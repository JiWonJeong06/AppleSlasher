using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.IO;

public class Showads : MonoBehaviour
{
    public string[] adFileNames = { "ad1.mp4", "ad2.mp4", "ad3.mp4" }; // 영상 파일 이름들
    public VideoPlayer videoPlayer;
    public GameObject gamesound;
    public GameObject Diamond;
    public GameObject gamemanaer;
    public GameObject Pin_Spawner;
    public GameObject Timer;

    void Awake()
    {
        PlayRandomAd();
        videoPlayer.loopPointReached += OnVideoFinished;
    }


    void PlayRandomAd()
    {
        if (adFileNames.Length == 0)
        {
            Debug.LogWarning("광고 영상이 없습니다.");
            gameObject.SetActive(false);
            return;
        }

        int randomIndex = Random.Range(0, adFileNames.Length);
        string fileName = adFileNames[randomIndex];


        videoPlayer.url = Application.streamingAssetsPath + "/Ads/" + fileName;

       videoPlayer.Play();;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        gameObject.SetActive(false);
        gamesound.GetComponent<SoundManager>().BGM.mute = false;
        Timer.GetComponent<Timer>().isRunning = true;
        gamemanaer.GetComponent<GameManager>().Gameover.SetActive(false);
        gamemanaer.GetComponent<GameManager>().isGameOver = false;
        Time.timeScale = 1f;
        Pin_Spawner.GetComponent<PinSpawner>().enablepin = true;
        Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;
        gamemanaer.GetComponent<GameManager>().stackGameover = true;
    }
}
