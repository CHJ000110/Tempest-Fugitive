using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public int health;
    public int MaxHealth;
    public Sprite[] sprites;
    public GameObject itemCoin;
    public GameObject player;

    SpriteRenderer spriteRenderer; //�����ǰݻ���
    Rigidbody2D rigid;


    void Start()
    {
        speed = 10;
        health = 50;
        MaxHealth = 50;
    }
    void Awake() //���Ͱ���
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Onhit(int dmg) //�����ǰ�
    {
        health -= dmg; //�������Ծ����� ü��
        spriteRenderer.sprite = sprites[1];  //�����ǰݻ���2
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {

            int ran = Random.Range(0, 10); //���;��ָ����� ����Ȯ��           
            if (ran < 10) //����
            {
                Instantiate(itemCoin, transform.position, itemCoin.transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    void ReturnSprite() //�ǰݻ��򵹾ƿ���
    {
        spriteRenderer.sprite = sprites[0];
    }

/*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet") //���;��ִ�
            Destroy(gameObject);
        else if (collision.gameObject.tag == "PlayerBullet") {
            Bullet1 bullet = collision.gameObject.GetComponent<Bullet1>(); //�Ѿ��±�
            Onhit(bullet.dmg); //������

            Destroy(collision.gameObject);    //�ǰݽ� �÷��̾� �Ѿ˻���
        }
    }*/
}
