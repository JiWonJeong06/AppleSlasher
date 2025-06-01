
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
            Start.SetActive(false);
            Main.SetActive(true);
        }
    
    public void mmain(){ //온 클릭 함수를 이용하여 게임 로딩 창을 닫고, 인게임을 킴
            Main.SetActive(false);
            InGame.SetActive(true);
        }
    void Awake()
        {
            if (!PlayerPrefs.HasKey("Score")) {
                PlayerPrefs.SetInt("Score", 0);
        }
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
        int highstagelevel = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", Mathf.Max(highstagelevel, stagelevel));
        Gameover.SetActive(true);
    }
    public void Restart()
    {
        Gameover.SetActive(false);
        SceneManager.LoadScene(0);
        Start.SetActive(false);
        InGame.SetActive(true);
    }
    public void GameExit(){
        Debug.Log("게임나가짐");
        Application.Quit();
}


}
