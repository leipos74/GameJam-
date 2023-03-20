using System.Collections;
using System.Collections.Generic;
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
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
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
