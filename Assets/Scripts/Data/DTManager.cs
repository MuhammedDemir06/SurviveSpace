using Firebase.Database;
using Firebase;
using Firebase.Extensions;
using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class DTManager : MonoBehaviour
{
    public static DTManager Instance;
    public DatabaseReference UserRef;
    public bool Internet;
    [SerializeField] private GameObject noInternet;
    private void Awake()
    {
        Instance = this;
        UserRef = FirebaseDatabase.DefaultInstance.GetReference("Users");
    }
    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.LogWarning("No internet connection. Please check your connection and try again.");
            Internet = false;
            noInternet.SetActive(true);
            // Burada kullanýcýya uygun bir uyarý mesajý gösterebilirsiniz
            return;
        }
        else
        {
            Internet = true;
            noInternet.SetActive(false);
        }
    }
}