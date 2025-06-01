using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    public Text stagetext;
    public Text best_stagetext;
    public GameObject gameManager;
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().GameStart)
            return;
        
        if (int.Parse(best_stagetext.text.Split(' ')[2]) <= gameManager.GetComponent<GameManager>().stagelevel)
        {

            best_stagetext.text = "Best Stage " + gameManager.GetComponent<GameManager>().stagelevel;
        }
        if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
        {
            stagetext.text = "Stage Boss";
        }
        else
        {
            stagetext.text = "Stage " + gameManager.GetComponent<GameManager>().stagelevel;
        }
            
    }
}
