using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    private static ObjectPooler _instance;

    private static ObjectPooler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObjectPooler>();
                if (_instance == null)
                {
                    _instance = new GameObject("ObjectPooler").AddComponent<ObjectPooler>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            return _instance;
        }
    }
    // Use this for initialization
   public virtual void Start()
    {
        FillObjectsPool();
    }

    public virtual void FillObjectsPool()
    {
        return;
    } 
    public virtual GameObject GetPooledGameObject()
    {
        return null;
    }

}
