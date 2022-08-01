using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using System;
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
public class WaveConfigurator : MonoBehaviour
{
    [SerializeField]
    private EnemiesGeneratorV2 enemiesGenerator;

    private static string csvPath = "Assets/Resources/Map/Scripts/GeneratorsV2_21072022/Monsters wave description.csv";
    private string[] csvLines;
    private WaveData[] waveDatas;
    private int nextWaveNum = 0;

    private void Start()
    {
        csvLines = File.ReadAllLines(csvPath);
        waveDatas = new WaveData[csvLines.Length - 1];
        nextWaveNum = 0;
        for (int i = 0; i < csvLines.Length - 1; i++)
        {
            waveDatas[i] = new WaveData();
            string[] dataString = csvLines[i + 1].Split(';');
            waveDatas[i].waveNum = Int32.Parse(dataString[0]);
            waveDatas[i].waveBeginSec = Int32.Parse(dataString[1]);
            waveDatas[i].spawnPointAmount = Int32.Parse(dataString[2]);
            waveDatas[i].spawnEachSec = Int32.Parse(dataString[3]);
            waveDatas[i].monstersAmount = Int32.Parse(dataString[4]);
            waveDatas[i].monstersName = dataString[5].Split(',');
        }

        SendDataToWaveProducer();
    }
    private void SendDataToWaveProducer()
    {
        enemiesGenerator.Stop();
        enemiesGenerator.SetWaveData(waveDatas[nextWaveNum]);
        enemiesGenerator.Run();
        nextWaveNum++;
    }
    public void Stop()
    {
        StopAllCoroutines();
        enemiesGenerator.Stop();
    }
}
