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
    [SerializeField]
    EnemiesGeneratorV2 enemiesGeneratorV2;

    void Start()
    {
        mapProducer.GenerateMap(mapConfig);
        ObstacleProducer.GenerateObstacle(mapConfig);
        ItemProducer.GenerateItems(mapConfig);
        worldProvider.Run();
        enemiesGeneratorV2.Run();
    }
}
