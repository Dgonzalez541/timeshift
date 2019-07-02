using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBarController : MonoBehaviour
{
    public float startingFast = 50;
    public float startingSlow = 50;

    public static float currentFast;
    public static float currentSlow;

    public static float maxFast = 100;
    public static float maxSlow = 100;

    public static float minFast = 0;
    public static float minSlow = 0;

    public Slider fastBar;
    public Slider slowBar;

    public float decreaseSpeedRate = 0.8f;
    public static float increaseAmount = 20f;

    void Start()
    {
      currentFast = startingFast;
      currentSlow = startingSlow;

      fastBar.value = currentFast;
      slowBar.value = currentSlow;
    }
    // Update is called once per frame
    void Update()
    {
      if(currentFast > maxFast)
      {
        currentFast = maxFast;
      }
      if(currentSlow > maxSlow)
      {
        currentSlow = maxSlow;
      }

      fastBar.value = currentFast;
      slowBar.value = currentSlow;
      //Fast Time
      if(TimeManager.timeSpeed == TimeManager.TimeState.Fast)
      {

        currentFast = currentFast - decreaseSpeedRate ;
        fastBar.value = currentFast;
        if(currentFast <= 0)
        {
          TimeManager.StartNormalTime();
        }
      }

        //Slow Time
        if(TimeManager.timeSpeed == TimeManager.TimeState.Slow)
        {
          //currentFast -= Time.deltaTime * decreaseSpeedRate;
          currentSlow = currentSlow - decreaseSpeedRate;
          slowBar.value = currentSlow;
          if(currentSlow <= 0)
          {
            TimeManager.StartNormalTime();
          }
        }//End slow check
    }//End Update

    public static void increaseFast()
    {
      currentFast += increaseAmount;
    }

    public static void increaseSlow()
    {
      currentSlow += increaseAmount;
    }


}//End class
