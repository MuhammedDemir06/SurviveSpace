using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class MaxScoreManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameUIManager.MaxScoreSave += LoadMaxScore;
    }
    private void OnDisable()
    {
        GameUIManager.MaxScoreSave -= LoadMaxScore;
    }
    private void Start()
    {
        Debug.Log(SaveUserID.Instance.UserID);
    }
        
    private void LoadMaxScore()
    {
        DTManager.Instance.UserRef.Child(SaveUserID.Instance.UserID).Child("MaxScore").SetValueAsync(GameUIManager.Instance.MaxScore).ContinueWithOnMainThread(updateTask =>
        {
            if (updateTask.IsCompleted)
            {
                Debug.Log("Score updated successfully.");
            }
            else
            {
                Debug.LogError("Failed to update score: " + updateTask.Exception);
            }
        });
        //
    }
}






