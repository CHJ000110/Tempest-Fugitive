using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundOptions : MonoBehaviour
{
    // ����� �ͼ�
    public AudioMixer audioMixer;

    // �����̴�
    public Slider BgmSlider;


    // ���� ����
    public void SetBgmVolme()
    {
        // �α� ���� �� ����
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }

}
