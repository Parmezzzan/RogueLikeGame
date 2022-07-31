using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using System;

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
    private WaveData[] waveDatas;
    public class WaveData
    { 
        public int waveNum { get; set; }
        public int waveBeginSec { get; set; }
        public int spawnPointAmount { get; set; }
        public int spawnEachSec { get; set; }
        public int monstersAmount { get; set; }
        public string[] monstersName { get; set; }

        public override string ToString()
        {
            return string.Format("#:{0},{1},{2},{3},{4},{5}",
                            waveNum, waveBeginSec, spawnPointAmount, spawnEachSec, monstersAmount, monstersName);
        }
    }
    private void Start()
    {
        //csvLines = new string[5];
        csvLines = File.ReadAllLines(csvPath);
        waveDatas = new WaveData[csvLines.Length-1];

        for (int i = 0; i < csvLines.Length - 1; i++)
        {
            waveDatas[i] = new WaveData();
            string[] dataString= csvLines[i+1].Split(';');
            waveDatas[i].waveNum = Int32.Parse(dataString[0]);
            waveDatas[i].waveBeginSec = Int32.Parse(dataString[1]);
            waveDatas[i].spawnPointAmount = Int32.Parse(dataString[2]);
            waveDatas[i].spawnEachSec = Int32.Parse(dataString[3]);
            waveDatas[i].monstersAmount = Int32.Parse(dataString[4]);
            waveDatas[i].monstersName = dataString[5].Split(',');

            print(waveDatas[i].ToString());
        }
    }
}
