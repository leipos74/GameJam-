using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spawnTime;
    private float counter;
    public float bulletSpeedX;
    public float bulletSpeedY;
    public float dispawnTime;
    private float count2;

    AudioSource audioSource;
    public AudioClip shot;

    public GameObject enemy;
    public GameObject player;

    public PlayerMovement p;
    public GameObject bulletPrefab;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bulletPrefab.transform.position = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        count2 += Time.deltaTime;


        if (transform.position.x <= player.transform.position.x)
        {
            sr.flipX = true;
            if (counter > spawnTime)
            {
                bulletPrefab.GetComponent<SpriteRenderer>().enabled = true;
                bulletPrefab.GetComponent<SpriteRenderer>().flipX = true;
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, enemy.transform, true);
                audioSource.PlayOneShot(shot);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeedY, bullet.GetComponent<Rigidbody2D>().velocity.y);
                counter = 0;
            }
        }
        else
        {
            sr.flipX = false;
            if (counter > spawnTime)
            {
                audioSource.PlayOneShot(shot);
                bulletPrefab.GetComponent<SpriteRenderer>().enabled = true;
                bulletPrefab.GetComponent<SpriteRenderer>().flipX = false;
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, enemy.transform, true);
                audioSource.PlayOneShot(shot);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeedX, bullet.GetComponent<Rigidbody2D>().velocity.y);
                counter = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            p.punctuation += 324;
            Destroy(gameObject);
        }
    }
}
