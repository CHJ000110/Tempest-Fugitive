using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; //프리펩보관 변수

    List<GameObject>[] pools; //프리펩 보관 풀리스트

    void Awake() //초기화담당
    {
        pools = new List<GameObject>[prefabs.Length];  
        
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null; //비활성(몬스터) 오브젝트 접근

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
