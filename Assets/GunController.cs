using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    float speed = 2;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = new();
        position.y = Camera.main.orthographicSize + 1;

        position.x = Random.Range(-5f, 5f);

        transform.position = position;
    }

    void Update()
    {
        Vector2 movement = Vector2.down;

        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>().timeBetweenShots = 0.05f;
            Destroy(this.gameObject);
        }
    }
}