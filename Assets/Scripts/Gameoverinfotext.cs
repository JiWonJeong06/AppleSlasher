using UnityEngine;
using UnityEngine.UI;

public class Gameoverinfotext : MonoBehaviour
{

    public GameObject Diamond;
    public GameManager gameManager;
    public bool mystage;
    public bool mybeststage;
    public bool mydia;

    Text mystagetext;

    Text mybeststagetext;

    Text mydiatext;
    void Start()
    {
        mystagetext = GetComponent<Text>();
        mybeststagetext = GetComponent<Text>();
        mydiatext = GetComponent<Text>();

    }

    void Update()
    {
        if (mystage)
        {
            mystagetext.text = "현재 스테이지: " + gameManager.GetComponent<GameManager>().stagelevel.ToString("F0");
        }
        if (mybeststage)
        {
            mybeststagetext.text = "최고 스테이지: " + gameManager.GetComponent<GameManager>().highstagelevel.ToString("F0");
        }
        if (mydia)
        {
            mydiatext.text = "+ " + Diamond.GetComponent<Diamond>().earnedDiamondsThisRun.ToString("F0");
        }

    }
}
