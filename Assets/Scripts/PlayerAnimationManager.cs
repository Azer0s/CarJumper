using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _animator;
    private InputState _inputState;

	public void Awake ()
	{
	    _animator = GetComponent<Animator>();
	    _inputState = GetComponent<InputState>();
	}
	
	void Update ()
	{
	    var running = !(_inputState.AbsolutVelX > 0 && _inputState.AbsolutVelY < _inputState.StandingThreshold);

        _animator.SetBool("Running",running);
	}
}
