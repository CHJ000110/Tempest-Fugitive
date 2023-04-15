using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolMnanger pool;
    public Enemy enemy;

    void Awake()
    {
        instance = this;
    }   

}
