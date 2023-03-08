using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 3f;

    float curLifeTime;
    private void Awake()
    {
        curLifeTime = lifeTime;
    }
    void Update()
    {
        curLifeTime -= Time.deltaTime;
        if (curLifeTime < 0) gameObject.SetActive(false);
    }
    public void Reload()
    {
        curLifeTime = lifeTime;
    }
}
