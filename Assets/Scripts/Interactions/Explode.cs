using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private ParticleSystem ps;
     public bool moduleEnabled;
    // Start is called before the first frame update
    void Start()
    {
      ps = GetComponent<ParticleSystem>();
    }

    void Update(){
      var emission = ps.emission;
      emission.enabled = moduleEnabled;
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            moduleEnabled = true;
        }
    }
}
