using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class PlayAdScript : MonoBehaviour {

    private static float lastTime = 0f;

    public static void ShowAd()
    {
        if (Advertisement.IsReady() && ( Time.time - lastTime) >= 60)
        {
            Advertisement.Show("video", new ShowOptions() {resultCallback = HandleAdResult });
            lastTime = Time.time;
        }
    }

    private static void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                Debug.Log("Ad was watched");
                break;
            default:
                break;
        }
    }
}
