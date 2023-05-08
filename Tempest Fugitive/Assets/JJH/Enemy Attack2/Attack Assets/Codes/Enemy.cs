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

    void Start()
    {

        returnMovebool = false;
        firstVec = this.transform.position;
        speed = 1;
        health = 50;
        MaxHealth = 50;
        target = GameObject.FindWithTag("Player");
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
        else{
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
            }
        }
    }

    void LateUpdate()
    {
        if (!isLive)
        { 
            return;
        }

        spriter.flipX = target.transform.position.x < this.gameObject.transform.position.x;
    }


    void Update()
    {
        if(health <= 0){
            isLive = false;

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
        print("남은 몬스터 HP : "+health);
    }

    void OnEnable()
    {
        isLive = true;
        health = MaxHealth;
    }
}