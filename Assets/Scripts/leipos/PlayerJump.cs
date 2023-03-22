using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float jumpForce;
    public Transform groundCheckPoint;
    public Vector2 boxDimensions;
    public LayerMask whatIsGround;

    public bool isGrounded;
    private bool canJump;

    AudioSource audioSource;
    public AudioClip jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, boxDimensions, 0, whatIsGround);
        anim.SetBool("run", isGrounded);

        if (Input.GetButtonDown("Jump"))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        if(canJump && isGrounded && PlayerMovement.Instance.canMove)
        {
            Saltar();
        }

        canJump = false;
    }

    private void Saltar()
    {
        audioSource.PlayOneShot(jump);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, boxDimensions);
    }
}
