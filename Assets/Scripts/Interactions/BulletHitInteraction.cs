using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitInteraction : MonoBehaviour
{

    public float speed = 25;
    public float fireRate;

    void Start()
    {
        Destroy(gameObject, 6);
    }

    void Update()
    {
        if(speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Speed was uninstantiated");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.Equals(PlayerManager.instance.player))
        {
            Debug.Log("Projectile Collided");
            ScoreManager.RemoveFromScore();
            Destroy(gameObject);
        }
    }
}
