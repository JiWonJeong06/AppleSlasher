using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText;               // 게임 중 타이머 표시용
    public Text currentTimeText;         // 게임 오버 창의 현재 기록
    public Text bestTimeText;     
    public Text currentTimeText2;         
    public Text bestTimeText2;            
    public Text record;

    public Text record2;                 // 최고 기록 텍스트 ("New Record!!")

    public float currentTime = 0f;
    public float bestTime = 0f;
    public bool isRunning = true;



    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        record.text = "";
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            timerText.text = FormatTime(currentTime);
        }
    }
    public void StopTimer()
    {
        isRunning = false;

        if (currentTime > bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();

            bestTimeText.text = FormatTime(bestTime);
            currentTimeText.text = FormatTime(currentTime);
            bestTimeText2.text = FormatTime(bestTime);
            currentTimeText2.text = FormatTime(currentTime);
            record.text = "New\nRecord!!";
            record2.text = "New\nRecord!!";
        }
        else
        {
            bestTimeText.text = FormatTime(bestTime);
            currentTimeText.text = FormatTime(currentTime);
            bestTimeText2.text = FormatTime(bestTime);
            currentTimeText2.text = FormatTime(currentTime);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
