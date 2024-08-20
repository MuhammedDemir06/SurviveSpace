using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginAccount : MonoBehaviour
{
    public static Action SceneTransition;
    public static Action WrongLogin;

    public static LoginAccount Instance;

    [Header("Input")]
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField passwordInput;
    private void Login()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        DTManager.Instance.UserRef.OrderByChild("Username").EqualTo(username).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted )
            {
                if(DTManager.Instance.Internet)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Exists)
                    {
                        foreach (DataSnapshot userSnaposhot in snapshot.Children)
                        {
                            string dbPassword = userSnaposhot.Child("Password").Value.ToString();
                            string dbUsername = userSnaposhot.Child("Username").Value.ToString();

                            if (password == dbPassword && username == dbUsername)
                            {
                                Debug.Log("User Logged in with: " + dbUsername + " Account");
                                SaveUserID.Instance.UserID = userSnaposhot.Key;
                                SceneTransition?.Invoke();
                            }
                            else
                            {
                                WrongLogin?.Invoke();
                                Debug.LogError("Wrong password or Wrong username");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("User not found");
                        WrongLogin?.Invoke();
                    }
                }
                else
                {
                    Debug.Log("No Internet");
                }
            }
            else
            {
                Debug.LogError("Failed to Check");
            }
        });
    }
    //Buttons
    public void LoginAccountButton()
    {
        Login();
    }
}