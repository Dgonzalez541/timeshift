using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterCreation : MonoBehaviour
{
    public float timeToDestroySelf = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroySelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
