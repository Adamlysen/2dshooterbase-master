using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpControl : MonoBehaviour
{

    [SerializeField]

    GameObject HealthIcon;

    [SerializeField]

    Transform PowerUpSpawner;

    float timeSinceLastSpawn = 0;
    float timeBetweenSpawn = 15;

    void Start()
    {
        
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawn)
        {
            timeSinceLastSpawn = 0;
            Instantiate(HealthIcon, PowerUpSpawner.position, Quaternion.identity);
        }
    }
}
