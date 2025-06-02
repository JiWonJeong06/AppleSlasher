using UnityEngine;
using UnityEngine.UI;

public class Gameoverinfotext : MonoBehaviour
{

    public GameObject stage;
    public GameObject dia;

    public Text mystage;


    void Update()
    {
        mystage.text = stage.GetComponent<StageText>().BestStagelevel.ToString("F0");
    }
}
