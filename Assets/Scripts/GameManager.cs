
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//게임 매니저저
public class GameManager : MonoBehaviour
{
    public int stagelevel = 1;
    public int highstagelevel;

    public Slider slider;
    public GameObject Apple_Spawner;
    public GameObject Pin_Spawner;
    public GameObject Diamond;
    public GameObject Start;
    public GameObject InGame;
    public GameObject Gameover;
    public bool isGameOver = false;

    

    public void Sstart()
    {                           //온 클릭 함수를 이용하여 게임 로딩 창을 닫고, 인게임을 킴
        Start.SetActive(false);
        InGame.SetActive(true);
    }


    void Awake()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
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
        if (isGameOver) return;  // 중복 방지
        isGameOver = true;
        Gameover.SetActive(true);
        highstagelevel = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", Mathf.Max(highstagelevel, stagelevel));
        Pin_Spawner.GetComponent<PinSpawner>().enablepin = false;
        Diamond.GetComponent<Diamond>().ShowRunResult();
        Time.timeScale = 0f;
        

    }
    public void StartDia() // 보석 쓰고 다시 시작하기
    {
        if (Diamond.GetComponent<Diamond>().Diamonds >= 400)
        {
            Debug.Log("400개 사용");
            Diamond.GetComponent<Diamond>().Diamonds -= 400;
            Gameover.SetActive(false);
            isGameOver = false;
            Time.timeScale = 1f;
            Pin_Spawner.GetComponent<PinSpawner>().enablepin = true;
            Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;
      
        }
        else
        {
            Debug.Log("400개 이상 있지 않아 사용 불가");
        }
    }
    public void StartAD() //광고 보고 다시 시작하기
    {
        Gameover.SetActive(false);
        isGameOver = false;
        Time.timeScale = 1f;
         Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;
      

    }
    public void MainExit()

    {
        Time.timeScale = 1f;
        isGameOver = false;
         Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;
        SceneManager.LoadScene(0);
    
    }

    public void GameExit()
    {
        Debug.Log("게임나가짐");
        Application.Quit();
    }



    public void Shop()
    {
        Debug.Log("상점 열림!");
    }

    public void Settings()
    {
        Debug.Log("설정 열림!");
    }
        public void Helps()
    {
        Debug.Log("도움말 열림!");
    }
  
}
