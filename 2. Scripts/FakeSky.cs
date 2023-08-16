using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSky : MonoBehaviour
{

    SpriteRenderer sr;
    BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Color originColor = sr.color;
            sr.color = new Vector4(1, 1, 1, 1);
        }
    }



}


