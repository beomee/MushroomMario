using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helly : MonoBehaviour
{
    public Rigidbody2D rigid;
    Animator anim;
    AudioManager audioManager;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        audioManager = GetComponent<AudioManager>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            anim.SetTrigger("Dead");
        }
    }



}
    // Update is called once per frame

