using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{

    public Button Play;
    public Button ToggleSoundButton;
    private bool _sound = true;

	// Use this for initialization
	void Start ()
    {
		Play.onClick.AddListener(PlayGame);
        ToggleSoundButton.onClick.AddListener(ToggleSound);
        _sound = AudioListener.volume > 0;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameStaging");
    }

    public void ToggleSound()
    {
        AudioListener.volume = _sound ? 0 : 1;
        _sound = !_sound;
    }
}
