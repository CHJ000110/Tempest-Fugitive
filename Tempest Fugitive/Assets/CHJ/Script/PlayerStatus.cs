    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool move;
    public float speed;
    public int playerHP;//현재체력
    public int playerHPMax;//최대체력


    public bool atackFlag;//false는 근접 true는 원거리
    public float waitingTime; //공격속도
    public float farAttackPoint; //원거리공격력
    public float nearAttackPoint;//근거리공격력

    public float criticalPercentage; //치명타 확률
    public float criticalDamage;//치명타 데미지


    // Start is called before the first frame update
    void Start()
    {
        //초기 스탯 초기화
        speed = 3;
        playerHP = 50;
        playerHPMax = 50;
        move = false;

        waitingTime = 0.8f; 
        farAttackPoint = 6; 
        nearAttackPoint = 10;

        atackFlag = true;
        criticalPercentage = 10; 
        criticalDamage = 150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
