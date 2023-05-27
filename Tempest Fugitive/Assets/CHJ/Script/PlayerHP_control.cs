using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP_control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    float playerHP;
    float playerHPMax;
    public bool die;
    public bool damageBool;
    float accumTime;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        playerHP = target.GetComponent<PlayerStatus>().playerHP;
        playerHPMax = target.GetComponent<PlayerStatus>().playerHPMax;
        die = false;
        damageBool = false;
        accumTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = target.GetComponent<PlayerStatus>().playerHP;
        playerHPMax = target.GetComponent<PlayerStatus>().playerHPMax;
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

    public void HPdamage(float damage)
    {
        target.GetComponent<PlayerStatus>().playerHP -= damage;
    }
}