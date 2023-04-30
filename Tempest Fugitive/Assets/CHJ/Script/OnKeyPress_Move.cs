using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_Move : MonoBehaviour
{
    public float speed = 10;
    public float MaxSpeed = 2;

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
                vx = 1;
                leftFlag = false;
            }
            else if (Input.GetKey("a"))
            {
                vx = -1;
                leftFlag = true;
            }

            if (Input.GetKey("w"))
            {
                vy = 1;
            }
            else if (Input.GetKey("s"))
            {
                vy = -1;
            }

        }
        else{
            rb.velocity = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(vx, vy);
        float speedx = Mathf.Abs(this.rb.velocity.x);
        float speedy = Mathf.Abs(this.rb.velocity.y);
        if(speedx < MaxSpeed && speedy < MaxSpeed){
            this.rb.AddForce(new Vector2(vx * speed ,vy * speed));
        }
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }

    public void moveAttack()
    {
        this.rb.AddForce(Vector2.right * 1f, ForceMode2D.Impulse);
    }

}
