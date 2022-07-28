using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfigurator : MonoBehaviour
{
    [SerializeField]
    public int numWave = 0;
    [SerializeField]
    public float startTime = 1;
    [SerializeField]
    public int spawnPointCount = 2;
    [SerializeField]
    public int spawnPerWave = 2;
    [SerializeField]
    public int monstersCount = 6;
    [SerializeField]
    public float dyfficultOfWave = 0.2f;
    [SerializeField]
    public string monstersType = "fly";
    [SerializeField]
    public string monstersName = "ent;spider";
    [SerializeField]
    public string stopListType = "boss";
}
