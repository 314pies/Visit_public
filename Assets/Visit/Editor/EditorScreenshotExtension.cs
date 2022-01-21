#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

public class ScreenshotGrabber
{
    [MenuItem("Screenshot/Grab")]
    public static void Grab()
    {
        ScreenCapture.CaptureScreenshot(UnityEngine.Random.Range(0,999999999) + ".png", 4);
    }
}
#endif