using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    public float Offset = 16f;
    public delegate void OnDestroy();
    public event OnDestroy DestroyCallback;
    private bool _offScreen;
    public float _offScreenX = 0;
    private Rigidbody2D _body2D;

    public void Awake()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }

	void Start ()
	{
	    _offScreenX = (Screen.width/PixelPerfectCamera.PixelsToUnit)/2 + Offset;
	}
	
	void Update ()
	{
	    var posX = transform.position.x;
	    var dirX = _body2D.velocity.x;

	    if (Mathf.Abs(posX) > _offScreenX)
	    {
	        if (dirX < 0 && posX < -_offScreenX)
	        {
	            _offScreen = true;
	        }
            else if (dirX > 0 && posX > _offScreenX)
	        {
	            _offScreen = true;
	        }
	    }
	    else
	    {
	        _offScreen = false;
	    }

	    if (!_body2D.GetComponent<Renderer>().isVisible && posX != 0 && _body2D.CompareTag("Player"))
	    {
	        _offScreen = true;
	    }

        if (_offScreen)
	    {
	        OnOutOfBounds();
	    }
	}

    public void OnOutOfBounds()
    {
        _offScreen = false;
        GameObjectUtility.Destroy(gameObject);

        if (DestroyCallback != null)
        {
            DestroyCallback();
        }
    }
}
