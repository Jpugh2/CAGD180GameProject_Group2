using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool goingDown;
    public GameObject projectilePrefab;
    [Header("Spawner Variables")]
    public float timeBetweenShots;
    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }

    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if(projectile.GetComponent<Laser>())
        {
            projectile.GetComponent<Laser>().goingDown = goingDown;
        }
    }
  
}
