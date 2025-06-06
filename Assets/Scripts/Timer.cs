using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;               // 게임 중 타이머 표시용

    public Text currentTimeText;         // 게임 오버 창의 현재 기록
    public Text bestTimeText;            // 게임 오버 창의 최고 기록

    public float currentTime = 0f;
    public float bestTime = 0f;
    public bool isRunning = true;

    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

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
        }
        else
            bestTimeText.text = FormatTime(bestTime);
            currentTimeText.text = FormatTime(currentTime);

    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
