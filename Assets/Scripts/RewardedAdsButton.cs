using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";

    [Header("Game Components")]
    public GameObject gamesound;
    public GameObject Timer;
    public GameObject gamemanager;
    public GameObject Pin_Spawner;
    public GameObject Diamond;

    string _adUnitId;

    void Awake()
    {
        #if UNITY_IOS
            _adUnitId = _iOSAdUnitId;
        #elif UNITY_ANDROID
            _adUnitId = _androidAdUnitId;
        #else
            Debug.LogWarning("Unsupported platform for Ads");
        #endif
    }

    public void LoadAd()
    {
        Advertisement.Load(_adUnitId, this);
        Debug.Log("Loading Rewarded Ad: " + _adUnitId);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
        Debug.Log("Showing Rewarded Ad: " + _adUnitId);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        if (adUnitId.Equals(_adUnitId))
        {
            _showAdButton.onClick.AddListener(ShowAd);
            Debug.Log("Rewarded Ad Loaded");
        }
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Reward Completed");

            // 리워드 처리
            gamesound.GetComponent<SoundManager>().Uitouch.Play();
            Timer.GetComponent<Timer>().isRunning = true;
            gamemanager.GetComponent<GameManager>().Gameover.SetActive(false);
            gamemanager.GetComponent<GameManager>().isGameOver = false;
            Time.timeScale = 1f;
            Pin_Spawner.GetComponent<PinSpawner>().enablepin = true;
            Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;
            gamemanager.GetComponent<GameManager>().stackGameover = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Rewarded Ad Load Failed: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Rewarded Ad Show Failed: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        _showAdButton.onClick.RemoveAllListeners();
    }
}
