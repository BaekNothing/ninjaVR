using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
using DG.Tweening;

public class mudraManager : Singletone<mudraManager>
{
    protected List<actionName> mudra = new List<actionName>();
    protected GameObject mudraHand;
    protected Material matMudraHand;
    protected List<Texture> mudraHandSprite = new List<Texture>();
    protected int mudraFlag = 0;

    public override void setInfo()
    {
        base.setInfo();
    }

    protected override void init()
    {
        base.init();
        setMudra(actionName.left_frontbtn);
        setMudra(actionName.left_backbtn);
        setMudra(actionName.right_frontbtn);
        setMudra(actionName.right_backbtn);

        releaseMudra(actionName.trigger);

        mudraHand = GameObject.Find("MudraHand");
        mudraHand.SetActive(false);

        matMudraHand = mudraHand.GetComponent<MeshRenderer>().material;
        mudraHandSprite.Add(resourceManager.instance.resourceLoad<Texture>("Image/Mudra", "Mudra_1"));
        mudraHandSprite.Add(resourceManager.instance.resourceLoad<Texture>("Image/Mudra", "Mudra_2"));
        mudraHandSprite.Add(resourceManager.instance.resourceLoad<Texture>("Image/Mudra", "Mudra_3"));
        mudraHandSprite.Add(resourceManager.instance.resourceLoad<Texture>("Image/Mudra", "Mudra_4"));
    }

    private void Update()
    {
        mudraHand.transform.position = Vector3.Lerp
            (controller.leftHand.position, controller.rightHand.position, 0.5f);
    }

    protected void setMudra(actionName actionName)
    {
        delegateManager.instance.setInputDelegate(actionName.ToString(), delegate 
        {
            if (mudraFlag != 0)
                return;
            float distance = Vector3.Distance(controller.rightHand.position, controller.leftHand.position);
            Debug.Log(distance);
            if (distance >= 100f)
                return;

            mudraFlag = 1;
            mudraHand.SetActive(true);
            controller.leftHand.gameObject.SetActive(false);
            controller.rightHand.gameObject.SetActive(false);

            if (mudra.Count == 0 || (mudra.Count > 0 && mudra[mudra.Count - 1] != actionName))
            {
                mudra.Add(actionName);
                switch(actionName)
                {
                    case actionName.left_frontbtn   :
                        matMudraHand.SetTexture("_MainTex", mudraHandSprite[0]);
                        break;
                    case actionName.left_backbtn    :
                        matMudraHand.SetTexture("_MainTex", mudraHandSprite[1]);
                        break;
                    case actionName.right_frontbtn  :
                        matMudraHand.SetTexture("_MainTex", mudraHandSprite[2]);
                        break;
                    case actionName.right_backbtn   :
                        matMudraHand.SetTexture("_MainTex", mudraHandSprite[3]);
                        break;
                    default:
                        break;
                }
            }
            effectManager.instance.playEffect("mudra");
            soundManager.instance.playClip("mudra", "mudra",
                UnityEngine.Random.Range(0, soundManager.instance.clipLength("mudra")));
            DOTween.To(() => mudraFlag, x => mudraFlag = x, 10, 1.2f).OnComplete(() => {
                mudraFlag = 0;
                mudraHand.SetActive(false);
                controller.leftHand.gameObject.SetActive(true);
                controller.rightHand.gameObject.SetActive(true);
                Debug.Log(mudraFlag);
            });
        });
    }

    protected void releaseMudra(actionName actionName)
    {
        delegateManager.instance.setInputDelegate(actionName.ToString(), delegate
        {
            foreach (actionName action in mudra)
                Debug.Log(action);
            if (mudra.Count == 3)
                showNinjutsu(mudra[2]);
            else
            {
                //≈‰≥¢
            }
            mudra.Clear();
        });
    }
    
    protected void showNinjutsu(actionName actionName)
    {
        switch (actionName)
        {
            case actionName.right_backbtn :
                soundManager.instance.playClip("ninjutsu", "ninjutsu", 0);
                soundManager.instance.playClip("spell", "spell", 0);
                mudraThree_fire();
                break;

            default:
                Debug.Log("no mached Ninjutsu");
                break;
        }
    }

    void mudraThree_fire()
    {
        GameObject flame = GameObject.Find("EffectOrigin").transform.Find("FlameStream").gameObject;
        flame.SetActive(false);
        flame.SetActive(true);
    }

}
