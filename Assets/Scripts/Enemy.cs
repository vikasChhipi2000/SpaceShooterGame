using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 300;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] float firingSpeed = 10f;
    [SerializeField] float firingTime;
    [SerializeField] float minFiringTime = .2f;
    [SerializeField] float maxFiringTime = 1f;
    [SerializeField] int deathScore = 100;
    // Start is called before the first frame update
    void Start()
    {
        firingTime = Random.Range(minFiringTime, maxFiringTime);
    }

    // Update is called once per frame
    void Update()
    {
        countAndFire();
    }

    private void countAndFire()
    {
        firingTime -= Time.deltaTime;
        if (firingTime <= 0)
        {
            fire();
            firingTime = Random.Range(minFiringTime, maxFiringTime);
        }
    }

    private void fire()
    {
        var laser = Instantiate(enemyLaser, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -firingSpeed);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this == null)
        {
            return;
        }
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.getDamage();

        damageDealer.hit();
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().addToScore(deathScore);
            GameObject particleEffectExp = Instantiate(explosion, transform.position,Quaternion.identity);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position);
            Destroy(particleEffectExp, 1f);
        }
    }
}
