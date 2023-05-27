using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //¾Àº¯°æ½Ã ÇÊ¿ä

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // ºÒ·¯¿Ã ¾À

    void Start()
    {

    }

    void Update()
    {

    }

    public void Load() // ¾À ºÒ·¯¿À±â
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthGauge.health += 10f;
    }

}
