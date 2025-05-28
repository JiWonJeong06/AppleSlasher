using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour



{
    public bool beststage;
    public Text stagetext;
    public GameObject gameManager;

    public void Start() {
        if (beststage)
        {
            stagetext.text = "Best Stage ";
        }
    }
    void Update()
    {

        if (gameManager.GetComponent<GameManager>().stagelevel % 5 == 0)
            stagetext.text = "Stage Boss";
        else
            stagetext.text = "Stage " + gameManager.GetComponent<GameManager>().stagelevel;
        
    }
}
