using UnityEngine;
using UnityEngine.Events;

public class WeaponData : MonoBehaviour
{
    public float WeaponAria = 2.0f;
    public float Might = 10.0f;
    public float FireRate = 1.0f;

    [SerializeField]
    public UnityEvent DataHasUpdated;
}
