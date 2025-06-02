using UnityEngine;
using UnityEngine.UI; // 또는 TextMeshProUGUI

public class Blink : MonoBehaviour
{
    public Text text; // 또는 TextMeshProUGUI
    public float interval = 0.5f;

    void Start()
    {
        InvokeRepeating(nameof(ToggleText), 0, interval);
    }

    void ToggleText()
    {
        text.enabled = !text.enabled;
    }
}
