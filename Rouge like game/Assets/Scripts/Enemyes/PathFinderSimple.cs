using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderSimple : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    //Ne ispolzyi eto ebgavno
    private float speed = 2.0f;
    public void Start()
    {
        speed = gameObject.GetComponent<Enemy>().enemy.speed;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.Normalize(target.position - transform.position) * speed * Time.deltaTime);
    }
    public void SetTarget(Transform tr)
    {
        target = tr;
    }
}
