using UnityEngine;

public class SessionSaveManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData pd;
    public void SaveSession() => SaveManager.SaveSession(new SaveFile() { money = pd.GetAccMonney() });
}
