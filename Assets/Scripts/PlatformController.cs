using System.Collections;
using UnityEngine;
[RequireComponent (typeof (BoxCollider2D))]
public class PlatformController : MonoBehaviour {
    Animator anim;
    public int xCount;
    public int yCount;
    bool left;
    bool up;
    Vector3 move;
    public LayerMask movPlatform;
    public float distance = 50;
    public bool verticle = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        xCount = 0;
        left = true;
        up = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(verticle)
        {
            VertMov();
        }
        else if(!verticle)
        {
            HorMove();
        }
	}
    void HorMove()
    {
        Vector3 velocity = new Vector3(0.05f, 0);
        float x = velocity.x;
        if (left)
        {
            transform.Translate(velocity);
            xCount++;
            if (xCount >= distance)
            {
                left = false;
            }
        }
        else if (!left)
        {
            transform.Translate(-velocity);
            xCount--;
            if (xCount <= 1)
            {
                left = true;
            }
        }
    }

    void VertMov()
    {
        Vector3 velocity = new Vector3(0, 0.05f);
        float y = velocity.y;
        if(up)
        {
            transform.Translate(velocity);
            yCount++;
            if(yCount >= distance)
            {
                up = false;
            }
        }
        else if(!up)
        {
            transform.Translate(-velocity);
            yCount--;
            if(yCount <=1 )
            {
                up = true;
            }
        }
    }
}
