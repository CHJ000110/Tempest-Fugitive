using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_FarAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public string monster;
    public float limitSec = 0.5f;
    void Start()
    {
        limitSec = 0.5f;
        Destroy(this.gameObject, limitSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == monster)
        {
            Destroy(this.gameObject);
        }
    }
}
