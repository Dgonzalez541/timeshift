using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AssaultDroneAI : MonoBehaviour
{

    public float detectionRadius = 10f;
    public float obstacleRange = 10f;

    public float burstLength = 1f;
    public float timeBetweenBursts = 0.5f;
    private float timeSinceBurstStart;
    private float timeSinceLastBurst;
    private bool waitToFire = false;
    
    public float fireRate = 0.001f; // Make sure it doesn't spam projectiles.
    private float timeLastFired;
    public AudioSource shootSound;

    public List<GameObject> projectiles;


    public GameObject leftGun;
    public GameObject rightGun;

    Transform target;
    NavMeshAgent agent;

    private GameObject projectileToSpawn;
    private GameObject firePoint;
    private bool targetAcquired = false;

    // Start is called before the first frame update
    void Start()
    {
        timeLastFired = fireRate;
        timeSinceLastBurst = timeBetweenBursts;

        firePoint = rightGun;
        projectileToSpawn = projectiles[0];
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= detectionRadius)
        {
            agent.SetDestination(target.position);
            if(waitToFire)
            {
                if(Time.time - timeSinceLastBurst >= timeBetweenBursts)
                {
                    waitToFire = false;
                    timeSinceBurstStart = Time.time;
                }
            }

            if(!waitToFire)
            {
                if(Time.time - timeSinceBurstStart >= burstLength)
                {
                    waitToFire = true; 
                }
            }
                // Player in range. Scan for target to shoot at.
            Ray scanForTarget = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.Log("Scanning for target");

            Debug.Log("Time since last shot: " + (Time.time - timeLastFired));

            if (Physics.SphereCast(scanForTarget, 0.75f, out hit) && !(waitToFire))
            {

                GameObject hitObject = hit.transform.gameObject;
                Debug.Log(hitObject.name);

                Fire(hitObject);
            }
            else if(targetAcquired)
            {
                targetAcquired = false;
            }
        }
    }


    void Fire(GameObject hitObject)
    {
        bool EnoughTimePassedSinceLastShot = ((Time.time - timeLastFired) >= fireRate);

        if (hitObject.tag == target.tag)
        {
            Debug.Log("I hit player with raycast.");

            timeSinceLastBurst = Time.time;
            targetAcquired = true;

            if (EnoughTimePassedSinceLastShot) SpawnProjectile();
        }
        else
        {
            Debug.Log("Target unacquired.");
            targetAcquired = false;
        }
    }

    void SpawnProjectile()
    {
        GameObject projectile;

        if(firePoint != null && shootSound != null)
        {
            projectile = Instantiate(projectileToSpawn, firePoint.transform.position, transform.rotation);
            shootSound.pitch = Random.Range(0.6f, 1f);
            shootSound.Play();

            // Change the firepoint to the other cannon.
            if (firePoint.Equals(leftGun))
            {
                firePoint = rightGun;
            }
            else
            {
                firePoint = leftGun;
            }
            timeLastFired = Time.time;
        }
        else
        {
            targetAcquired = false;
            Debug.Log("Left null?" + leftGun == null);
            Debug.Log("Right null? " + rightGun == null);
            Debug.Log("Sound source null?" + shootSound == null);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
