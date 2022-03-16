using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdInter : MonoBehaviour
{
    public string adUnitId = "ca-app-pub-3940256099942544/1033173712";
    private InterstitialAd interstitial;

    public ChangeGravity mainComponent;

    // Use this for initialization
    private void Start()
    {
        int i = PlayerPrefs.GetInt("inter", 0);
        if (i >= 4)
        {
            RequestInterstitial();
            PlayerPrefs.SetInt("inter", 0);
        }
        else
        {
            PlayerPrefs.SetInt("inter", i + 1);
        }
    }
    public void loadInter()
    {
        if (interstitial != null)
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        }
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .Build();
    }

    private void RequestInterstitial()
    {
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
    }

    #endregion
}
