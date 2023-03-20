using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private int direction;

    public int ingredientId = -1;

    private void Start()
    {
        direction = 1;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * direction * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z); 


        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            direction = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cheese"))
        {
            ingredientId = 0;
        }
    }
}
