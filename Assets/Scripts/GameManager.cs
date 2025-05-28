using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int stagelevel = 1;

    public static GameObject gameoverui;

    public Slider slider;

    public GameObject Apple_Spawner;
    public GameObject Pin_Spawner;

    public GameObject Main;
    public GameObject Start;
    public GameObject InGame;
    public GameObject Gameover;

    public bool GameStart;
    void Update()
    {
        if (stagelevel % 5 == 0)
        {
            slider.value = Apple_Spawner.GetComponent<Apple_Spawner>().Current_Hp / Apple_Spawner.GetComponent<Apple_Spawner>().Boss_Hp;
        } 
        else
            slider.value = Apple_Spawner.GetComponent<Apple_Spawner>().Current_Hp / Apple_Spawner.GetComponent<Apple_Spawner>().Max_Hp;

    }
    public void GameOver()
    {
    
    }
    void GameOverUI()
    {
        
    }




}
