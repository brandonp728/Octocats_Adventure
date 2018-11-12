using UnityEngine;
using System.Collections;

public class OctocatController : MonoBehaviour {


    public float maxSpeed = 10f;
    bool facingRight = true;
    Animator anim;

    bool grounded = false;
    bool touchingWall = false;
    public Transform groundCheck;
    float checkRadius = 0.2f;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    public float jumpForce = 700f;
    public float jumpPushForce = 10f;

    bool doubleJump = false;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        anim.SetBool("Ground", grounded);


        if(grounded)
        {
            doubleJump = false;
        }

        anim.SetFloat("velocityY", GetComponent<Rigidbody2D>().velocity.y);

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);


        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Update()
    {
        if (grounded)
            anim.SetBool("Wall", false);

        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10, jumpForce));
            if(!doubleJump && !grounded)
            {
                doubleJump = true;
            }
        }
        touchingWall = anim.GetBool("Wall");

        if(touchingWall && Input.GetKeyDown(KeyCode.Space))
        {
			Flip();
            WallJump();
        }

    }

    void WallJump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpPushForce, jumpForce));
    }
    void  Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coll enter");
        if(collision.gameObject.tag == "Wall")
        {
            anim.SetBool("Wall", true);
        }
    }
}
