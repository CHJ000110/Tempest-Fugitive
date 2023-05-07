using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; //�����麸�� ����

    List<GameObject>[] pools; //������ ���� Ǯ����Ʈ

    void Awake() //�ʱ�ȭ���
    {
        pools = new List<GameObject>[prefabs.Length];  
        
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null; //��Ȱ��(����) ������Ʈ ����

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;   
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
