using System.Collections;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    Animator anim;
    public int transCount;
    bool left;
    Vector3 move;
    public LayerMask movPlatform;
    public float distance = 50;

    bool facingRight = true;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        transCount = 0;
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new Vector3(0.1f, 0);
        float x = velocity.x;
        if (left)
        {
            float dirextionX = Mathf.Sign(x);
            transform.Translate(velocity);
            transCount++;
            if (transCount >= distance)
            {
                Flip();
                left = false;
            }
        }
        else if (!left)
        {
            float dirextionX = Mathf.Sign(-x);
            transform.Translate(-velocity);
            transCount--;
            if (transCount <= 1)
            {
                Flip();
                left = true;
            }
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
