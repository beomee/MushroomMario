using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helly : MonoBehaviour
{
    public Rigidbody2D rigid;

    
    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
    }


}
    // Update is called once per frame

