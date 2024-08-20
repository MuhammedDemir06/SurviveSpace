using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;
    [Header("Sound")]
    [SerializeField] private AudioSource clickSound;
    //Buttons
    public void SoundPlay()
    {
        clickSound.Play();
    }
}