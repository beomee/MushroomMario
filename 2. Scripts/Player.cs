using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int dir; // 방향을 결정할 변수
    bool isJumping; // 점프 중인지 확인하는 함수 
    static bool isSave;

    Player player;
    public Rigidbody2D rigid;
    CapsuleCollider2D coll;
    public SpriteRenderer sr;
    Animator anim;
    public GameObject respawnImg;
    public float moveSpeed;
    public float jumpPower;
    public int jumpCount;
    public LifeAccount lifeAccountClass;
    public Transform fakeGround;
    //public Trigger triggerClass;
    public FakeGround fakeGroundClass;
    public Helly[] hellys;
    public GameManager gm;
    public static int life = 2;
    public AudioManager audioManager;

    public bool isTouched_Malady1;
    public bool isTouched_Malady2;
    public bool isTouched_Malady3;

    public Vector2 inputvec;


    bool isGround;

    [SerializeField]
    private string PlayerJumpSE; // 점프사운드
    
    [SerializeField]
    private string PlayerDeadSE; // 죽을 때 사운드

    [SerializeField]
    private string PlayerDeadBgm; // 죽을 때 사운드

    public  Vector2 boxCastSize = new Vector2(0.4f, 0.05f);
    private float boxCastMaxDistance = 0.7f;


    void OnDrawGizmos()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, boxCastMaxDistance, LayerMask.GetMask("Ground"));

        Gizmos.color = Color.red;

        if (raycastHit.collider != null)
        {
            Gizmos.DrawWireCube(transform.position + Vector3.down * raycastHit.distance, boxCastSize);
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {


        player = GetComponent<Player>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        isGround = true;

        if (Json.instance.data.isSaved == false)
        {
            transform.position = Json.instance.data.respawnPosition;
        }

        else
        {
            transform.position = Json.instance.data.respawnPosition2;
        }
        




    }

    // Update is called once per frame
    void Update()
    {


        // 캐릭터가 살아있는 경우에만 조작이 가능하도록 조건
        if (gm.currentLive == true)
        { 
            PlayerMove();
            PlayerJump();
        }


        
    }


    // 땅에 닿으면 다시 점프 가능하도록 + 점프상태를 해제
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                anim.SetBool("isJump", false);
                jumpCount = 0;

                break;

            case "FakeGround":
                anim.SetBool("isJump", false);
                jumpCount = 0;
                isGround = true;

                break;


            case "Obstacle":
                StartCoroutine(PlayerDead());

                rigid.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;


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

            case "Save":
                Json.instance.data.isSaved = true;
                


                break;


        }



        // 헬리 장애물 작동 코드 
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



            case "Trigger7_Malady":

                isTouched_Malady1 = true;
                break;

            case "Trigger8_Malady":
                isTouched_Malady2 = true;
                break;

            case "Trigger9_Malady":
                isTouched_Malady3 = true;

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

        if (isGround == true)
        { 

          if (Input.GetButtonDown("Jump") && jumpCount == 0)
          {
            // 위로 힘을 가해서 점프
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            jumpCount++; // 점프 횟수 증가 

            // 점프 애니메이션으로 전환 
            anim.SetBool("isJump", true);

            audioManager.PlaySE(PlayerJumpSE, 1, 0.3f);
            
          }

        }
    }

    void PlayDeadSound()
    {
        StartCoroutine(DeadSound_Coroutine());
    }

    IEnumerator DeadSound_Coroutine()
    {
        yield return new WaitForSeconds(0.5f);
        audioManager.PlaySE(PlayerDeadBgm, 1, 1f);
    }


     IEnumerator PlayerDead()
    {
  
        audioManager.audioSourceBgm.Stop();
        audioManager.PlaySE(PlayerDeadSE, 1, 0.3f);
        PlayDeadSound();

        //triggerClass.isTouch = false;
        // 조작 하지 못하도록 bool값 변경 
        gm.currentLive = false;

 
        float time = 0;

        Color origninColor = sr.color;

        yield return new WaitForSeconds(0.5f); 
        // 투명해지기 전까지만 반복.
        while (sr.color.a != 0)
        {
            // 1초마다 서서히 바뀌는것
            time += Time.deltaTime;
            //RGB에 4개를 가지고 있어서 벡터4를 씀 

            //2초만에 투명해지는 코드 
            sr.color = Vector4.Lerp(origninColor, new Vector4(origninColor.r, origninColor.g, origninColor.b, 0), time / 3);

            yield return null; //한 프레임을 쉬기. 
        }

        yield return new WaitForSeconds(0.5f);

        respawnImg.SetActive(true);


        lifeAccountClass.ShowMyLife();
        

        yield return new WaitForSeconds(2f);
        respawnImg.SetActive(false);
        SceneManager.LoadScene("2. PlayScene");
        life--;

    }



}
