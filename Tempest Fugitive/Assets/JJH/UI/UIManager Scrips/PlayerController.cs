using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    float axisH;
    float axisV;
    public float angleZ = -90.0f;

    Rigidbody2D rbody;
    bool isMoving = false;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }

        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(axisH, axisV) * speed;
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HealthGauge.health <= 0) 
        SceneManager.LoadScene(sceneName);

        if (collision.gameObject.tag == "Enemy")
        {
            MonsterGauge.health -= 20f;
        }

        if (collision.gameObject.name == "Building")
        {
            this.gameObject.SetActive(false);
        }
    }

    public string sceneName;

}
