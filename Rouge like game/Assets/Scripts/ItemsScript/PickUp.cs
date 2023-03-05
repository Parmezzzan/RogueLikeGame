using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour, IFarm
{
    public delegate void PuckUpD(Transform t);
    public event PuckUpD OnPickUP;

    [SerializeField]
    float upMoveDistanseKoifitient = 0.2f;
    [SerializeField]
    float movingSpeed = 10.0f;
    [SerializeField]
    float destroyDistanse = 0.3f;

    [SerializeField] bool isPooled = false;

    private Transform target;

    public void GetFarm(PlayerData playerDataObj)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        target = playerDataObj.gameObject.transform;
        StartCoroutine(GetBuff());
    }

    private IEnumerator GetBuff()
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
        OnPickUP?.Invoke(target);

        if (isPooled) gameObject.SetActive(false);
        else Destroy(gameObject);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
