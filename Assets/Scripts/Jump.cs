using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpSpeed = 240f;
    public float ForwardSpeed = 20f;
    public AudioClip Impact;
    private Rigidbody2D _body2D;
    private InputState _inputState;
    private AudioSource _audio;

	public void Awake ()
	{
	    _body2D = GetComponent<Rigidbody2D>();
	    _inputState = GetComponent<InputState>();
	    _audio = FindObjectOfType<AudioSource>();
	}
	
	void Update () {
	    if (_inputState.Standing)
	    {
	        if (_inputState.ActionButton)
	        {
	            _body2D.velocity = new Vector2(transform.position.x < 0 ? ForwardSpeed : 0, JumpSpeed);
                _audio.PlayOneShot(Impact);
	        }
	    }
	}
}
