using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufLoader : MonoBehaviour
{
    [SerializeField]
    private PlayerBuffManager buffManager;

    private string pathBuffFile = "SaveGame/savebuff";
    void Start()
    {
        LoadBuffToPlayer();
    }
    private void LoadBuffToPlayer()
    {
        List<PlayerBuff> buffs = new List<PlayerBuff>();
        var textFile = Resources.Load<TextAsset>(pathBuffFile).text;
        var buffsName = textFile.Split(',');
        if(buffsName.Length > 0)
        {
            foreach (var item in buffsName)
            {
                var buff = Resources.Load("PlayerBuff/"+ item) as PlayerBuff;
                buffManager.AddBuff(buff);
            }
        }    
    }
}
