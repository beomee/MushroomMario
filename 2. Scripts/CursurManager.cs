using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursurManager : MonoBehaviour
{


    static public CursurManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        //Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
