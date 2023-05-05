using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_NearAttack : MonoBehaviour
{
    public float limitSec = 0.2f;
    void Start()
    {
        Destroy(this.gameObject, limitSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
