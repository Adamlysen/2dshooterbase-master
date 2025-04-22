using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class ShipController : MonoBehaviour
{

    [SerializeField]

    float speed = 0.02f;

    [SerializeField]

    GameObject Boltprefab;

    [SerializeField]

    Transform GunPosition;

    public float timeBetweenShots = 0.25f;
    float timeSinceLastShot = 0;

    [SerializeField]
    bool PowerupActive = false;
    float ptimer = 0;

    [SerializeField]

    int maxHealth = 10;
    public int currentHealth;

    [SerializeField]

    public Slider hpBar;

    [SerializeField]

    TMP_Text scoretext;

    int ScoreCount = 0;
    public int currentScore = 0;
    void Start()
    {
        currentHealth = maxHealth;
        hpBar.maxValue = maxHealth;
        hpBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        // print(xInput);

        float yInput = Input.GetAxisRaw("Vertical");
        // print(yInput);

        Vector2 movement = new Vector2(xInput, yInput) * speed * Time.deltaTime;

        // Vector2 movement2 = new Vector2(0, 1) * speed * yInput;

        transform.Translate(movement);

        timeSinceLastShot += Time.deltaTime;

        if (PowerupActive)
        {
            ptimer += Time.deltaTime;
            if (ptimer >= 5f)
            {
                PowerupActive = false;
                ptimer = 0;
                timeBetweenShots = 0.25f; // Reset to normal
            }
        }



        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShots)
        {
            timeSinceLastShot = 0;
            Instantiate(Boltprefab, GunPosition.position, Quaternion.identity);
        }
        if (currentHealth > 10)
        {
            currentHealth = 10;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            currentHealth--;
            hpBar.value = currentHealth;
            print(currentHealth);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (other.tag == "Power")
        {
            PowerupActive = true;
            ptimer = 0;
            timeBetweenShots = 0.05f;
            Destroy(other.gameObject); // optional
        }
    }

    public void AddHealth(int h)
    {
        currentHealth += h;
        hpBar.value = currentHealth;
    }

    public void AddPoints(int p)
    {
        currentScore += p;
        scoretext.SetText($"{currentScore}");
    }
}
