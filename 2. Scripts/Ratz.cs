using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ratz : MonoBehaviour
{
    int dir; // ������ ������ ����
    bool isChange = false; // ���� �ٲ��� Ȯ���ϴ� ���� 

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

        // ���������� �̵�
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

                // ���� �ٲٱ� 
                dir = dir * -1;

                // ���� �ٲ����� ���� 
                isChange = true;  // ���� ����.

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
        // ���� �������� �ϱ�.
        dir = Random.Range(-1, 2);

        Dir();

        // ������ �ֱ�� �ݺ��ϱ�(Invoke -> �� �����δ� �������� �ݺ�) 
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
