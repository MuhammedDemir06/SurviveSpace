using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] playerNameTexts;
    [SerializeField] private TextMeshProUGUI[] playerScoreTexts;
    void Start()
    {
        FetchTopScores();
    }
    void FetchTopScores()
    {
        DTManager.Instance.UserRef.OrderByChild("MaxScore").LimitToLast(15).GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                List<KeyValuePair<string, int>> topScores = new List<KeyValuePair<string, int>>();

                foreach (DataSnapshot userSnapshot in snapshot.Children)
                {
                    string username = userSnapshot.Child("Username").Value.ToString();
                    int score = int.Parse(userSnapshot.Child("MaxScore").Value.ToString());
                    topScores.Add(new KeyValuePair<string, int>(username, score));
                }

                // Skorlarý büyükten küçüðe sýralýyoruz (En yüksek skor baþta olacak þekilde)
                topScores.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
                for (int i = 0; i < snapshot.ChildrenCount; i++)
                {
                    playerNameTexts[i].text = topScores[i].Key.ToString();
                    playerScoreTexts[i].text = topScores[i].Value.ToString();
                }

            }
            else
            {
                Debug.LogError("Failed to fetch top scores: " + task.Exception);
            }
        });
    }

    void UpdateLeaderboardUI(List<KeyValuePair<string, int>> topScores)
    {

    }
}
