using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger_MoveBool2 : MonoBehaviour
{
    // Start is called before the first frame update


    Rigidbody2D rigid;
    public GameObject AttackBullet;
    public float timer;
    int waitingTime;
    bool attackbool;
    Vector2 dirVec;
    Vector2 dirVec2;
    Vector2 dirVec3;
    void Start()
    {
        rigid = this.gameObject.transform.parent.GetComponent<Rigidbody2D>();

        waitingTime = 3;
        attackbool = false;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= waitingTime && attackbool)
        {
            timer = 0;
            Vector3 newPos = this.transform.position;

            GameObject newGO = Instantiate(AttackBullet) as GameObject;
            newGO.GetComponent<EnemyAttack>().attackpoint = this.transform.parent.GetComponent<EnemyAttack>().attackpoint;
            Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();
            newGO.transform.position = newPos;
            rb.velocity = new Vector2(dirVec.x * 5, dirVec.y * 5);


            GameObject newGO1 = Instantiate(AttackBullet) as GameObject;
            newGO1.GetComponent<EnemyAttack>().attackpoint = this.transform.parent.GetComponent<EnemyAttack>().attackpoint;
            Rigidbody2D rb1 = newGO1.GetComponent<Rigidbody2D>();
            newGO1.transform.position = newPos;
            rb1.velocity = new Vector2(dirVec2.x * 5, dirVec2.y * 5);

            GameObject newGO2 = Instantiate(AttackBullet) as GameObject;
            newGO2.GetComponent<EnemyAttack>().attackpoint = this.transform.parent.GetComponent<EnemyAttack>().attackpoint;
            Rigidbody2D rb2 = newGO2.GetComponent<Rigidbody2D>();
            newGO2.transform.position = newPos;
            rb2.velocity = new Vector2(dirVec3.x * 5, dirVec3.y * 5);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //���;��ִ�
        {
            this.gameObject.transform.parent.GetComponent<Enemy_2>().movebool = true;
            attackbool = true;

            Vector3 otherdirVec = other.transform.position;
            dirVec = (otherdirVec - this.transform.position).normalized;

            otherdirVec.x += 1;
            otherdirVec.y -= 1;
            dirVec2 = (otherdirVec - this.transform.position).normalized;

            otherdirVec.x -= 3;
            otherdirVec.y += 3;

            dirVec3 = (otherdirVec - this.transform.position).normalized;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //���;��ִ�
        {
            this.gameObject.transform.parent.GetComponent<Enemy_2>().movebool = false;
            attackbool = false;
        }
    }
}
