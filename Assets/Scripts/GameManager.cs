using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//게임 매니저저
public class GameManager : MonoBehaviour
{
    public int stagelevel = 1;
    public Slider slider;
    public GameObject Apple_Spawner;
    public GameObject Pin_Spawner;
    public GameObject Main;
    public GameObject Start;
    public GameObject InGame;
    public GameObject Gameover;
    public bool Gamestart; 

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
        Gameover.SetActive(true);
    }




}
