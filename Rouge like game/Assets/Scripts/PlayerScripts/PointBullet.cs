using UnityEngine;

public class PointBullet : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 3.0f;
    [SerializeField]
    private float speed = 15.0f;
    [SerializeField]
    private Vector3 targetNarrow = Vector3.zero;
    [SerializeField]
    private string tagEnemy = "Enemy";
    [SerializeField]
    private int damage = 15;

    MusicPlayer musicPlayer;
     private void Update()
    {
        transform.position = transform.position + (targetNarrow * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagEnemy))
        {
            musicPlayer.playSound();
            collision.GetComponent<Enemy_HP>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
    public void MusicHitFx(MusicPlayer mp) => musicPlayer = mp;
    public void SetTargetPoint(Vector3 newTargetPoin) => targetNarrow = newTargetPoin;
    
    public void SetDemage(int newDemage)=>damage = newDemage;

    public void SetSpeed(float newSpeed)=>speed = newSpeed;

    public void SetLifeTime(float newLifeTime)=>lifeTime = newLifeTime;
}
