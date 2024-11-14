using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T: Component
{
    private static T _instace;
    public static T Instance
    {
        get
        {
            if(_instace == null)
            {
                _instace = FindObjectOfType<T>();
                if(_instace == null)
                {
                    GameObject nuevoGO = new GameObject();
                    _instace = nuevoGO.AddComponent<T>();
                }
            }
            return _instace;
        }
    }

    protected virtual void Awake()
    {
        _instace = this as T;

    }
}
