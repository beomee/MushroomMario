using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Player player;
    public Rigidbody2D rigid;
    CapsuleCollider2D coll;
    public SpriteRenderer sr;
    Animator anim;
    public GameManager gm;

    public GameObject respawnImg;
    public float moveSpeed;
    public float jumpPower;
    public int jumpCount;
    public LifeAccount lifeAccountClass;
    public Transform fakeGround;
    //public Trigger triggerClass;
    public FakeGround fakeGroundClass;
    public Helly[] hellys;
 

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // ĳ���Ͱ� ����ִ� ��쿡�� ������ �����ϵ��� ����
        if (gm.currentLive == true)
        { 
            PlayerMove();
            PlayerJump();
        }

    }


    // ���� ������ �ٽ� ���� �����ϵ��� + �������¸� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                anim.SetBool("isJump", false);
                jumpCount = 0;

                break;

            case "Obstacle":
                StartCoroutine(PlayerDead());

                rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
                rigid.constraints = RigidbodyConstraints2D.FreezePositionY;

                anim.SetTrigger("PlayerDead");

                break;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision2)
    {
        switch (collision2.gameObject.tag)
        {
            case "Obstacle":
                StartCoroutine(PlayerDead());

                rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
                rigid.constraints = RigidbodyConstraints2D.FreezePositionY;

                anim.SetTrigger("PlayerDead");

                break;
        }



        // �︮ ��ֹ� �۵� �ڵ� 
        switch (collision2.gameObject.name)
        {
            case "Trigger1_Helly":
                hellys[0].rigid.constraints = RigidbodyConstraints2D.None;
                break;

            case "Trigger2_Helly":
                hellys[1].rigid.constraints = RigidbodyConstraints2D.None;
                break;
            case "Trigger3_Helly":
                hellys[2].rigid.constraints = RigidbodyConstraints2D.None;
                break;
            case "Trigger4_Helly":
                hellys[3].rigid.constraints = RigidbodyConstraints2D.None;
                break;
            case "Trigger5_Helly":
                hellys[4].rigid.constraints = RigidbodyConstraints2D.None;
                break;

        }
    }
    void PlayerMove()
    {

        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
        }

        if (h != 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (h > 0)
        {
            sr.flipX = true;
        }

        else if (h < 0)
        {
            sr.flipX = false;
        }



        rigid.AddForce(new Vector2(h, 0), ForceMode2D.Impulse);


        if (rigid.velocity.x > moveSpeed)
        {

            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
        }

        else if (rigid.velocity.x < -moveSpeed)
        {
            rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
        }

    }


    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount == 0)
        {
            // ���� ���� ���ؼ� ����
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            jumpCount++; // ���� Ƚ�� ���� 

            // ���� �ִϸ��̼����� ��ȯ 
            anim.SetBool("isJump", true);

        }
    }

     IEnumerator PlayerDead()
    {
        //triggerClass.isTouch = false;
        // ���� ���� ���ϵ��� bool�� ���� 
        gm.currentLive = false;

        gm.life--;
 
        float time = 0;

        Color origninColor = sr.color;

        yield return new WaitForSeconds(0.5f); 
        // ���������� �������� �ݺ�.
        while (sr.color.a != 0)
        {
            // 1�ʸ��� ������ �ٲ�°�
            time += Time.deltaTime;
            //RGB�� 4���� ������ �־ ����4�� �� 

            //2�ʸ��� ���������� �ڵ� 
            sr.color = Vector4.Lerp(origninColor, new Vector4(origninColor.r, origninColor.g, origninColor.b, 0), time / 3);

            yield return null; //�� �������� ����. 
        }

        yield return new WaitForSeconds(0.5f);

        respawnImg.SetActive(true);


        lifeAccountClass.ShowMyLife();
        

        yield return new WaitForSeconds(2f);
        respawnImg.SetActive(false);
        SceneManager.LoadScene("2. PlayScene");
    }



}