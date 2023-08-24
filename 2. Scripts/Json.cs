using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// ����ȭ 
[System.Serializable]
public class Data
{
    public Vector2 position; //�÷��̾��� ��ġ 
    public Vector2 respawnPosition; // ���� �������� ��ġ
    public Vector2 respawnPosition2; // ���̺� �浹 �� �������� ��ġ
    public bool isSaved; // ���̺� �ƴ��� üũ�ϴ� ���� 

}


public class Json : MonoBehaviour
{
    public Data data;
    public static Json instance;

    //string GameDataFileName = "GameData.json";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this; //�ν��Ͻ��� ���� �Ҵ� 

            DontDestroyOnLoad(gameObject); // �ٸ������� ���� ������� �ʵ���.      
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //public void Save()
    //{



    //    ���� ���
    //    string path = Application.persistentDataPath + "/" + GameDataFileName;
    //    ������ Ŭ������ json ���·� ��ȯ(������ ����)
    //    string saveDate = JsonUtility.ToJson(data, true);
    //    json ���·� ��ȯ�� ���ڿ��� ����
    //    File.WriteAllText(path, saveDate); //������ �����ϸ鼭 ���� ���ÿ� ����
    //    print("���� �Ϸ�");

    //}




}
