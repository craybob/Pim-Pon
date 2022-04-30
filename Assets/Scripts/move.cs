using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D myRB;
    public float speed;
    private float moveInput;

    public float jumpSpeed;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    

    Animator anim;

    gameManager gmScript;

    public AudioSource audioEffects;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gmScript = FindObjectOfType<gameManager>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            audioEffects.PlayOneShot(gmScript.effectClip[0]);
            myRB.velocity = Vector2.up * jumpSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPos.position,checkRadius);
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

        if (moveInput == 0)
        {
            anim.SetBool("isRunnig",false);
        }
        else
        {
            anim.SetBool("isRunnig", true);
        }
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
