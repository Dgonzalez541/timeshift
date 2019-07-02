using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectResource : MonoBehaviour
{

  public GameObject creditPS;
  public GameObject slowPS;
  public GameObject fastPS;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SlowResourceNode")
        {
            ResourceBarController.increaseSlow();
            GameObject slowExplosion = Instantiate(slowPS, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "FastResourceNode")
        {
          ResourceBarController.increaseFast();
          GameObject fastExplosion = Instantiate(fastPS, collision.gameObject.transform.position,  Quaternion.identity);
          Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Credits")
        {
          ScoreManager.AddToScore();
          GameObject creditExplosion = Instantiate(creditPS, collision.gameObject.transform.position, Quaternion.identity);
          Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Projectile")
        {

            Destroy(collision.gameObject);
        }
    }
}
