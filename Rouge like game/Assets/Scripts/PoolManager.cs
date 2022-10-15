using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    int poolSize = 50;
    [SerializeField]
    GameObject poolObj;

    ObjectPool pool;
    void Start()
    {
        pool = new ObjectPool();
        pool.Init(poolObj, poolSize, gameObject.transform);
    }
    public GameObject GetObjectFromPool()
    {
        return pool.GetPoolObjectOrNull();
    }
}
