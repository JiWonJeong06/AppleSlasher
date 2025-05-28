using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour


{
    public Text stagetext;
    public GameObject gameManager;
    void Start() {

    }
    void Update()
    {

        if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
            stagetext.text = "Stage Boss";
        else
            stagetext.text = "Stage " + gameManager.GetComponent<GameManager>().stagelevel;
        
    }
}
