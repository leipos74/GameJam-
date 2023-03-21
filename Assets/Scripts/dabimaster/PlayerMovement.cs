using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public float speed;
    public int direction;
    private SpriteRenderer sr;

    public Animator anim;
    public int ingredientId = -1;

    public GameObject spawnPlayer;

    public float punctuation;

    public Punctuation points;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        direction = 1;
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * direction * Time.fixedDeltaTime, gameObject.transform.position.y, gameObject.transform.position.z); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bread1"))
        {
            ingredientId = 0;
            punctuation = 100;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Hamburguer"))
        {
            ingredientId = 1;
            punctuation = 300;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Letuce"))
        {
            ingredientId = 2;
            punctuation = 150;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Cheese"))
        {
            ingredientId = 3;
            punctuation = 320;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Bacon"))
        {
            ingredientId = 4;
            punctuation = 250;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Tomato"))
        {
            ingredientId = 5;
            punctuation = 110;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Egg"))
        {
            ingredientId = 6;
            punctuation = 500;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Bread2"))
        {
            ingredientId = 7;
            punctuation = 100;
            points.SumarPoints(punctuation);
        }
        else if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("gameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plataform")
        {
            transform.parent = other.transform;
        }

        if (other.gameObject.tag == "BounceWall" && direction == 1)
        {
            sr.flipX = true;
            direction = -1;
        }

        else if (other.gameObject.tag == "BounceWall" && direction == -1)
        {
            sr.flipX = false;
            direction = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plataform")
        {
            transform.parent = null;
        }

    }
}
