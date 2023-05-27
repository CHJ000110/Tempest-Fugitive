using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger_MoveBool_E3 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    void Start()
    {
        rigid = this.gameObject.transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //���;��ִ�
        {
            this.gameObject.transform.parent.GetComponent<Enemy_3>().movebool = false;
            this.gameObject.transform.parent.GetComponent<Enemy_3>().returnMovebool = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //���;��ִ�
        {
            this.gameObject.transform.parent.GetComponent<Enemy_3>().movebool = true;
            this.gameObject.transform.parent.GetComponent<Enemy_3>().returnMovebool = true;
        }
    }
}
