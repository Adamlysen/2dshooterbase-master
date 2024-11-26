using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    [SerializeField]

    GameObject boltprefab;

    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.up;

        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y > 10)
        {
            Destroy(boltprefab);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>().AddPoints(1);
        }
    }
}
