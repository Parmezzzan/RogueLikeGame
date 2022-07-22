using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleProducerV2 : MonoBehaviour
{
    [SerializeField]
    GameObject[] obstacles;
    [SerializeField]
    Transform root;
    [Space(20)]
    [SerializeField]
    int obstaclesNum = 10;
    [SerializeField]
    int tryingNum = 300;
    [SerializeField]
    float distance;

    private List<GameObject> pull = new List<GameObject>();
    public void GenerateObstacle(MapConfiguration configuration)
    {
        pull.Clear();
        int i = 0;
        int succes = 0;

        while (i < tryingNum && succes != obstaclesNum)
        {
            var pos = GeneratePos(configuration);
            i++;
            bool valid = true;
            if(pull.Count > 1)
                foreach (var item in pull)
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
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)],
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
    public List<GameObject> GetObstaclePull()
    {
        return pull;
    }
}
