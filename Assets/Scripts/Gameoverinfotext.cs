using UnityEngine;
using UnityEngine.UI;

public class Gameoverinfotext : MonoBehaviour
{

    public GameObject Diamond;
    public GameManager gameManager;
    public bool mystage;
    public bool mybeststage;
    public bool mydia;

    public Text mystagetext;

    public Text mybeststagetext;

    public Text mydiatext;
 

    void Update()
    {
        if (mystage)
        {
            mystagetext.text = "Stage " + gameManager.GetComponent<GameManager>().stagelevel.ToString("F0");
        }
        if (mybeststage)
        {
            mybeststagetext.text = "Best Stage " + gameManager.GetComponent<GameManager>().highstagelevel.ToString("F0");
        }
        if (mydia)
        {
            mydiatext.text = "+ " + Diamond.GetComponent<Diamond>().earnedDiamondsThisRun.ToString("F0");
        }

    }
}
