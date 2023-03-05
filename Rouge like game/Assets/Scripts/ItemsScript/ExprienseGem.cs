using System.Collections;
using UnityEngine;

public class ExprienseGem : MonoBehaviour
{
    [SerializeField]
    int EXPboost = 20;

    private void Start()
    {
        gameObject.GetComponent<Pickup>().OnPickUP += getExp;
    }
    public void getExp(Transform t)
    {
        t.gameObject.GetComponent<PlayerData>().AddEXP(EXPboost);
    }
}
