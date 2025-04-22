using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoostControl : MonoBehaviour
{

    [SerializeField]

    GameObject GunBooster;

    [SerializeField]

    Transform GunBoostSpawner;

    float timeSinceLastSpawn = 0;
    float timeBetweenSpawn = 5;

    void Start()
    {
        
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawn)
        {
            timeSinceLastSpawn = 0;
            Instantiate(GunBooster, GunBoostSpawner.position, Quaternion.identity);
        }
    }
}
