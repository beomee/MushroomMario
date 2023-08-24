using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGround : MonoBehaviour
{
    public Transform fakeGround;
    public Trigger triggerClass;

    //public Vector2 firstPosition;
    //float speed = 100.0f; // 이동속도 
    public GameManager gm;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        //firstPosition = new Vector2(transform.position.x, transform.position.y);
       rigid = GetComponent<Rigidbody2D>();
    }

    // 리지드바디 써서 해보자


    // Update is called once per frame
    void Update()
    {
        //if (triggerClass.isTouch == true && gm.currentLive == true)
        //{ 
        //Vector3 moveDirection = Vector3.down; // 아래 방향을 나타내는 벡터
        //Vector3 movement = moveDirection * speed * Time.deltaTime; // 이동량 계산

        //transform.position += movement; // 오브젝트의 위치 변경

        //}

        //else if (triggerClass.isTouch == false && gm.currentLive == true)
        //{
        //    Vector3 moveDirection = Vector3.down; // 아래 방향을 나타내는 벡터
        //    Vector3 movement = moveDirection * speed * Time.deltaTime; // 이동량 계산

        //    //transform.position = new Vector3(0, 0, 0);

        //}


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DropGround_Coroutine());
        }

    }


    IEnumerator DropGround_Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        rigid.constraints = RigidbodyConstraints2D.None;
    }


}
