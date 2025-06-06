using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[System.Serializable]
public class RankData
{
    public string playerName;
    public int stage;
    public float time;

    public RankData(string name, int stage, float time)
    {
        this.playerName = name;
        this.stage = stage;
        this.time = time;
    }
}

public class Rank : MonoBehaviour
{
    public GameManager gameManager;       // GameManager 연결
    public Timer timer;                   // Timer 연결
    public Transform rankContent;         // ScrollView -> Content 오브젝트
    public GameObject rankItemPrefab;     // 랭킹 하나를 표시할 프리팹 (Text 포함)

    public List<RankData> rankList = new List<RankData>();
    private const int MaxRankCount = 10;

    void Start()
    {
        LoadRank();
    }

    public void AddCurrentRank(string playerName = "Player")
    {
        int stage = gameManager.stagelevel;
        float time = timer.currentTime;

        RankData newEntry = new RankData(playerName, stage, time);
        rankList.Add(newEntry);
        SortRanks();

        if (rankList.Count > MaxRankCount)
            rankList.RemoveAt(rankList.Count - 1);

        SaveRank();
    }

    public void UpdateRankUI()
    {
        // 기존 목록 제거
        foreach (Transform child in rankContent)
        {
            Destroy(child.gameObject);
        }

        // 정렬된 랭크 리스트 출력
        for (int i = 0; i < rankList.Count; i++)
        {
            GameObject item = Instantiate(rankItemPrefab, rankContent);
            Text text = item.GetComponent<Text>();

            TimeSpan t = TimeSpan.FromSeconds(rankList[i].time);
            string timeStr = $"{t.Minutes:00}:{t.Seconds:00}";

            text.text = $"{i + 1}. {rankList[i].playerName} - Stage {rankList[i].stage} - Time {timeStr}";
        }
    }

    private void SortRanks()
    {
        rankList.Sort((a, b) =>
        {
            if (b.stage != a.stage)
                return b.stage.CompareTo(a.stage);     // 높은 stage 우선
            else
                return a.time.CompareTo(b.time);       // 짧은 시간 우선
        });
    }

    private void SaveRank()
    {
        for (int i = 0; i < rankList.Count; i++)
        {
            PlayerPrefs.SetString($"Rank_Name_{i}", rankList[i].playerName);
            PlayerPrefs.SetInt($"Rank_Stage_{i}", rankList[i].stage);
            PlayerPrefs.SetFloat($"Rank_Time_{i}", rankList[i].time);
        }
        PlayerPrefs.SetInt("Rank_Count", rankList.Count);
        PlayerPrefs.Save();
    }

    private void LoadRank()
    {
        rankList.Clear();
        int count = PlayerPrefs.GetInt("Rank_Count", 0);

        for (int i = 0; i < count; i++)
        {
            string name = PlayerPrefs.GetString($"Rank_Name_{i}", "Player");
            int stage = PlayerPrefs.GetInt($"Rank_Stage_{i}", 0);
            float time = PlayerPrefs.GetFloat($"Rank_Time_{i}", 0f);
            rankList.Add(new RankData(name, stage, time));
        }

        SortRanks();
    }
}
