using UnityEngine;

public class damageIcon : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 1.5f;
    [SerializeField]
    float moveSpeed = 2.0f;
    void Update()
    {
        transform.position += (Vector3.up * Time.deltaTime * moveSpeed);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            lifeTime = 1.5f;
            gameObject.SetActive(false);
        }
    }
    public void setText(string text)
    {
        gameObject.GetComponent<TextMesh>().text = text;
    }
}
