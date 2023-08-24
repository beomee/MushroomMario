using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Ŭ���� ����ȭ

public class Sound
{
    public string name; // ���� �̸�
    public AudioClip clip; // ���� 
}

public class AudioManager : MonoBehaviour
{

    public AudioSource[] audioSourceEffects; // ȿ������ �����ų mp3 �÷��̾�
    public AudioSource audioSourceBgm; // bgm �����ų mp3 �÷��̾� 



    public Sound[] effectSounds; // ȿ������ �뷡�� �̸��� �뷡�� ���� Ŭ���� 
    public AudioClip[] bgmSounds;  // bgm�� �뷡�� �̸��� �뷡�� ���� Ŭ���� 

    // Start is called before the first frame update
    void Start()
    {
        audioSourceBgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // ���� ����
    public void PlaySE(string _name, float _pitch, float _volume)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        audioSourceEffects[j].pitch = _pitch;
                        audioSourceEffects[j].volume = _volume;
                        return; // �̹� ����������ϱ� ���� �ٽ� �ݺ��� �� �ʿ�� ������. -> ���ÿ� �����Ҹ��� �� �� �ְԲ� ��.
                    }
                }
                return;
            }
        }


    }



}
