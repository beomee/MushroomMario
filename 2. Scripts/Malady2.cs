using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malady2 : MonoBehaviour
{
    Animator anim;
    public Player player;
    bool isMoveStop;

    float targetX = -30.0f; // 목표 x 위치
    float moveSpeed;// 이동 속도

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (player.isTouched_Malady2 == true && isMoveStop == false)
        {
            moveSpeed = 75f;

            // 현재 위치에서 목표 위치로 부드럽게 이동
            Vector3 newPosition = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);

            // 새로운 위치로 이동
            transform.position = newPosition;


        }

        else if (player.isTouched_Malady2 == false)
        {
            moveSpeed = 0f;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMoveStop = true;
            anim.SetTrigger("Dead");
        }
    }


}

