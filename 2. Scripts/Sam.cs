using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sam : MonoBehaviour
{

    Animator anim;
    BoxCollider2D coll;
    public AudioManager audioManager;

    [SerializeField]
    private string saveComplete; // 세이브 완료 소리


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

        if (Json.instance.data.isSaved == true)
        {
            coll.enabled = false;
        }

        else
        {
            coll.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            anim.SetTrigger("Save");
            audioManager.PlaySE(saveComplete, 1, 1);
            coll.enabled = false;

        }
    }
}
