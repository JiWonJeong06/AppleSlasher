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
       
            
            stagetext.text = "Stage " + gameManager.GetComponent<GameManager>().stagelevel;
        
    }
}
