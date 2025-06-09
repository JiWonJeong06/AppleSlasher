using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class InterstitialAdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOSAdUnitId = "Interstitial_iOS";
    private string _adUnitId;
    [Header("Game Components")]
    public GameObject gamesound;
    public GameObject gamemanager;
    public GameObject Diamond;
    void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
    }

    public void LoadAd()
    {
        Advertisement.Load(_adUnitId, this);
        Debug.Log("Loading Interstitial Ad: " + _adUnitId);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
        Debug.Log("Showing Interstitial Ad: " + _adUnitId);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Interstitial Ad Loaded: " + adUnitId);
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Interstitial Ad Load Failed: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Interstitial Ad Show Failed: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Interstitial Ad Completed: {adUnitId} - {showCompletionState}");
        gamesound.GetComponent<SoundManager>().Uitouch.Play();
        Time.timeScale = 1f;
        gamemanager.GetComponent<GameManager>().isGameOver = false;
        Diamond.GetComponent<Diamond>().earnedDiamondsThisRun = 0;
        SceneManager.LoadScene(0);
    }
}
