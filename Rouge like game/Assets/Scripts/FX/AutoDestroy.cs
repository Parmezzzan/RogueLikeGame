using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 3f;
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) gameObject.SetActive(false);
    }
}
