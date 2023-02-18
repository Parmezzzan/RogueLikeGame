using System.Collections.Generic;
using UnityEngine;
public class EnemiesGeneratorV2 : MonoBehaviour
{
    [SerializeField]
    float distanse = 15.0f;
    [SerializeField]
    Transform root;
    [SerializeField]
    Transform targetTransform;
    [SerializeField] Transform expirienseRoot;

    [SerializeField] int expPoolSize = 200;
    [SerializeField] bool IsExpPoolCycled = true;
    [SerializeField] GameObject expItem;
    ObjectPool expPool;

    private float durationTime = 5.0f;
    private int pointOfSpawn = 1;
    int monstersCount = 0;
    private string[] monstersName;
    private List<GameObject> enemies;

    private bool generationOn = false;

    private void Awake()
    {
        expPool = new ObjectPool();
        expPool.Init(expItem, expPoolSize, expirienseRoot, IsExpPoolCycled);
    }
    public void Run()
    {
        generationOn = true;
        InvokeRepeating("Generation", 0.0f, durationTime);
    }
    public void Stop()
    {
        generationOn = false;
        StopAllCoroutines();
    }
    public void SetWaveData(WaveData wd)
    {
        pointOfSpawn = wd.spawnPointAmount;
        durationTime = wd.spawnEachSec;
        monstersCount = wd.monstersAmount;

        monstersName = wd.monstersName;
        enemies = new List<GameObject>();
        foreach (var item in monstersName)
        {
            enemies.Add((GameObject)Resources.Load("Enemies/" + item));
        }
    }
    private void Generation()
    {
        if (pointOfSpawn > monstersCount)
            pointOfSpawn = monstersCount;

        int countOnPoint = monstersCount / pointOfSpawn;

        for (int k = 0; k < pointOfSpawn; k++)
        {
            int theta = Random.Range(0, 360);
            float X = Mathf.Cos(theta) * distanse + targetTransform.position.x;
            float Y = Mathf.Sin(theta) * distanse + targetTransform.position.y;

            for (int i = 0; i < countOnPoint; i++)
            {
                int j = Random.Range(0, enemies.Count);
                var obj = Instantiate(enemies[j], new Vector3(X, Y, 0.0f), Quaternion.identity, root);
                obj.GetComponent<Enemy_HP>().SetExpPool(expPool);
                obj.GetComponent<Pathfinding.AIDestinationSetter>().target = targetTransform;  //heh kek but it's no error
            }
        }
    }
}
