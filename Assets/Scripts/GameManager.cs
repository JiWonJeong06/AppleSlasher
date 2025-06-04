
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

    //UI 창
    public GameObject StoreUI;
    public GameObject SetUI;
    public GameObject HelpUI;

    public GameObject gamesound;
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
    

        Gameover.SetActive(true);
        highstagelevel = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", Mathf.Max(highstagelevel, stagelevel));
        Diamond.GetComponent<Diamond>().ShowRunResult();
        Time.timeScale = 0f;


    }
    public void StartDia() // 보석 쓰고 다시 시작하기
    {
        if (Diamond.GetComponent<Diamond>().Diamonds >= 400)
        {
            Debug.Log("400개 사용");
            gamesound.GetComponent<SoundManager>().Uitouch.Play();
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
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
        Gameover.SetActive(false);
        isGameOver = false;
        Time.timeScale = 1f;
        Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;


    }
    public void MainExit()

    {
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
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
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
        StoreUI.SetActive(true);
        Debug.Log("상점 열림!");
    }

    public void Settings()
    {
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
        SetUI.SetActive(true);
        Debug.Log("설정 열림!");
    }
    public void Helps()
    {
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
        HelpUI.SetActive(true);
        Debug.Log("도움말 열림!");
    }
    public void ExitUI()
    {
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
        StoreUI.SetActive(false);
        SetUI.SetActive(false);
        HelpUI.SetActive(false);
    }
  
}
