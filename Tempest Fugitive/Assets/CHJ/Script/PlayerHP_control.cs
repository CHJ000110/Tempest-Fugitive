using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP_control : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerHP = 50;
    public int playerHPMax = 50;
    public bool die;
    float accumTime;
    void Start()
    {
        playerHP = 50;
        playerHPMax = 50;
        die = false;
        accumTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerHP <= 0)
        {
            this.gameObject.GetComponent<OnkeyPress_ChangeAnime>().DieAnim();
            die = true;
            accumTime += Time.deltaTime;
            if (accumTime >= 1.0f)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else */
        if (playerHP > playerHPMax)
        {
            playerHP = playerHPMax;
        }
    }
}