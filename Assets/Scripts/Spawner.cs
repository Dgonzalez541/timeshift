using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pickups;
    public Vector3 spawnValuesX;

    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randPickup;

    void Start()
    {
      StartCoroutine(waitSpawner());
    }


    void Update()
    {
      spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
      yield return new WaitForSeconds(startWait);

      while(!stop)
      {
        //Does not include 3
        randPickup = Random.Range(0,2);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesX.x, spawnValuesX.x), 1, Random.Range(-spawnValuesX.z, spawnValuesX.z));
        Instantiate(pickups[randPickup], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
        yield return new WaitForSeconds(spawnWait);
      }
    }
}
