using UnityEngine;
using System.Collections;

 public class Facing : MonoBehaviour {

     public float speed = 2.0f;
     private Quaternion qTo;
     public GameObject player;

     void Start() {

         qTo = player.transform.rotation;
     }

     void Update () {
         Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

         if (direction != Vector3.zero)
             qTo = Quaternion.LookRotation (direction);

         player.transform.rotation = Quaternion.Slerp (player.transform.rotation, qTo, Time.unscaledDeltaTime * speed);
     }
 }
