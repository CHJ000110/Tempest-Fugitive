using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_Move : MonoBehaviour
{
    float vx = 0;
    float vy = 0;
    bool leftFlag = false;
    Rigidbody2D rb;
    bool die;

    public bool attackMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        attackMove = true;
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
                leftFlag = true;
            }
            else if (Input.GetKey("a"))
            {
                vx = -1;
                leftFlag = false;
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
                
                this.gameObject.GetComponent<PlayerStatus>().move = true;
            }
            else
            {
                moveZero3();
            }

            if (Input.GetKeyDown("f"))
            {
                showStatus();
            }
        }
        else{
            rb.velocity = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        if(this.gameObject.GetComponent<PlayerStatus>().move && attackMove)
        {
            rb.velocity = new Vector2(vx * this.gameObject.GetComponent<PlayerStatus>().speed , vy* this.gameObject.GetComponent<PlayerStatus>().speed);
        }
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }

    public void moveAttack(float Flag)
    {
        switch (Flag)
        {
            case 1:
                this.rb.AddForce(Vector2.right * 7f, ForceMode2D.Impulse);
                break;
            case 2:
                this.rb.AddForce(Vector2.left * 7f, ForceMode2D.Impulse);
                break;
            case 3:
                this.rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
                break;
            case 4:
                this.rb.AddForce(Vector2.down * 7f, ForceMode2D.Impulse);
                break;
        } 
        Invoke("moveZero2", 0.15f);
    }
    
    public void damageMove(Vector2 dir)
    {
        this.rb.AddForce(dir * 7f, ForceMode2D.Impulse);
        Invoke("moveZero2", 0.2f);
    }

    public void moveZero()
    {
        if (!attackMove)
        {
            rb.velocity = Vector2.zero;
        }
    }
    public void moveZero2()
    {
        rb.velocity = Vector2.zero;
        attackMove = true;
    }
    public void moveZero3()
    {
        if (this.gameObject.GetComponent<PlayerStatus>().move)
        {
            this.gameObject.GetComponent<PlayerStatus>().move = false;
            rb.velocity = Vector2.zero;
        }
    }

    public void showStatus(){

        print("현재 체력 : " + this.gameObject.GetComponent<PlayerStatus>().playerHP);
        print("현재 급거리 공격력 : " + this.gameObject.GetComponent<PlayerStatus>().nearAttackPoint);
        print("현재 원거리 공격력 : " + this.gameObject.GetComponent<PlayerStatus>().farAttackPoint);
    }
}
