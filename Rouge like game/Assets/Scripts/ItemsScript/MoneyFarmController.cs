using System.Collections;
using UnityEngine;

public class MoneyFarmController : MonoBehaviour
{
    [SerializeField]
    int MoneyFarmAmount = 20;
    private void Start()
    {
        gameObject.GetComponent<Pickup>().OnPickUP += GetGem;
    }
    private void GetGem(Transform t)
    {
        t.gameObject.GetComponent<PlayerData>().AddMoney(MoneyFarmAmount);
        gameObject.GetComponent<Pickup>().OnPickUP -= GetGem;
    }
}
