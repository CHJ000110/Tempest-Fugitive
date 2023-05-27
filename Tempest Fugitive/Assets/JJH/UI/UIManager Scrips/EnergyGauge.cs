using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGauge : MonoBehaviour
{
    Image healthE;
    float maxHealth = 100f;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        healthE = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        healthE.fillAmount = health / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnergyGauge.health += 10f;

    }
}

