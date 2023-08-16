using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeAccount : MonoBehaviour
{


    public GameManager gm;

    public Text lifeText;


    public void ShowMyLife()
    {
        lifeText.text = gm.life.ToString();
    }
}
