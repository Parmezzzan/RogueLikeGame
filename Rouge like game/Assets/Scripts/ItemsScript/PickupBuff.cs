using UnityEngine;

public class PickupBuff : MonoBehaviour
{
    [SerializeField]
    PlayerBuff buff;
    public void AddBuff(Transform playerTransform)
    {
          playerTransform.gameObject.GetComponent<PlayerBuffManager>().AddBuff(buff);
    }
}
