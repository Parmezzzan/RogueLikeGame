using UnityEngine;
public class EnemiesGeneratorV2 : MonoBehaviour
{
    [SerializeField]
    float durationTime = 2.0f;
    [SerializeField]
    float preparationTime = 3.0f;
    [SerializeField]
    int pointOfSpawn = 2;
    [SerializeField]
    int count = 3;
    [SerializeField]
    float distanse = 15.0f;
    [Space(20)]
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    Transform root;
    [SerializeField]
    Transform targetTransform;

    private bool generationOn = false;

    public void Run()
    {
        generationOn = true;
        InvokeRepeating("Generation", preparationTime, durationTime);
    }
    public void Stop()
    {
        generationOn = false;
        targetTransform = null;
        StopAllCoroutines();
    }
    private void Generation()
    {
        int countOnPoint = count / pointOfSpawn;

        for (int k = 0; k < pointOfSpawn; k++)
        {
            int theta = Random.Range(0, 360);
            float X = Mathf.Cos(theta) * distanse + targetTransform.position.x;
            float Y = Mathf.Sin(theta) * distanse + targetTransform.position.y;

            for (int i = 0; i < countOnPoint; i++)
            {
                int j = Random.Range(0, enemies.Length);
                var obj = Instantiate(enemies[j], new Vector3(X, Y, 0.0f), Quaternion.identity, root);
                obj.GetComponent<Pathfinding.AIDestinationSetter>().target = targetTransform;  //heh kek but it's no error
            }
        }
    }
}
