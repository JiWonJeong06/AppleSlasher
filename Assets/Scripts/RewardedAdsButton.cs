using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null;



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
        LoadAd();
        Debug.Log("Showing Rewarded Ad: " + _adUnitId);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        if (adUnitId.Equals(_adUnitId))
        {

            Debug.Log("Rewarded Ad Loaded");
        }
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Reward Completed");
            LoadAd();

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

    }
}
