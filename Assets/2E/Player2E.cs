using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2E : MonoBehaviour
{
    private Rigidbody2D myRB;
    public float speed;
    private float moveInput;

    public float jumpSpeed;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public int hp;

    gameManager gmScript;

    public AudioSource audioEffects;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        gmScript = FindObjectOfType<gameManager>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        jump();
    }


    void jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            audioEffects.PlayOneShot(gmScript.effectClip[0]);
            myRB.velocity = Vector2.up * jumpSpeed;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                myRB.velocity = Vector2.up * jumpSpeed;
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        else
        {
            isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(moveInput * speed, myRB.velocity.y);

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        /*if (moveInput == 0)
        {
            anim.SetBool("isRunnig", false);
        }
        else
        {
            anim.SetBool("isRunnig", true);
        }
        */
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fruits")
        {
            gmScript.aplles += 1;
            Destroy(collision.gameObject);
        }
    }
}
