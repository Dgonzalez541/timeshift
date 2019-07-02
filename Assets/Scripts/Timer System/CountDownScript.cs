using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
  [SerializeField] private Text realUiText;
  [SerializeField] private float realMainTimer;

  [SerializeField] private Text scaledUiText;
  [SerializeField] private float scaledMainTimer;

  private float realTimer;
  private bool realCanCount = true;
  private bool realDoOnce = false;

  private float scaledTimer;
  private bool scaledCanCount = true;
  private bool scaledDoOnce = false;

  private float scaledSeconds;
  private float scaledMiliseconds;
  void Start()
  {
    realTimer = realMainTimer;
    scaledTimer = scaledMainTimer;
  }

  void Update()
  {
    //Real Timer
    if(realTimer > 0.0f && realCanCount)
    {
      realTimer -= Time.deltaTime;

      realUiText.text = realTimer.ToString("F");
    }
    else if(realTimer <= 0.0f && !realDoOnce)
    {
      realCanCount = false;
      realDoOnce = true;
      realUiText.text = "0.00";
      realTimer = 0.0f;
    }

    //Scalled Timerf
    if(scaledTimer > 0.0f && scaledCanCount)
    {
      scaledTimer -= Time.deltaTime * TimeManager.timeFactor;
      scaledUiText.text = scaledTimer.ToString("F");
    }
    else if(scaledTimer <= 0.0f && !scaledDoOnce)
    {
      scaledCanCount = false;
      scaledDoOnce = true;
      scaledUiText.text = "0.00";
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      scaledTimer = 0.0f;
      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }//end Update

}
