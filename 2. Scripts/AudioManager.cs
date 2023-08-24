using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 클래스 직렬화

public class Sound
{
    public string name; // 사운드 이름
    public AudioClip clip; // 사운드 
}

public class AudioManager : MonoBehaviour
{

    public AudioSource[] audioSourceEffects; // 효과음을 재생시킬 mp3 플레이어
    public AudioSource audioSourceBgm; // bgm 재생시킬 mp3 플레이어 



    public Sound[] effectSounds; // 효과음의 노래의 이름과 노래를 담을 클래스 
    public AudioClip[] bgmSounds;  // bgm의 노래의 이름과 노래를 담을 클래스 

    // Start is called before the first frame update
    void Start()
    {
        audioSourceBgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 사운드 실행
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
                        return; // 이미 재생시켰으니까 굳이 다시 반복을 할 필요는 없으니. -> 동시에 여러소리가 날 수 있게끔 함.
                    }
                }
                return;
            }
        }


    }



}
