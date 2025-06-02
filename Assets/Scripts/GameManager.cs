
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
    public GameObject Diamond;
    public GameObject Start;
    public GameObject InGame;
    public GameObject Gameover;
    public bool isGameOver = false;

    public void sstart()
    { //온 클릭 함수를 이용하여 게임 로딩 창을 닫고, 인게임을 킴
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
    public void StageClear()
    {
        // 예시: 스테이지 클리어 시
        Diamond.GetComponent<Diamond>().AddDiamondsForStageClear(stagelevel);
    }
    public void GameOver()
    {
        if (isGameOver) return;  // 중복 방지
        isGameOver = true;
        int highstagelevel = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", Mathf.Max(highstagelevel, stagelevel));
        Diamond.GetComponent<Diamond>().ShowRunResult();
        // 누적 다이아 수를 UI에 보여주고 싶다면:
        Gameover.SetActive(true);
        Time.timeScale = 0f;



    }
    public void StartDia()
    {
        Time.timeScale = 1f;
        Gameover.SetActive(false);
    }
    public void StartAD()
    {
        Time.timeScale = 1f;
        Gameover.SetActive(false);
    }
    public void MainExit()

    {
        Time.timeScale = 1f;
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


}
