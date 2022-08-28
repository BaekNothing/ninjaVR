using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class effectManager : Singletone<effectManager>
{
    protected Dictionary<string, GameObject> effects = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    protected override void init()
    {
        base.init();
        effects.Add("mudra",
            controller.originCamera.Find("EffectOrigin").Find("_effNinjutsu").gameObject);
    }

    public override void setInfo()
    {
        base.setInfo();
    }

    public void playEffect(string name)
    {
        if (!effects.TryGetValue(name, out GameObject effect))
            return;

        effect.SetActive(false);
        effect.SetActive(true);
    }
}
