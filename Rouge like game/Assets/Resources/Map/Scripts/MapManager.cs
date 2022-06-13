using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    MapGenerator mapGenerator;
    [SerializeField]
    ItemGenerator itemManager;
    [SerializeField]
    ObstacleGenerator ObstacleGenerator;

    private void Start()
    {
        mapGenerator.Generate();
        itemManager.Generate();
        ObstacleGenerator.Generate();
    }
}
