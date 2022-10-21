using UnityEngine;
using UnityEngine.UI;

public class UICoinCounter : MonoBehaviour
{
    [SerializeField]
    Text UItext;
    public void UpdateCounter(int n) => UItext.text = n.ToString();
}
