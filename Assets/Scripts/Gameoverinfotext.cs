using UnityEngine;
using UnityEngine.UI;

public class Gameoverinfotext : MonoBehaviour
{

    public GameObject Diamond;

    public bool mystage;
    public bool mybeststage;
    public bool mysetdia;
    public bool mydia;

    Text mystagetext;

    Text mybeststagetext;
    Text mysetdiatext;
    Text mydiatext;
    void Start()
    {
        mystagetext = GetComponent<Text>();
        mybeststagetext = GetComponent<Text>();
        mysetdiatext = GetComponent<Text>();
        mydiatext = GetComponent<Text>();

    }

    void Update()
    {
        if (mystage)
        {
            mystagetext.text = "현재 스테이지: ";
        }
        if (mybeststage)
        {
            mybeststagetext.text = "최고 스테이지: " ;
        }
        if (mydia)
        {
            mydiatext.text = "획득 다이아: +" + Diamond.GetComponent<Diamond>().earnedDiamondsThisRun.ToString("F0");
        }
        if (mysetdia)
        {
            mysetdiatext.text = "보유한 다이아: "+ Diamond.GetComponent<Diamond>().Diamonds.ToString("F0");
        }
    }
}
