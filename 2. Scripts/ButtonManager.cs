using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button pauseBtn; // 일시정지 버튼
    public Button resumeBtn; // 게임 재개 버튼
    public Button exitBtn; // 게임 나가기 버튼 
    public Button homeBtn; // 시작화면으로 전환
    public Button restartBtn; // 게임 다시시작 버튼
    public GameManager gm;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

        homeBtn.onClick.AddListener(HomeScene);
        //restartBtn.onClick.AddListener(StartPlayScene);
        exitBtn.onClick.AddListener(ExitGame);

    }

    void StartPlayScene()
    {
        SceneManager.LoadScene("2. PlayScene");
    }

    void ShowGamepauseUi()
    {
        gm.GamePause(); // 게임 일시정지 함수

    }

    void HomeScene()
    {
        SceneManager.LoadScene("1. StartScene");
        Json.instance.data.isSaved = false;
        Player.life = 2;
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
