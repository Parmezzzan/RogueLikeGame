using UnityEngine;

public class UIdeathScreen : MonoBehaviour
{
    [SerializeField]
    private float splashScreenTime = 3.0f;
    public void Death()
    {
        Invoke("Hide", splashScreenTime);
    }
}
