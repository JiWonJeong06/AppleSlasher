using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;
public class AttendanceSystem : MonoBehaviour
{
    [Header("UI")]
    public Button claimButton;
    public Text buttonText;

    [Header("보상 설정")]
    public int dailyReward = 300;

    private const string LastClaimKey = "LastAttendanceDate";

    public GameObject Gamemanager;


    void Start()
    {
        UpdateUI();
        claimButton.onClick.AddListener(OnClickClaim);
    }
    /*void Update()
{
    // 키보드에서 R 키를 누르면 날짜 초기화 (에디터에서만 동작)
    if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
    {
        PlayerPrefs.DeleteKey("LastAttendanceDate");
        Debug.Log("🧹 출석 날짜 초기화됨 (테스트용)");
        UpdateUI();
    }
}*/

    void OnClickClaim()
    {
        if (CanClaimToday())
        {
            GiveDiamonds(dailyReward);
            SaveTodayAsClaimed();
            Debug.Log($"✅ 출석 보상 지급 완료! 다이아 +{dailyReward}");
        }
        else
        {
            Debug.Log("⚠️ 오늘은 이미 출석 보상을 받았습니다.");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (CanClaimToday())
        {
            Gamemanager.GetComponent<GameManager>().Checking.SetActive(true);
            claimButton.interactable = true;
            buttonText.text = "받기";
        }
        else
        {

            claimButton.interactable = false;
            buttonText.text = "수령 완료";
        }
    }

    bool CanClaimToday()
    {
        DateTime today = GetKoreanToday();
        DateTime? lastClaim = GetLastClaimedDate();
        return lastClaim == null || lastClaim.Value.Date < today;
    }

    // ✅ 한국 시각 = UTC + 9 시간
    DateTime GetKoreanToday()
    {
        return DateTime.UtcNow.AddHours(9).Date;
    }

    DateTime? GetLastClaimedDate()
    {
        if (PlayerPrefs.HasKey(LastClaimKey))
        {
            string saved = PlayerPrefs.GetString(LastClaimKey);
            if (DateTime.TryParse(saved, out DateTime date))
                return date;
        }
        return null;
    }

    void SaveTodayAsClaimed()
    {
        string dateString = GetKoreanToday().ToString("yyyy-MM-dd");
        PlayerPrefs.SetString(LastClaimKey, dateString);
        PlayerPrefs.Save();
    }

    void GiveDiamonds(int amount)
    {
        // 실제 다이아 지급 처리
        Debug.Log($"💎 다이아 {amount}개 지급 (예시)");
        // 예시: DiamondManager.Instance.AddDiamonds(amount);
    }
}
