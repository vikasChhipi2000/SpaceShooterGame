using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 1000;

    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] TMP_Text healthText;

    [Header("Player Laser")]
    [SerializeField] GameObject simpleLaser;
    [SerializeField] float laserSpeed = 20f;
    [SerializeField] float firingTime = .05f;

    Coroutine firingCoroutine;
    float xMax;
    float xMin;
    float yMax;
    float yMin;


    void Start()
    {
        healthText.text = health.ToString();
        SetUpBoundary();
    }

    private void SetUpBoundary()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.getDamage();
        damageDealer.hit();
        if (health <= 0)
        {
            healthText.text = "0";
            GameObject particleEffectExp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
            Destroy(particleEffectExp, 1f);
            FindObjectOfType<SceneLoader>().gameOver();
        }
        else
        {
            healthText.text = health.ToString();
        }
    }

    void Update()
    {
        move();
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(firingCont());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator firingCont()
    {
        while (true)
        {
            GameObject laser = Instantiate(simpleLaser, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position);
            yield return new WaitForSeconds(firingTime);
        }
    }

    private void move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

}
