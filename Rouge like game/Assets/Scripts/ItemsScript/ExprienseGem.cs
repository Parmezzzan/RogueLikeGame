using System.Collections;
using UnityEngine;

public class ExprienseGem : MonoBehaviour, IFarm
{
    [SerializeField]
    int EXPboost = 20;
    [SerializeField]
    float upMoveDistanseKoifitient = 0.2f;
    [SerializeField]
    float movingSpeed = 10.0f;
    [SerializeField]
    float destroyDistanse = 0.3f;

    private Transform target;
    private PlayerData playerData;

    public void GetFarm(PlayerData playerDataObj)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        target = playerDataObj.gameObject.transform;
        playerData = playerDataObj;
        StartCoroutine(GetGem());
    }
    private IEnumerator GetGem()
    {
        while (upMoveDistanseKoifitient > 0) {
            upMoveDistanseKoifitient -= Time.deltaTime;
            transform.position += Vector3.up * Time.deltaTime * movingSpeed;
            yield return null;
        }
        while (Vector3.Distance(transform.position, target.position) > destroyDistanse){
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * movingSpeed);
            yield return null;
        }
        playerData.AddEXP(EXPboost);
        Destroy(gameObject);
    }
}
