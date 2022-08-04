using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TranslationType
{
    none,
    left,
    right,
    up,
    down
}
public class WorldProvider : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    Vector2 windowsSize;
    [SerializeField]
    Transform[] scrollRoots;
    [SerializeField]
    Transform[] scrolRootsWitsDeleting;
    [SerializeField]
    UnityEvent OnDestroyInAria;
    [SerializeField]
    MapConfiguration mapConfig;
    

    private bool scrolEnable = false;
    private Vector2 windowCentralPoint;
    private Vector2 forbiddenZone;
    private Vector2 translation;
    TranslationType transType;
    void Update()
    {
        if (scrolEnable && IsTargetWayout() != TranslationType.none)
        {
            if (transType == TranslationType.left)
            {
                for (int j = 0; j < scrollRoots.Length; j++)
                {
                    var transformArray = new List<Transform>();
                    for (int k = 0; k < scrollRoots[j].childCount; k++)
                    {
                        transformArray.Add(scrollRoots[j].GetChild(k));
                    }
                    for (int i = 0; i < transformArray.Count; i++)
                    {
                        if (transformArray[i].position.x > translation.x)
                            transformArray[i].Translate(-mapConfig.MapUnit_Width, 0.0f, 0.0f, Space.World);
                    }
                }
            }
            if (transType == TranslationType.right)
            {
                for (int j = 0; j < scrollRoots.Length; j++)
                {
                    var transformArray = new List<Transform>();
                    for (int k = 0; k < scrollRoots[j].childCount; k++)
                    {
                        transformArray.Add(scrollRoots[j].GetChild(k));
                    }
                    for (int i = 0; i < transformArray.Count; i++)
                    {
                        if (transformArray[i].position.x < translation.x)
                            transformArray[i].Translate(mapConfig.MapUnit_Width, 0.0f, 0.0f, Space.World);
                    }
                }
            }
            if (transType == TranslationType.up)
            {
                for (int j = 0; j < scrollRoots.Length; j++)
                {
                    var transformArray = new List<Transform>();
                    for (int k = 0; k < scrollRoots[j].childCount; k++)
                    {
                        transformArray.Add(scrollRoots[j].GetChild(k));
                    }
                    for (int i = 0; i < transformArray.Count; i++)
                    {
                        if (transformArray[i].position.y < translation.y)
                            transformArray[i].Translate(0.0f, mapConfig.MapUnit_Height, 0.0f, Space.World);
                    }
                }
            }
            if (transType == TranslationType.down)
            {
                for (int j = 0; j < scrollRoots.Length; j++)
                {
                    var transformArray = new List<Transform>();
                    for (int k = 0; k < scrollRoots[j].childCount; k++)
                    {
                        transformArray.Add(scrollRoots[j].GetChild(k));
                    }
                    for (int i = 0; i < transformArray.Count; i++)
                    {
                        if (transformArray[i].position.y > translation.y)
                            transformArray[i].Translate(0.0f, -mapConfig.MapUnit_Height, 0.0f, Space.World);
                    }
                }
            }
        }
    }
    public void Run()
    {
        windowCentralPoint = mapConfig.CurrentCentralPosition;
        scrolEnable = true;
    }
    public void Stop()
    {
        scrolEnable = false;
    }
    private TranslationType IsTargetWayout()
    {
        if (target.transform.position.x < windowCentralPoint.x - windowsSize.x / 2)
        {
            translation.x = windowCentralPoint.x + mapConfig.MapUnit_Width / 2.0f - windowsSize.x / 2.0f;
            windowCentralPoint.x -= windowsSize.x / 2;
            transType = TranslationType.left;
            return transType;
        }
        if (target.transform.position.x > windowCentralPoint.x + windowsSize.x / 2)
        {
            translation.x = windowCentralPoint.x - mapConfig.MapUnit_Width / 2.0f + windowsSize.x / 2.0f;
            windowCentralPoint.x += windowsSize.x / 2;
            transType = TranslationType.right;
            return transType;
        }
        if (target.transform.position.y > windowCentralPoint.y + windowsSize.y / 2)
        {
            translation.y = windowCentralPoint.y - mapConfig.MapUnit_Height / 2.0f + windowsSize.y / 2.0f;
            windowCentralPoint.y += windowsSize.y / 2;
            transType = TranslationType.up;
            return transType;
        }
        if (target.transform.position.y < windowCentralPoint.y - windowsSize.y / 2)
        {
            translation.y = windowCentralPoint.y + mapConfig.MapUnit_Height / 2.0f - windowsSize.y / 2.0f;
            windowCentralPoint.y -= windowsSize.y / 2;
            transType = TranslationType.down;
            return transType;
        }

        transType = TranslationType.none;
        return transType;
    }
    /*
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow; 
        Gizmos.DrawCube(new Vector3(windowCentralPoint.x, windowCentralPoint.y, 0.0f), 
                        new Vector3(windowsSize.x, windowsSize.y, 1));
    }
    */
}
