using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<T>();
                    singleton.name = typeof(T).Name;
                }
            }

            return instance;
        }
    }

    public virtual void Awake()
    {
        if(instance == null) 
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }    
}
