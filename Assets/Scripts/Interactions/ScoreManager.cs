using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int playerScore;
    public GameObject timeController;
    public float scoreFactor; // This is just a conceptual placeholder. We will want to multiply score gain by score factor based on the current state of time.

    void Awake()
    {
        playerScore = 0;
    }


    public static void RemoveFromScore()
    {
        if(playerScore - 2 >= 0)
        {
            playerScore -= 2;
        }
        
    }

    // This changes the score based on the current timescale and the resource that was just collected.
    public static void AddToScore()
    {
        switch(TimeManager.timeSpeed)
        {
            case TimeManager.TimeState.Slow:
                playerScore += 1;
                break;
            case TimeManager.TimeState.Normal:
                playerScore += 2;
                break;
            case TimeManager.TimeState.Fast:
                playerScore += 4;
                break;
            default:
                break;
        }
    }

}
