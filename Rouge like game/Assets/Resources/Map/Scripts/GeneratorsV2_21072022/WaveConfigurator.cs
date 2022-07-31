using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public class WaveConfigurator : MonoBehaviour
{
    [SerializeField]
    public int numWave = 0;
    [SerializeField]
    public float startTimeSec = 1;
    [SerializeField]
    public int spawnPointCount = 2;
    [SerializeField]
    public int spawnEachSec = 2;
    [SerializeField]
    public int monstersCount = 6;
    [SerializeField]
    public string monstersName = "ent;spider";

    private static string csvPath = "Assets/Resources/Map/Scripts/GeneratorsV2_21072022/Monsters wave description.csv";
    private string[] csvLines;
    public class WaveData
    { 
        public int waveNum { get; set; }
        public int waveBeginSec { get; set; }
        public int spawnPointAmount { get; set; }
        public int spawnEachSec { get; set; }
        public int monstersAmount { get; set; }
        public string[] monstersName { get; set; }
    }
    private void Start()
    {
        //csvLines = File.ReadAllLines()
    }
}
