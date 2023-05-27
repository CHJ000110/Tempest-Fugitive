using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            float attackPoint = other.gameObject.GetComponent<EnemyAttack>().attackpoint;
            if (!gameObject.GetComponent<PlayerHP_control>().damageBool)
            {
                gameObject.GetComponent<PlayerHP_control>().HPdamage(attackPoint);
                gameObject.GetComponent<PlayerHP_control>().damageBool = true;
                Vector2 dir = (this.transform.position - other.transform.position).normalized;
                this.GetComponent<OnKeyPress_Move>().attackMove = false;
                this.GetComponent<OnKeyPress_Move>().moveZero();

                this.GetComponent<OnKeyPress_Move>().damageMove(dir);
            }
        }
    }
}
