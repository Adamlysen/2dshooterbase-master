using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]

    GameObject EnemyPrefab;

    [SerializeField]

    Transform EnemySpawner;

    [SerializeField]

    TMP_Text LevelText;

    float timeSinceLastSpawn = 0;
    float timeBetweenSpawn = 2;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeBetweenSpawn && player.GetComponent<ShipController>().currentScore < 20)
        {
            timeSinceLastSpawn = 0;
            Instantiate(EnemyPrefab, EnemySpawner.position, Quaternion.identity);
        }
        else if (timeSinceLastSpawn > timeBetweenSpawn && player.GetComponent<ShipController>().currentScore >= 20 && player.GetComponent<ShipController>().currentScore < 50)
        {
            timeBetweenSpawn = 1;
            timeSinceLastSpawn = 0;
            LevelText.SetText("Level 2");
            Instantiate(EnemyPrefab, EnemySpawner.position, Quaternion.identity);
        }
        else if (timeSinceLastSpawn > timeBetweenSpawn && player.GetComponent<ShipController>().currentScore >= 50)
        {
            timeBetweenSpawn = 0.5f;
            timeSinceLastSpawn = 0;
            LevelText.SetText("Level 3");
            Instantiate(EnemyPrefab, EnemySpawner.position, Quaternion.identity);
        }
    }
}
