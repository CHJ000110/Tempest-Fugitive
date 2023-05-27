using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum ExitDirection //출입구 위치
{
    right,
    left,
    down,
    up,
}

public class Exit : MonoBehaviour
{
    public string sceneName = ""; //이동할 씬 이름
    public int doorNumber = 0; // 문 번호
    public ExitDirection direction = ExitDirection.down; //문의 위치

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
            EnergyGauge.health += 10;
        }
    }

}
