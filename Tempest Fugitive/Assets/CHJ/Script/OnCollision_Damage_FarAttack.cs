using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision_Damage_FarAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    float attackpoint;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        int i = Random.Range(0, 100);
        attackpoint = target.GetComponent<PlayerStatus>().farAttackPoint;
        if(i < target.GetComponent<PlayerStatus>().criticalPercentage){
            attackpoint = (attackpoint/ 100) * target.GetComponent<PlayerStatus>().criticalDamage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyAttack>().attackpointDamage = attackpoint;
            Destroy(gameObject);
        }
    }
}
