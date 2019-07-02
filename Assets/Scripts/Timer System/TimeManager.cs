using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public enum TimeState{Slow,Normal,Fast};

    // Time factors
    public static float timeFactor = 1.0f;

    public static float slowDownLength = 2f;

    public static float fastTimeLength = 2f;

    public static TimeState timeSpeed = TimeState.Normal;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1.5f);
    }

    public static void StartSlowTime()
    {
        timeFactor = 0.25f;
        Time.timeScale += (1.0f / timeFactor) * Time.unscaledDeltaTime;
        Time.timeScale = timeFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        timeSpeed = TimeState.Slow;
    }

    public static void StartNormalTime()
    {
      timeFactor = 1.0f;
      Time.timeScale += (1.0f / timeFactor) * Time.unscaledDeltaTime;
      Time.timeScale = timeFactor;
      Time.fixedDeltaTime = Time.timeScale * .02f;
      timeSpeed = TimeState.Normal;
    }

    public static void StartFastTime()
    {
      timeFactor = 4f;
      Time.timeScale += (1.0f / timeFactor) * Time.unscaledDeltaTime;
      Time.timeScale = timeFactor;
      Time.fixedDeltaTime = Time.timeScale * .02f;
      timeSpeed = TimeState.Fast;
    }
}
