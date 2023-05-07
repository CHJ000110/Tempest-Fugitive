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
    public string targetName;

    bool isLive = true; //����ִ���Ȯ��

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    void Start()
    {
        speed = 1;
        health = 50;
        MaxHealth = 50;
        target = GameObject.Find(targetName);
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() //�÷��̾���󰡴¸���
    {
        Vector3 dirVec = (target.transform.position - this.transform.position).normalized;
        print(target.transform.position);
        //rigid.MovePosition(rigid.position + nextVec);
        //rigid.AddForce(nextVec, ForceMode2D.Impulse);
        rigid.velocity = new Vector2(dirVec.x, dirVec.y);
    }

    void LateUpdate()
    {
        if (!isLive)
        { 
            return;
        }

        //spriter.flipX = target.transform.position.x < this.gameObject.transform.position.x;
    }



    void OnEnable()
    {
        isLive = true;
        health = MaxHealth;
    }
}