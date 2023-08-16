using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int min, sec;
    public bool isStart;
    //public float time;

    //public Text timeText;
    public Transform player;


    public Transform[] spawnPoints;
    Transform spawnPoint;


    public Player playerClass;
    //public Transform savedSpawnPoint;

    public Animator anim;

    public bool currentLive = false;

    public int life = 3;
    // Start is called before the first frame update

    private void Awake()
    {
        Time.timeScale = 1;
        currentLive = true;
    }
    void Start()
    {
        isStart = true;

        spawnPoint = spawnPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if (isStart == false)
        //{
        //    return;
        //}

        //else
        //{
        //    time += Time.deltaTime;

        //    sec = (int)time;

        //    if (sec == 60)
        //    {
        //        min++;

        //        time = 0;
        //    }

        //    timeText.text = min.ToString("00") + ":" + sec.ToString("00");
        //} 

    }




    public void PlayerRespawn()
    {
        StartCoroutine(PlayerRespawn_Coroutine());
        // 게임 다시 시작 
    }

    IEnumerator PlayerRespawn_Coroutine()
    {
        
        yield return new WaitForSeconds(1);
        playerClass.rigid.constraints = RigidbodyConstraints2D.None;  // 플레이어 리지드바디 고정 모두 해제 

        yield return new WaitForSeconds(0.1f);

        playerClass.rigid.constraints = RigidbodyConstraints2D.FreezeRotation;   // 플레이어 리지드바디 회전 고정

        anim.SetTrigger("PlayerIdle");
        playerClass.sr.color = new Vector4(1, 1, 1, 1);

        player.position = spawnPoint.position;
        currentLive = true;

    }



    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
    }



}
