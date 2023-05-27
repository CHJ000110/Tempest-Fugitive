using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger_MoveBool2_E1 : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigid;
    public GameObject AttackBullet;
    public float timer;
    int waitingTime;
    bool attackbool;
    Vector2 dirVec;
    void Start()
    {
        rigid = this.gameObject.transform.parent.GetComponent<Rigidbody2D>();

        waitingTime = 1;
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
            rb.velocity = new Vector2(dirVec.x*5, dirVec.y*5);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //���;��ִ�
        {
            this.gameObject.transform.parent.GetComponent<Enemy>().movebool = true;
            attackbool = true;
            dirVec = (other.transform.position - this.transform.position).normalized;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //���;��ִ�
        {
            this.gameObject.transform.parent.GetComponent<Enemy>().movebool = false;
            attackbool = false;
        }
    }
}