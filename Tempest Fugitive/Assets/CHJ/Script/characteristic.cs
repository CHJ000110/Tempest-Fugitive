using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characteristic : MonoBehaviour
{
    // Start is called before the first frame update
    public string player;
    public float limitSec = 1f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == player)
        {
            other.gameObject.GetComponent<PlayerStatus>().farAttackPoint -= 3;
            other.gameObject.GetComponent<PlayerStatus>().nearAttackPoint += 5;
            Destroy(this.gameObject);
        }
    }
}
