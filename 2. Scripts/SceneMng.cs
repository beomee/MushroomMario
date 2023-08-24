using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneMng : MonoBehaviour
{
    public Button startBtn;
    //public Button exitBtn;

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(StartPlayScene);
        //exitBtn.onClick.AddListener(ExitGame);

    }

    void StartPlayScene()
    {
        SceneManager.LoadScene("2. PlayScene");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
        //Json.instance.DataDelete();

#else
Application.Quit();
#endif
    }

}




