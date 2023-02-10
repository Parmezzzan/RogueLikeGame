using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private int poolSize;
    private GameObject poolObject;
    private GameObject[] poolObjects;
    private Transform root;
    public void Init(GameObject gameObject, int size, Transform newRoot)
    {
        root = newRoot;
        poolSize = size;
        poolObject = gameObject;
        Init();
    }
    private void Init()
    {
        poolObjects = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            poolObjects[i] = Instantiate(poolObject) as GameObject;
            poolObjects[i].transform.parent = root;
            poolObjects[i].SetActive(false);
        }
    }
    public void Clear ()
    {
        for (int i = 0; i < poolSize; i++)
            poolObjects[i].SetActive(false);
    }
    public GameObject GetPoolObjectOrNull()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (poolObjects[i].gameObject.active == false)
            {
                poolObjects[i].SetActive(true);
                return poolObjects[i];
            }
        }

        return null;
    }
}
