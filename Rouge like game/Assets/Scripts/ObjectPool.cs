using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    int poolSize;
    GameObject poolObject;
    GameObject[] poolObjects;
    Transform root;
    
    bool cycledPool;
    int currentindex;
    public void Init(GameObject gameObject, int size, Transform newRoot, bool isCycled = false)
    {
        root = newRoot;
        poolSize = size;
        poolObject = gameObject;
        cycledPool = isCycled;
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
        currentindex = 0;
    }
    public void Clear ()
    {
        for (int i = 0; i < poolSize; i++)
            poolObjects[i].SetActive(false);
    }
    public GameObject GetPoolObjectOrNull()
    {
        if (!cycledPool)
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
        else
        {
            currentindex++;
            if (currentindex >= poolSize) currentindex = 0; 
            poolObjects[currentindex].SetActive(true);
            return poolObjects[currentindex];
        }
    }
}
