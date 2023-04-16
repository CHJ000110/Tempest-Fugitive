using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPress_attack : MonoBehaviour
{
    public GameObject newPrefab;
    public int maxCount = 20;
    public int speed = 5;
    public float force = 1000;

    float Flag;
    public bool pushFlag;

    Rigidbody2D rb;
    //false는 근접 true는 원거리
    public bool ataackFlag;
    public bool ataackFlag2;
    public float timer;
    int waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        Flag = 1;
        pushFlag = false;
        ataackFlag2 = false;
        ataackFlag = true;
        timer = 0;
        waitingTime = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("d"))
        {
            Flag = 1;
        }
        if (Input.GetKey("a"))
        {
            Flag = 2;

        }
        if (Input.GetKey("w"))
        {
            Flag = 3;

        }
        if (Input.GetKey("s"))
        {
            Flag = 4;

        }
        if (Input.GetMouseButtonDown(1))
        {
            ataackFlag = !ataackFlag;
        }
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            if(ataackFlag){
                if (Input.GetMouseButtonDown(0))
                {
                    timer = 0;
                    Vector3 newPos = this.transform.position;
                    newPos.z = -5;

                    GameObject newGO = Instantiate(newPrefab) as GameObject;
                    Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();

                    switch (Flag)
                    {
                        case 1:
                            newPos.x += 1f;
                            newGO.transform.position = newPos;
                            rb.velocity = new Vector2(speed, 0);
                            break;
                        case 2:
                            newPos.x -= 1f;
                            newGO.transform.position = newPos;
                            newGO.transform.Rotate(0, 0, 180);
                            rb.velocity = new Vector2(-speed, 0);
                            break;
                        case 3:
                            newPos.y += 1f;
                            newGO.transform.position = newPos;
                            newGO.transform.Rotate(0, 0, 90);
                            rb.velocity = new Vector2(0, speed);
                            break;
                        case 4:
                            newPos.y -= 1f;
                            newGO.transform.position = newPos;
                            newGO.transform.Rotate(0, 0, 270);
                            rb.velocity = new Vector2(0, -speed);
                            break;
                    }

                }
            }
            else{
                //근접 공격
                if (Input.GetMouseButtonDown(0))
                {
                    timer = 0;
                    ataackFlag2 = true;
                    this.GetComponent<OnKeyPress_Move>().moveAttack();
                }
            }

        }
    }

}
