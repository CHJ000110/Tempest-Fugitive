using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnData[] spawnData;
    object spawnPoint;



    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

        }
    }
}



    [System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}