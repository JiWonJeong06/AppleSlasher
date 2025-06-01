using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    Text stagetext;
    public bool BestStage;
    public float BestStagelevel;
    public GameObject gameManager;

    void Start()
    {
        stagetext = GetComponent<Text>();
        if (BestStage)
        {
            BestStagelevel = PlayerPrefs.GetInt("Score");
            stagetext.text = "Best Stage " + BestStagelevel.ToString("F0");
        }
    }
    void Update()
    {
        if (BestStage && gameManager.GetComponent<GameManager>().stagelevel < BestStagelevel)
            return;


        if (BestStage)
        {
            stagetext.text = "최고 기록 달성!";
        }
        else if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
        {
            stagetext.text = "Stage Boss";
        }
        else
        {
            stagetext.text = "Stage " + gameManager.GetComponent<GameManager>().stagelevel;
        }
            
    }
}
