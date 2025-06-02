using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public int diamonds;              // 보유 다이아
    public int earnedDiamonds = 0;   // 이번 플레이 중 얻은 다이아
    public Text diaText;             // 다이아 UI 텍스트

    void Start()
    {
        diamonds = PlayerPrefs.GetInt("Diamonds", 0);
        UpdateUIDisplay();
    }

    void Update()
    {
        // 실시간 UI 표시
        UpdateUIDisplay();
    }

    void UpdateUIDisplay()
    {
        diaText.text = diamonds.ToString();
    }

    // 스테이지 클리어 시 호출
    public void AddDiamondsForStageClear(int stageLevel)
    {
        if (stageLevel % 5 == 0)
        {
            earnedDiamonds += 30;
            Debug.Log($"[다이아] 스테이지 {stageLevel} 클리어 → 30 다이아 적립 (총: {earnedDiamonds})");
        }
    }

    // 게임 오버 시 호출
    public void ApplyEarnedDiamonds()
    {
        diamonds += earnedDiamonds;
        earnedDiamonds = 0;
        PlayerPrefs.SetInt("Diamonds", diamonds);
        PlayerPrefs.Save();
        Debug.Log($"[다이아] 총 다이아: {diamonds} 저장 완료");
    }

    // 게임 오버 화면에서 표시할 때 사용
    public int GetEarnedDiamonds()
    {
        return earnedDiamonds;
    }
}
