using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerV2 : MonoBehaviour
{
    [SerializeField]
    MapConfiguration mapConfig;
    [SerializeField]
    MapProducerV2 mapProducer;
    [SerializeField]
    ObstacleProducerV2 ObstacleProducer;
    [SerializeField]
    ItemProducerV2 ItemProducer;
    [SerializeField]
    WorldProvider worldProvider;

    void Start()
    {
        if (mapConfig.isChankGeneration)
            mapProducer.GenerateChankMap(mapConfig);
        else
            mapProducer.GenerateMap(mapConfig);

        ObstacleProducer.GenerateObstacle(mapConfig);
        ItemProducer.GenerateItems(mapConfig);
        worldProvider.Run();
    }
}
