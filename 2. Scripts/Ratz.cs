using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ratz : MonoBehaviour
{
    int dir; // 방향을 결정할 변수
    bool isChange = false; // 방향 바꿈을 확인하는 변수 

    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer sr;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        RandomDir();
    }

    private void FixedUpdate()
    {

        // 랜덤값으로 이동
        rigid.velocity = new Vector2(dir * 3f, rigid.velocity.y);


    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(dir * 1.0f, 0, 0), Vector2.down);

        if (dir != 0)
        {
            

            RaycastHit2D hit
                = Physics2D.Raycast(transform.position + new Vector3(dir * 1.0f, 0, 0), Vector2.down, 1);


            if (!hit && !isChange)
            {

                CancelInvoke("RandomDir");

                // 방향 바꾸기 
                dir = dir * -1;

                // 방향 바꿨음을 저장 
                isChange = true;  // 버그 방지.

                Dir();


                Invoke("RandomDir", 10f);

            }
            else if (hit)
            {
                isChange = false;
            }

        }

    }

    void RandomDir()
    {
        // 방향 랜덤으로 하기.
        dir = Random.Range(-1, 2);

        Dir();

        // 랜덤한 주기로 반복하기(Invoke -> 나 스스로는 무한으로 반복) 
        Invoke("RandomDir", 5f);

    }

    void Dir()
    {

        anim.SetInteger("dir", dir);



        if (dir < 0)
        {
            sr.flipX = false;
        }
        else if (dir > 0)
        {
            sr.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            anim.SetTrigger("Dead");
        }
    }
}
