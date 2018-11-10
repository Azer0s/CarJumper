using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour
{
    public bool ActionButton;
    public bool Left;
    public bool Right;
    public float AbsolutVelX = 0f;
    public float AbsolutVelY = 0f;
    public bool Standing;
    public float StandingThreshold = 1;
    private Rigidbody2D _body2D;
    public Jump jumpScript;

    public void Awake()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
	{
	    ActionButton = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
	    Left = Input.GetKeyDown(KeyCode.LeftArrow);
	    Right = Input.GetKeyDown(KeyCode.RightArrow);
	}

    void FixedUpdate()
    {
        AbsolutVelX = System.Math.Abs(_body2D.velocity.x);
        AbsolutVelY = System.Math.Abs(_body2D.velocity.y);

        Standing = AbsolutVelY <= StandingThreshold;

        _body2D.position += Left ? Vector2.left * jumpScript.ForwardSpeed : Vector2.zero;
        _body2D.position += Right ? Vector2.right * jumpScript.ForwardSpeed : Vector2.zero;
    }
}
