using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTouch = false;
    public Helly helly;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
       
            // ¶³¾î¶ß¸®´Â ÄÚµå 
            helly.rigid.constraints = RigidbodyConstraints2D.None;



        }

    }

    //private void OnTriggerExit2D(Collider2D collision2)
    //{
    //    if (collision2.gameObject.tag == "Player")
    //    {
    //        isTouch = false;
    //    }
    //}

