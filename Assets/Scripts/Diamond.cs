using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public int Diamonds; // 총 보유 다이아
    private int earnedDiamondsThisRun = 0; // 이번 게임에서 획득한 다이아

    public Text Dia_Text; // UI 텍스트
    void Start()
    {
        Diamonds = PlayerPrefs.GetInt("Diamonds", 0);
        Dia_Text.text = Diamonds.ToString();
    }

    void Update()
    {
        Diamonds = PlayerPrefs.GetInt("Diamonds", 0);
        Dia_Text.text = Diamonds.ToString();
    }

    public void AddDiamondsForStageClear(int stageLevel)
    {
        if (stageLevel % 5 == 0 )
        {
            earnedDiamondsThisRun += 30;
            Debug.Log($"[다이아] 스테이지 {stageLevel} 클리어 → 30 다이아 적립 (총: {earnedDiamondsThisRun})");
        }
    }

    // 게임 오버 시 호출
    public void ShowRunResult()
    {
        Debug.Log($"[다이아] 이번 플레이로 획득한 다이아: {earnedDiamondsThisRun}");

        Diamonds += earnedDiamondsThisRun;
        PlayerPrefs.SetInt("Diamonds", Diamonds);
        PlayerPrefs.Save();

        Debug.Log($"[다이아] 총 다이아: {Diamonds} 저장 완료");

        earnedDiamondsThisRun = 0;
    }
}
