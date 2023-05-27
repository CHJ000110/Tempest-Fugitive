using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // text사용위한

public class Score : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = coinAmount.ToString();    
    }
}
