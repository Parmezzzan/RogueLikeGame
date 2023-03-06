using System.Collections.Generic;
using UnityEngine;
public class EnemiesGeneratorV2 : MonoBehaviour
{
    [SerializeField]
    float distanse = 15.0f;
    [SerializeField]
    Transform monstersRoot;
    [SerializeField]
    Transform targetTransform;

    [SerializeField] int MonsterPoolSize = 300;
    [SerializeField] GameObject monsterPrefab;
    ObjectPool monstersPool;
    [SerializeField] bool IsMonstersPoolCycled = true;

    [SerializeField] Transform expirienseRoot;
    [SerializeField] int expPoolSize = 200;
    [SerializeField] bool IsExpPoolCycled = true;
    [SerializeField] GameObject expItem;
    ObjectPool expPool;

    private float durationTime = 5.0f;
    private int pointOfSpawn = 1;
    int monstersCount = 0;
    private string[] monstersName;
    private List<EnemyData> enemiesScriptableData;

    private bool generationOn = false;

    private void Awake()
    {
        monstersPool = new ObjectPool();
        monstersPool.Init(monsterPrefab, MonsterPoolSize, monstersRoot, IsMonstersPoolCycled);

        expPool = new ObjectPool();
        expPool.Init(expItem, expPoolSize, expirienseRoot, IsExpPoolCycled);

        for (int i = 0; i < MonsterPoolSize; i++)
        {
            var obj = monstersPool.GetPoolObjectOrNull();
            obj.GetComponent<Enemy_HP>().SetExpPool(expPool);
            obj.SetActive(false);
        }
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
        enemiesScriptableData = new List<EnemyData>();
        foreach (var item in monstersName)
        {
            enemiesScriptableData.Add(Resources.Load<EnemyData>("EnemyBiom/" + item));
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
                int j = Random.Range(0, enemiesScriptableData.Count);
                var obj = monstersPool.GetPoolObjectOrNull();
                obj.GetComponent<Enemy>().SetData(enemiesScriptableData[j]);
                obj.GetComponent<Pathfinding.AIDestinationSetter>().target = targetTransform;  //heh kek but it's no error
                obj.transform.position = new Vector3(X, Y, 0.0f);
            }
        }
    }
}
