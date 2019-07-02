using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator playerAnimator;
    public GameObject player;

    void Start()
    {
      playerAnimator = player.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      //Debug.Log(player.GetComponent<JoyStickMovement>().speed);
      playerAnimator.SetBool("Moving", JoyStickMovement.isMoving);
    }
}
