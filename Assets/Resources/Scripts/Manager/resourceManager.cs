using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class resourceManager : Singletone<resourceManager>
{
    protected override void init()
    {
        base.init();
    }

    public override void setInfo()
    {
        base.setInfo();
    }

    public T resourceLoad<T>(string folder, string resourceName) where T : class
    {
        T result = Resources.Load($"{folder}/{resourceName}", typeof(T)) as T;
        return result;
    }

    public T[] resourceLoadAll<T>(string folder) where T : Object
    {
        T[] result = Resources.LoadAll<T>(folder);
        return result;
    }
}
