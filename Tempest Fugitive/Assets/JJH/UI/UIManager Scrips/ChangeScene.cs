using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //������� �ʿ�

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // �ҷ��� ��

    void Start()
    {

    }

    void Update()
    {

    }

    public void Load() // �� �ҷ�����
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthGauge.health += 10f;
    }

}
