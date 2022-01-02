using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public bool Jumping;
    public int jumlah;
    private Animator anim;

    public GameObject snowBall;
    public Transform throwPoint;

    public AudioSource throwsound;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        } else if  (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
        
        if (!Jumping || jumlah <= 1)
        {
                if (Input.GetKeyDown(jump))
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    Jumping = true;
                    jumlah++;
                }
        }
        if (Input.GetKeyDown(throwBall))
        {
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

            throwsound.Play();
        }

        if (theRB.velocity.x < 0) 
        {
            transform.localScale = new Vector3 (-1,1,1);
        }
        else if(theRB.velocity.x > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

        if (Jumping)
        {
            anim.SetBool("Grounded", false);
        } else
        {
            anim.SetBool("Grounded", true);
        }
        Debug.Log(jumlah);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Tanah"))
        {
            Jumping = false;
            jumlah = 0;
        }
       
    }
}
