using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    InputModule inputModule;

    void Start()
    {
        DontDestroyOnLoad(this);
        delegateManager.instance.setInfo();
        inputModule = this.GetComponent<InputModule>();

        
        soundManager.instance.setInfo();
        effectManager.instance.setInfo();
        mudraManager.instance.setInfo();
    }

    // Update is called once per frame
    void Update()
    {
        inputModule.InputCheck();
    }
}
