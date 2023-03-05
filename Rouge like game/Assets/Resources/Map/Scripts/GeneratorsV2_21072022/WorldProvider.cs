using Pathfinding;
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
    Transform[] scrolRootsWitsPolling;
    [SerializeField]
    ItemProducerV2 itemProducerV2;
    [SerializeField]
    MapConfiguration mapConfig;


    private bool scrolEnable = false;
    private Vector2 windowCentralPoint;
    private Vector2 forbiddenZone;
    private Vector2 translation;
    TranslationType transType;

    void FixedUpdate()
    {
        if (scrolEnable && IsTargetWayout() != TranslationType.none)
        {
            if (transType == TranslationType.left)
            {
                for (int j = 0; j < scrollRoots.Length; j++)
                {
                    var transformArray = new List<Transform>();
                    for (int k = 0; k < scrollRoots[j].childCount; k++)
                        transformArray.Add(scrollRoots[j].GetChild(k));

                    for (int i = 0; i < transformArray.Count; i++)
                    {
                        if (transformArray[i].position.x > translation.x)
                            transformArray[i].Translate(-mapConfig.MapUnit_Width, 0.0f, 0.0f, Space.World);
                    }
                }
                if (scrolRootsWitsDeleting.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsDeleting.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsDeleting[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsDeleting[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.x > translation.x)
                                Destroy(transformArray[i].gameObject);
                    }
                }
                if (scrolRootsWitsPolling.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsPolling.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsPolling[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsPolling[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.x > translation.x)
                                transformArray[i].gameObject.SetActive(false);
                    }
                    var pos = new Vector2(target.transform.position.x - mapConfig.MapUnit_Width / 2.0f - windowsSize.x,
                                        target.transform.position.y + mapConfig.MapUnit_Height / 2.0f);
                    var size = new Vector2(windowsSize.x, mapConfig.MapUnit_Height);
                    itemProducerV2.GenerateInAria(pos, size);
                }
                UpdatePathFinder();
                return;
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
                if (scrolRootsWitsDeleting.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsDeleting.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsDeleting[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsDeleting[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.x < translation.x)
                                Destroy(transformArray[i].gameObject);
                    }
                }
                if (scrolRootsWitsPolling.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsPolling.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsPolling[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsPolling[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.x < translation.x)
                                transformArray[i].gameObject.SetActive(false);
                    }
                    var pos = new Vector2(target.transform.position.x + mapConfig.MapUnit_Width / 2.0f - windowsSize.x,
                                        target.transform.position.y + mapConfig.MapUnit_Height / 2.0f);
                    var size = new Vector2(windowsSize.x, mapConfig.MapUnit_Height);
                    itemProducerV2.GenerateInAria(pos, size);
                }
                UpdatePathFinder();
                return;
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
                if (scrolRootsWitsDeleting.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsDeleting.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsDeleting[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsDeleting[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.y < translation.y)
                                Destroy(transformArray[i].gameObject);
                    }
                }
                if (scrolRootsWitsPolling.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsPolling.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsPolling[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsPolling[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.y < translation.y)
                                transformArray[i].gameObject.SetActive(false);
                    }
                    var pos = new Vector2(target.transform.position.x - mapConfig.MapUnit_Width / 2.0f,
                                       target.transform.position.y + mapConfig.MapUnit_Height - windowsSize.y);
                    var size = new Vector2(mapConfig.MapUnit_Width, windowsSize.y);
                    itemProducerV2.GenerateInAria(pos, size);
                }
                UpdatePathFinder();
                return;
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
                if (scrolRootsWitsDeleting.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsDeleting.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsDeleting[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsDeleting[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.y > translation.y)
                                Destroy(transformArray[i].gameObject);
                    }
                    var pos = new Vector2(target.transform.position.x - mapConfig.MapUnit_Width / 2.0f,
                                        target.transform.position.y - mapConfig.MapUnit_Height / 2.0f + windowsSize.y);
                    var size = new Vector2(mapConfig.MapUnit_Width, windowsSize.y);
                    itemProducerV2.GenerateInAria(pos, size);
                }
                if (scrolRootsWitsPolling.Length > 0)
                {
                    for (int m = 0; m < scrolRootsWitsPolling.Length; m++)
                    {
                        var transformArray = new List<Transform>();
                        for (int k = 0; k < scrolRootsWitsPolling[m].childCount; k++)
                            transformArray.Add(scrolRootsWitsPolling[m].GetChild(k));

                        for (int i = 0; i < transformArray.Count; i++)
                            if (transformArray[i].position.y > translation.y)
                                transformArray[i].gameObject.SetActive(false);
                    }
                    var pos = new Vector2(target.transform.position.x - mapConfig.MapUnit_Width / 2.0f,
                                        target.transform.position.y - mapConfig.MapUnit_Height / 2.0f + windowsSize.y);
                    var size = new Vector2(mapConfig.MapUnit_Width, windowsSize.y);
                    itemProducerV2.GenerateInAria(pos, size);
                }
                UpdatePathFinder();
                return;
            }
        }
    }
    private void UpdatePathFinder()
    {
        var gg = AstarPath.active.astarData.gridGraph;
        gg.center = target.transform.position;
        //gg.RelocateNodes(target.transform.position, Quaternion.Euler(90, 0, 0), 1.35f);
        //gg.UpdateSizeFromWidthDepth();
        gg.UpdateTransform();
        // Recalculate the graph
        AstarPath.active.Scan();
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
}
