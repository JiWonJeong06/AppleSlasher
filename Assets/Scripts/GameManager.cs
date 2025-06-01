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

    public void sstart(){ //온 클릭 함수를 이용하여 게임 로딩 창을 닫고, 인게임을 킴
            Gamestart = true;
            Start.SetActive(false);
            InGame.SetActive(true);
        }


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
        float highstagelevel = PlayerPrefs.GetFloat("Score");
        PlayerPrefs.SetFloat("Score", Mathf.Max(highstagelevel, stagelevel));
    }

    public void GameExit(){
        Debug.Log("게임나가짐");
        Application.Quit();
}


}
