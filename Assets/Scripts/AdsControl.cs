﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class AdsControl : MonoBehaviour
{


    protected AdsControl()
    {
    }

    private static AdsControl _instance;
    InterstitialAd interstitial;
    RewardBasedVideoAd rewardBasedVideo;
    BannerView bannerView;
    ShowOptions options;
    public string AdmobID_Android, AdmobID_IOS, BannerID_Android, BannerID_IOS;
    public string UnityID_Android, UnityID_IOS, UnityZoneID;

    public static AdsControl Instance { get { return _instance; } }

    void Awake()
    {
        if (FindObjectsOfType(typeof(AdsControl)).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        MakeNewInterstial();
        RequestBanner();
        if (PlayerPrefs.GetInt("RemoveAds") == 0)
            ShowBanner();
        else
            HideBanner();
        if (Advertisement.isSupported)
        { // If the platform is supported,
#if UNITY_IOS
			Advertisement.Initialize (UnityID_IOS); // initialize Unity Ads.
#endif

#if UNITY_ANDROID
            Advertisement.Initialize(UnityID_Android); // initialize Unity Ads.
#endif
        }
        options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        DontDestroyOnLoad(gameObject); //Already done by CBManager


    }


    public void HandleInterstialAdClosed(object sender, EventArgs args)
    {

        if (interstitial != null)
            interstitial.Destroy();
        MakeNewInterstial();



    }

    void MakeNewInterstial()
    {


#if UNITY_ANDROID
        interstitial = new InterstitialAd(AdmobID_Android);
#endif
#if UNITY_IPHONE
		interstitial = new InterstitialAd (AdmobID_IOS);
#endif
        interstitial.OnAdClosed += HandleInterstialAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);


    }


    public void showAds()
    {
        int adsCounter = PlayerPrefs.GetInt("AdsCounter");

        if (adsCounter >= 2)
        {
            if (PlayerPrefs.GetInt("RemoveAds") == 0)
            {
                if (interstitial.IsLoaded())
                    interstitial.Show();
                else
                    if (Advertisement.IsReady())

                    Advertisement.Show();  
            }
            adsCounter = 0;
        }
        else
        {
            adsCounter++;
        }

        PlayerPrefs.SetInt("AdsCounter", adsCounter);
    }


    public bool GetRewardAvailable()
    {
        bool avaiable = false;
        avaiable = Advertisement.IsReady();
        return avaiable;
    }

    public void ShowRewardVideo()
    {

        Advertisement.Show(UnityZoneID, options);


    }


    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
		string adUnitId = BannerID_Android;
#elif UNITY_IPHONE
		string adUnitId = BannerID_IOS;
#else
		string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }



    public void ShowFB()
    {
        Application.OpenURL("https://www.facebook.com/PonyStudio2507/?ref=settings");
    }

    public void RateMyGame()
    {
#if UNITY_EDITOR
        Application.OpenURL("https://itunes.apple.com/us/app/color-flow-puzzle/id1436566275?ls=1&mt=8");
#elif UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ponygames.MagicBlockPuzzle");
#elif UNITY_IPHONE
        Application.OpenURL("https://itunes.apple.com/us/app/color-flow-puzzle/id1436566275?ls=1&mt=8");
#else
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ponygames.MagicBlockPuzzle");
#endif


    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
        
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }

    public void PlayCallbackRewardVideo(Action<ShowResult> _action)
    {
        ShowOptions _options = new ShowOptions();
        _options.resultCallback = _action;
        Advertisement.Show(UnityZoneID, _options);
    }

   public void PlayDelegateRewardVideo(Action<bool> onVideoPlayed)
    {
      
        if (Advertisement.IsReady(UnityZoneID))
        {
            Advertisement.Show(UnityZoneID, new ShowOptions
            {
                //pause = true,
                resultCallback = result => {
                    switch (result)
                    {
                        case (ShowResult.Finished):
                            onVideoPlayed(true);
                            break;
                        case (ShowResult.Failed):
                            onVideoPlayed(false);
                            break;
                        case (ShowResult.Skipped):
                            onVideoPlayed(false);
                            break;
                    }
                }
            });
        }
        onVideoPlayed(false);
    }
}

