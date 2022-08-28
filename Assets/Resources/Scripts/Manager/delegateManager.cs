using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegateManager : Singletone<delegateManager>
{
    private Dictionary<string, List<System.Action>> inputDelegate = new Dictionary<string, List<System.Action>>();

    protected override void init()
    {
        base.init();
    }

    public override void setInfo()
    {
        base.setInfo();
    }

    public Dictionary<string, List<System.Action>> getInputDelegate() { return inputDelegate; }
    public void setInputDelegate(string name, System.Action function)
    {
        List<System.Action> actions;

        if (!inputDelegate.TryGetValue(name, out actions))
        {
            actions = new List<System.Action>();
            inputDelegate.Add(name, actions);
        }
        actions.Add(function);
    }
}
