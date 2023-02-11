using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHP : MonoBehaviour, IFarm
{
    [SerializeField]
    int healPower = 20;

    [SerializeField]
    float upMoveDistanseKoifitient = 0.2f;
    [SerializeField]
    float movingSpeed = 10.0f;
    [SerializeField]
    float destroyDistanse = 0.3f;

    private Transform target;
    public void GetFarm(PlayerData playerDataObj)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        target = playerDataObj.gameObject.transform;
        StartCoroutine(GetHeal());
    }

    private IEnumerator GetHeal()
    {
        while (upMoveDistanseKoifitient > 0)
        {
            upMoveDistanseKoifitient -= Time.deltaTime;
            transform.position += Vector3.up * Time.deltaTime * movingSpeed;
            yield return null;
        }
        while (Vector3.Distance(transform.position, target.position) > destroyDistanse)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * movingSpeed);
            yield return null;
        }
        target.GetComponent<PlayerData>().Heal(healPower);
        Destroy(gameObject);
    }
}
