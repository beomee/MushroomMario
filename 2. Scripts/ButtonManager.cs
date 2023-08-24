using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button pauseBtn; // �Ͻ����� ��ư
    public Button resumeBtn; // ���� �簳 ��ư
    public Button exitBtn; // ���� ������ ��ư 
    public Button homeBtn; // ����ȭ������ ��ȯ
    public Button restartBtn; // ���� �ٽý��� ��ư
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
        gm.GamePause(); // ���� �Ͻ����� �Լ�

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
