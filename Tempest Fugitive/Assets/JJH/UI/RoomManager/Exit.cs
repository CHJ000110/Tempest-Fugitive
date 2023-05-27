using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum ExitDirection //���Ա� ��ġ
{
    right,
    left,
    down,
    up,
}

public class Exit : MonoBehaviour
{
    public string sceneName = ""; //�̵��� �� �̸�
    public int doorNumber = 0; // �� ��ȣ
    public ExitDirection direction = ExitDirection.down; //���� ��ġ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
            EnergyGauge.health += 10;
        }
    }

}
