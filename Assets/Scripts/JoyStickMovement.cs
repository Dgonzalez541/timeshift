using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMovement : MonoBehaviour
{
    Animator playerAnimator;
    public float speed = 10.0f;
    public static bool isMoving = false;
    public static bool slowTime = false;
    public static bool fastTime = false;

    private GameObject mesh;
    private Renderer rend;
    public Material playerColorSlow;
    public Material playerColorNormal;
    public Material playerColorFast;

    void Start()
    {
      mesh = GameObject.Find("Mesh_Karate");
      mesh.GetComponent<Renderer>().material = playerColorNormal;
      TimeManager.StartNormalTime();
    }

    void Update()
    {

        float vertical = Input.GetAxis("Vertical") * speed;
        float horizontal = Input.GetAxis("Horizontal") * speed;

        vertical *= Time.unscaledDeltaTime;
        horizontal *= Time.unscaledDeltaTime;

        transform.Translate(horizontal,0,vertical);

        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
          isMoving = true;
        }
        else
        {
          isMoving = false;
        }

        //Time Controls
        //Slow Time
        if (Input.GetButton("LeftBumper") || Input.GetMouseButton(0))
        {
          if(ResourceBarController.currentSlow != 0)
          {
            mesh.GetComponent<Renderer>().material = playerColorSlow;
            TimeManager.StartSlowTime();
          }else
          {
            mesh.GetComponent<Renderer>().material = playerColorNormal;
            TimeManager.StartNormalTime();
          }
        }else if(Input.GetButton("RightBumper") || Input.GetMouseButton(1))
        {
          if(ResourceBarController.currentFast != 0)
          {
            mesh.GetComponent<Renderer>().material = playerColorFast;
            TimeManager.StartFastTime();
          }else
          {
            mesh.GetComponent<Renderer>().material = playerColorNormal;
            TimeManager.StartNormalTime();
          }
        }else
        {
          mesh.GetComponent<Renderer>().material = playerColorNormal;
          TimeManager.StartNormalTime();
        }//End Fast Time
    }//End Update
}//End class
