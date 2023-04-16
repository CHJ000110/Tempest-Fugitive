using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_Move : MonoBehaviour
{
    public float speed = 10;

    float vx = 0;
    float vy = 0;
    bool leftFlag = false;
    public Rigidbody2D rb;
    bool die;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        die = this.gameObject.GetComponent<PlayerHP_control>().die;
        if (!die)
        {
            vx = 0;
            vy = 0;
            if (Input.GetKey("d"))
            {
                vx = speed;
                leftFlag = false;
            }
            if (Input.GetKey("a"))
            {
                vx = -speed;
                leftFlag = true;
            }
            if (Input.GetKey("w"))
            {
                vy = speed;
            }
            if (Input.GetKey("s"))
            {
                vy = -speed;
            }

        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vx, vy);
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }

    public void moveAttack()
    {
        this.rb.AddForce(Vector2.right * 100f, ForceMode2D.Impulse);
    }

}
