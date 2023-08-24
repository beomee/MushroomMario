using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    Animator anim;
    public GameObject finishImg;
    public LifeAccount lifeAccountClass;
    public AudioManager audioManager;

    [SerializeField]
    private string victorySound; // 세이브 완료 소리

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Finish");
            finishImg.SetActive(true);
            lifeAccountClass.ShowMyLife();
            audioManager.PlaySE(victorySound, 1, 1);

        }
    }
}
