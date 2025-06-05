using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;        // 현재 시간 표시용 Text
    public Text gameovertimerText;
    public Text bestTimeText;     // 최고 기록 표시용 Text
    private float currentTime = 0f;
    private float bestTime = 0f;

    void Start()
    {
       
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        UpdateBestTimeUI();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimerUI();
                // 최고 기록 갱신
        if (currentTime > bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.Save();
            UpdateBestTimeUI();
        }
    }

    private void UpdateTimerUI()

    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
        gameovertimerText.text = $"{minutes:00}:{seconds:00}";
       
    }

    private void UpdateBestTimeUI()
    {
        int minutes = Mathf.FloorToInt(bestTime / 60f);
        int seconds = Mathf.FloorToInt(bestTime % 60f);
        bestTimeText.text =  $"{minutes:00}:{seconds:00}";
    }
}