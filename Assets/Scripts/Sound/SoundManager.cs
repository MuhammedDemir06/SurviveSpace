using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds Of In Scene")]
    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private TextMeshProUGUI soundText;
    private int soundIndex;
    private bool sound;

    private void Start()
    {
        soundIndex = PlayerPrefs.GetInt("Sound");
        if (soundIndex == 0)
            sound = true;
        else
            sound = false;
    }
    private void SoundsVolume()
    {
        foreach (var sound in sounds)
        {
            if (soundIndex == 0)
                sound.volume = 1f;
            else if (soundIndex == 1)
                sound.volume = 0f;
        }
    }
    private void SoundText()
    {
        switch (soundIndex)
        {
            case 0:
                soundText.text = "Sound:On";
                break;
            case 1:
                soundText.text = "Sound:OFF";
                break;
        }
    }
    private void Update()
    {
        SoundsVolume();
        SoundText();
    }
    //Buttons
    public void SoundButton()
    {
        sound = !sound;
        switch(sound)
        {
            case true:
                soundIndex = 0;
                soundText.text = "Sound:On";
                PlayerPrefs.SetInt("Sound", soundIndex);         
                break;
            case false:
                soundIndex = 1;
                soundText.text = "Sound:OFF";
                PlayerPrefs.SetInt("Sound", soundIndex);
                break;
        }
    }
}
