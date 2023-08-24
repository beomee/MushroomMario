using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 직렬화 
[System.Serializable]
public class Data
{
    public Vector2 position; //플레이어의 위치 
    public Vector2 respawnPosition; // 최초 리스폰의 위치
    public Vector2 respawnPosition2; // 세이브 충돌 후 리스폰의 위치
    public bool isSaved; // 세이브 됐는지 체크하는 변수 

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
            instance = this; //인스턴스에 나를 할당 

            DontDestroyOnLoad(gameObject); // 다른씬으로 가도 사라지지 않도록.      
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //public void Save()
    //{



    //    저장 경로
    //    string path = Application.persistentDataPath + "/" + GameDataFileName;
    //    저장할 클래스를 json 형태로 전환(가독성 좋게)
    //    string saveDate = JsonUtility.ToJson(data, true);
    //    json 형태로 전환된 문자열을 저장
    //    File.WriteAllText(path, saveDate); //파일을 생성하면서 값을 동시에 저장
    //    print("저장 완료");

    //}




}
