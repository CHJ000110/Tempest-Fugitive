using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    public string type; //������Ÿ��
    Rigidbody2D rigid; //�����ۼӵ�
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down * 1/2, ForceMode2D.Impulse); //�����ۼӵ�
    }
}
