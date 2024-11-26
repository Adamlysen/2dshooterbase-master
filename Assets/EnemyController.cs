using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    [SerializeField]
    GameObject explosionPrefab;

    GameObject player;

    void Start()
    {
        Vector2 position = new();
        position.y = Camera.main.orthographicSize + 1;

        position.x = Random.Range(-5f, 5f);

        transform.position = position;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector2 movement = Vector2.down;

        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
            player.GetComponent<ShipController>().currentHealth--;
            player.GetComponent<ShipController>().hpBar.value = player.GetComponent<ShipController>().currentHealth;
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bolt" || other.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
