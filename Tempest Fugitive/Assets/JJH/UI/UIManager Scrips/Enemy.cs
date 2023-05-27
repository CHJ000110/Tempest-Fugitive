using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MonsterGauge.health == 0)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            HealthGauge.health -= 10f;
            return;
        }
    }
}
