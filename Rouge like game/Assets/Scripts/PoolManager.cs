using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    int poolSize = 50;
    [SerializeField]
    GameObject poolObj;
    [SerializeField]
    bool IsCycledBuffer = false;

    ObjectPool pool;
    void Start()
    {
        pool = new ObjectPool();
        pool.Init(poolObj, poolSize, gameObject.transform, IsCycledBuffer);
    }
    public GameObject GetObjectFromPool()
    {
        return pool.GetPoolObjectOrNull();
    }
}
