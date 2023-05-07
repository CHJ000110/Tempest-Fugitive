using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    internal static object instance;
    public PoolManager pool;

    void Awake()
    {
        Instance = this;
    }
}
