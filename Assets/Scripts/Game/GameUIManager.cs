using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUIManager : MonoBehaviour
{
    public static Action Fire;
    public static Action DontFire;
    public static Action MaxScoreSave;

    public static GameUIManager Instance;

    [SerializeField] private SpaceshipController shipManager;
    [Header("Score")]
    public int Score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [Header("Health")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthValueText;
    [HideInInspector] public int HealthValue;
    [Header("Lost")]
    [SerializeField] private GameObject lostScreen;
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseButton;
    [Header("Max Score")]
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI newHighScoreText;
    public int MaxScore;
    [Header("Sounds")]
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource fireSound;
    private void Start()
    {
        Instance = this;
    }
    private void ScoreUpdate()
    {
        scoreText.text = "Score:" + Score.ToString();
    }
    public void HealthUpdate()
    {
        healthValueText.text = "%" + HealthValue.ToString();
        healthBar.fillAmount = HealthValue / 100f;
    }
    private void GameLost()
    {
        if(shipManager.IsDead)
        {
            lostScreen.SetActive(true);
            if(Score>MaxScore)
            {
                MaxScore = Score;
                newHighScoreText.gameObject.SetActive(true);
                maxScoreText.text = "Max Score:" + MaxScore.ToString();
            }
        }
    }
    private void Update()
    {
        ScoreUpdate();
        GameLost();
    }
    //Buttons
    public void SoundPlay()
    {
        clickSound.Play();
    }
    public void RestartButton()
    {
        if (MaxScore == Score)
        {
            MaxScoreSave?.Invoke();
            print("kfdfdjkf");
        }
    }
    public void MenuButton()
    {
        if (MaxScore == Score)
        {
            MaxScoreSave?.Invoke();
        }
    }
    public void PauseButton()
    {
        GameManager.Instance.IsPause = true;
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void BackButton()
    {
        GameManager.Instance.IsPause = false;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void FireButton(int fireIndex)
    {
        if(fireIndex==0)
        {
            fireSound.Play();
            Fire?.Invoke();
        }     
        if (fireIndex == 1)
        {
            fireSound.Stop();
            DontFire?.Invoke();
        }     
    }
    public void SpaceshipControlButton(float index) //0=right //1=left//2=Idle
    {
        shipManager.GetInput(index);
    }
}
