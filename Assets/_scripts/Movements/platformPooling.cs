using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformPooling : ObjectPooler
{

    public GameObject Platforms;


    public int PoolSize = 20;

    public bool poolCanExpand = true;

    private GameObject _waitingPool;
    private List<GameObject> _pooledPlatforms;


    public override void FillObjectsPool()
    {
        _waitingPool = new GameObject("[platformPooling]" + this.name);
        _pooledPlatforms = new List<GameObject>();

        for (int i = 0; i < PoolSize; i++)
        {
            AddOneObjectToPool();
        }
    }
    public override GameObject GetPooledGameObject()
    {
       
        for (int i = 0; i < _pooledPlatforms.Count; i++)
        {
            if (!_pooledPlatforms[i].gameObject.activeInHierarchy)
            {
               
                return _pooledPlatforms[i];
            }
        }
        
        if (poolCanExpand)
        {
            return AddOneObjectToPool();
        }
      
        return null;
    }


    public virtual GameObject AddOneObjectToPool()
    {
        if (Platforms ==null)
        {
            Debug.Log("No platform Pooled");
            return null;
        }

        GameObject ObjectPlatform = (GameObject)Instantiate(Platforms);
        ObjectPlatform.gameObject.SetActive(false);
        ObjectPlatform.transform.parent = _waitingPool.transform;
        ObjectPlatform.name = Platforms.name + "-" + _pooledPlatforms.Count;
        _pooledPlatforms.Add(ObjectPlatform);
        return ObjectPlatform;
    }
}
