using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeAccount : MonoBehaviour
{
    public Text lifeText;




    public void ShowMyLife()
    {
        lifeText.text = Player.life.ToString();
    }


}
