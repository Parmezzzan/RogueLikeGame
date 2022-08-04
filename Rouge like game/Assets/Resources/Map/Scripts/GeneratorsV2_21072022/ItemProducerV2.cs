using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProducerV2 : MonoBehaviour
{
    [SerializeField]
    GameObject[] items;
    [SerializeField]
    Transform root;
    [Space(20)]
    [SerializeField]
    float distance = 0.5f;
    [SerializeField]
    int tryingNum = 1000;
    [SerializeField]
    int itemNum = 30;
    [SerializeField]
    bool enableObstaclePoolReference = true;
    [SerializeField]
    ObstacleProducerV2 obstacleGen;

    private List<GameObject> pull = new List<GameObject>();
    public void GenerateItems(MapConfiguration mapConfig)
    {
        var obstaclePull = new List<GameObject>();
        if (enableObstaclePoolReference)
            obstaclePull =  obstacleGen.GetObstaclePull();

        pull.Clear();
        int i = 0;
        int succes = 0;

        while (i < tryingNum && succes != itemNum)
        {
            var pos = GeneratePos(mapConfig);
            i++;
            bool valid = true;
            if (pull.Count > 1)
                foreach (var item in pull)
                {
                    if (Vector3.Distance(pos, item.transform.position) < distance)
                    {
                        valid = false;
                        break;
                    }
                }

            if(valid)
                if (enableObstaclePoolReference)
                    foreach (var item in obstaclePull)
                    {
                        if (Vector3.Distance(pos, item.transform.position) < distance)
                        {
                            valid = false;
                            break;
                        }
                    }
            if (valid)
            {
                succes++;
                pull.Add(
                    Instantiate(items[Random.Range(0, items.Length)],
                    pos, Quaternion.identity, root)
                    );
            }
        }
    }
    public Vector3 GeneratePos(MapConfiguration configuration)
    {
        var posX = Random.Range(configuration.LeftTopPosition().x, configuration.LeftTopPosition().x + configuration.MapUnit_Width);
        var posY = Random.Range(configuration.LeftTopPosition().y, configuration.LeftTopPosition().y - configuration.MapUnit_Height);
        var pos = new Vector3(posX, posY);

        return pos;
    }
    public void GenerateInAria(Vector2 pos, Vector2 size)
    {
        int itemAmount = itemNum; //10 -  is coifitient of map size
        for (int i = 0; i < itemAmount; i++)
        {
            var posX = Random.Range(pos.x, pos.x + size.x);
            var posY = Random.Range(pos.y - size.y, pos.y);
            var position = new Vector3(posX, posY);

            Instantiate(items[Random.Range(0, items.Length)],
                    position, Quaternion.identity, root);
        }
    }
}
