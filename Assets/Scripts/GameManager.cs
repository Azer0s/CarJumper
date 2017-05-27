using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Text ContinueText;
    public Text ScoreText;
    public float BlinkTime = 0f;

    private float _timeElapsed = 0f;
    private float _bestTime = 0f;
    private bool _blink;
    private bool _gameStarted;
    private Spawner _spawner;
    private GameObject _player;
    private TimeManager _timeManager;
    private bool _beatBestTime;

    public void Awake()
    {
        _spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        _timeManager = GetComponent<TimeManager>();
    }

	void Start ()
	{
	    _spawner.Active = false;
	    Time.timeScale = 0;
	    ContinueText.text = "PRESS SPACE OR CLICK TO START";

	    _bestTime = PlayerPrefs.GetFloat("BestTime");
	}
	
	void Update () {
	    if (!_gameStarted && Time.timeScale == 0)
	    {
	        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
	        {
	            _timeManager.ManipulateTime(1,1f);
                ResetGame();
	        }
	    }

	    if (!_gameStarted)
	    {
	        BlinkTime++;

	        if (BlinkTime % 40 == 0)
	        {
	            _blink = !_blink;
	        }

	        ContinueText.canvasRenderer.SetAlpha(_blink ? 0 : 1);

	        var textColour = _beatBestTime ? "#FF0" : "#FFF";

	        ScoreText.text = "TIME: " + FormatTime(_timeElapsed) + "\n<color=" + textColour + ">BEST: " + FormatTime(_bestTime) + "</color>";
	    }
	    else
	    {
	        _timeElapsed += Time.deltaTime;
	        ScoreText.text = "TIME: " + FormatTime(_timeElapsed);
	    }
    }

    public void OnPlayerKilled()
    {
        _spawner.Active = false;
        var playerDestroyScript = _player.GetComponent<DestroyOffScreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        _timeManager.ManipulateTime(0,5.5f);
        _gameStarted = false;

        ContinueText.text = "PRESS SPACE OR CLICK TO RESTART";

        if (_timeElapsed > _bestTime)
        {
            _bestTime = _timeElapsed;
            PlayerPrefs.SetFloat("BestTime",_bestTime);
            _beatBestTime = true;
        }
    }

    public void ResetGame()
    {
        _player = GameObjectUtility.Instantiate(PlayerPrefab,new Vector3(0, (Screen.height / PixelPerfectCamera.PixelsToUnit) / 2,0));
        _spawner.Active = true;

        var playerDestroyScript = _player.GetComponent<DestroyOffScreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        _gameStarted = true;

        ContinueText.canvasRenderer.SetAlpha(0);

        _timeElapsed = 0;

        _beatBestTime = false;
    }

    public string FormatTime(float value)
    {
        var t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}",t.Minutes,t.Seconds);
    }
}
