using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUserID : MonoBehaviour
{
    public static SaveUserID Instance;
    public string UserID;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
