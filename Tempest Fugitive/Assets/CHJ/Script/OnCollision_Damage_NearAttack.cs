using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision_Damage_NearAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    float attackpoint;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        attackpoint = target.GetComponent<PlayerStatus>().nearAttackPoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().OnDamage(attackpoint);
            Destroy(gameObject);
        }
    }
}
