using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float MaxHealth;
    public RuntimeAnimatorController[] animCon;
    public GameObject target;

    bool isLive = true; //����ִ���Ȯ��

    public bool movebool = true; //����ִ���Ȯ��

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;
    public GameObject itemCoin;
    Vector3 firstVec;
    public bool returnMovebool = false; //����ִ���Ȯ��

    public bool attackMove;
    void Start()
    {
        movebool = true;
        returnMovebool = false;
        attackMove = true;
        firstVec = this.transform.position;
        speed = 10;
        health = 50;
        MaxHealth = 50;
        target = GameObject.FindWithTag("Player");
        rigid.gravityScale = 0;
        gameObject.GetComponent<EnemyAttack>().attackpoint = 5;
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() //�÷��̾���󰡴¸���
    {
        if (!isLive)
        {
            return;
        }
        if (movebool)
        {
            rigid.velocity = new Vector2(0,0);
        }
        else if (attackMove){
            Vector3 dirVec = (target.transform.position - this.transform.position).normalized;
            //rigid.MovePosition(rigid.position + nextVec);
            //rigid.AddForce(nextVec, ForceMode2D.Impulse);
            rigid.velocity = new Vector2(dirVec.x, dirVec.y);

        }

        if (returnMovebool)
        {
            if(this.transform.position.x <= firstVec.x+0.2f && this.transform.position.x >= firstVec.x-0.2f && this.transform.position.y <= firstVec.y + 0.2f &&this.transform.position.y >= firstVec.y - 0.2f)
            {

                rigid.velocity = new Vector2(0, 0);
            }
            else
            {
                Vector3 dirVec1 = (firstVec - this.transform.position).normalized;
                //rigid.MovePosition(rigid.position + nextVec);
                //rigid.AddForce(nextVec, ForceMode2D.Impulse);
                rigid.velocity = new Vector2(dirVec1.x, dirVec1.y);
                spriter.flipX = firstVec.x > this.gameObject.transform.position.x;
            }
        }
    }

    void LateUpdate()
    {
        if (!isLive)
        { 
            return;
        }

        spriter.flipX = target.transform.position.x > this.gameObject.transform.position.x;
    }


    void Update()
    {
        if(health <= 0){
            isLive = false;
            health = 0;
            int ran = Random.Range(0, 10); //���;��ָ����� ����Ȯ��           
            if (ran < 10) //����
            {
                Instantiate(itemCoin, transform.position, itemCoin.transform.rotation);
            }
            Destroy(gameObject);
        }
        
    }

    public void OnDamage(float ataackpoint)
    {
        health -= ataackpoint;
        if (health <= 0)
        {
            health = 0;
        }
        Debug.Log("남은 몬스터 HP : "+health);
    }

    public void damageMove(Vector2 dir)
    {
        this.rigid.AddForce(dir * 7f, ForceMode2D.Impulse);
        Invoke("moveZero2", 0.2f);
    }

    public void moveZero()
    {
        if (!attackMove)
        {
            rigid.velocity = Vector2.zero;
        }
    }
    public void moveZero2()
    {
        rigid.velocity = Vector2.zero;
        attackMove = true;
    }
    void OnEnable()
    {
        isLive = true;
        health = MaxHealth;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            OnDamage(gameObject.GetComponent<EnemyAttack>().attackpointDamage);
            Vector2 dir = (this.transform.position - other.transform.position).normalized;
            attackMove = false;
            moveZero();
            damageMove(dir);
        }
    }
}