using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_Move : MonoBehaviour
{
    public float speed = 10;
    public float MaxSpeed = 2;
    public bool move; 

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
        move = false;
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

            if( Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("w")|| Input.GetKey("s"))
            {
                move = true;
            }
            else
            {
                moveZero();
            }

        }
        else{
            rb.velocity = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        if(move)
        {
            rb.velocity = new Vector2(vx * speed , vy* speed);
        }
        /*
        float speedx = Mathf.Abs(this.rb.velocity.x);
        float speedy = Mathf.Abs(this.rb.velocity.y);
        if(speedx < MaxSpeed && speedy < MaxSpeed){
            this.rb.AddForce(new Vector2(vx * speed ,vy * speed));
        }*/
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }

    public void moveAttack(float Flag)
    { 
        switch (Flag)
        {
            case 1:
                this.rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
                break;
            case 2:
                this.rb.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
                break;
            case 3:
                this.rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
                break;
            case 4:
                this.rb.AddForce(Vector2.down * 5f, ForceMode2D.Impulse);
                break;
        }
        Invoke("moveZero2", 0.2f);
    }

    public void moveZero()
    {
        if (move)
        {
            move = false;
            rb.velocity = Vector2.zero;
        }
    }
    public void moveZero2()
    {
        rb.velocity = Vector2.zero;
    }
}
