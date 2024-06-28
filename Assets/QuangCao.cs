using System;
using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class QuangCao : PersistentSingleton<QuangCao>
{
    public void Start()
    {
        // _bannerView.Show();
    }


    public bool IsAdAvailable => false;

    public void LoadAd()
    {
    }


    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
    }

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowAd(Action action)
    {
    }


    /// <summary>
    /// Creates a 320x50 banner at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
    }

    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void LoadBanner()
    {
    }

    /// <summary>
    /// listen to events the banner may raise.
    /// </summary>
    private void ListenToAdEvents()
    {
    }

    public void ShowRewardedAd()
    {
    }

    public bool GetRewardAvailable()
    {
        return false;
    }

    public void PhatQuangCao(Action action = null)
    {
        ShowAd(action);
    }

    public void PhatQuangCaoInter()
    {
        ShowAd(null);
    }

    public void ShowAdIfAvailable()
    {
    }
}