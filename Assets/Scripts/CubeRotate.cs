using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour
{
    public float speed = 50;


    void Update ()
    {
        transform.Rotate((Vector3.up + Vector3.forward).normalized, speed * Time.deltaTime);
    }
}
