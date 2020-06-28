using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JsonHelper
{

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

    // public static string ToJSON(this object obj)
    // {
    //     JavaScriptSerializer serializer = new JavaScriptSerializer();
    //     return serializer.Serialize(obj);
    // }
}