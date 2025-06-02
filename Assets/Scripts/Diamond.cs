using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    
    public int Diamonds; // 총 보유 다이아
    public int earnedDiamondsThisRun; // 이번 게임에서 획득한 다이아

    public Text Titletext;

    public Text InGametext;

    void Start()
    {
        Diamonds = PlayerPrefs.GetInt("Diamonds", 0);

    }

    void Update()
    {
      
        Titletext.text = Diamonds.ToString("F0");
        InGametext.text = Diamonds.ToString("F0");
    }
    
    public void AddDiamondsForStageClear(int stageLevel)
    {
        if (stageLevel % 5 == 0)
        {
            earnedDiamondsThisRun += 30;
            Debug.Log($"[다이아] 스테이지 {stageLevel} 클리어 → 30 다이아 적립 (총: {earnedDiamondsThisRun})");

        }
    }
    // 게임 오버 시 호출
    public void ShowRunResult()
    {
        Diamonds += earnedDiamondsThisRun;
        PlayerPrefs.SetInt("Diamonds", Diamonds);
        PlayerPrefs.Save();
        Debug.Log($"[다이아] 총 다이아: {Diamonds}에  {earnedDiamondsThisRun} 만큼 저장 완료");
       
    }
}
