using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccount : MonoBehaviour
{
    public static Action AccountCreated;
    public static Action NameTaken;

    [Header("Inputs")]
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField passwordInput;

    public string userID;
    private void AddNewUser()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        string maxScore = "00";

        Dictionary<string, object> user = new Dictionary<string, object>();

        user["Username"] = username;
        user["Password"] = password;
        user["MaxScore"] = maxScore;
        string userID = "User: " + username;
        if(username!="")
        {
            DTManager.Instance.UserRef.OrderByChild("Username").EqualTo(username).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if(task.IsCompleted)
                {
                    if(DTManager.Instance.Internet)
                    {
                        DataSnapshot snapshot = task.Result;
                        if (snapshot.Exists)
                        {
                            Debug.LogWarning("This name is already taken.");
                            NameTaken?.Invoke();
                        }
                        else
                        {
                            Debug.LogWarning("Account Created");
                            DTManager.Instance.UserRef.Child(userID).UpdateChildrenAsync(user);
                            AccountCreated?.Invoke();
                        }
                    }
                    else
                    {
                        Debug.Log("No Internet");
                    }
                }
                else
                {
                    Debug.LogError("Failed to Check username" + task.Result);
                }
            });
        }
        else
        {
            Debug.LogError("Empty Text");
        }
    }
    //Buttons
    public void AddNewUserButton()
    {
        AddNewUser();
    }
}
