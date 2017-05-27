using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    public Vector2 Speed = Vector2.zero;
    private Vector2 _offset = Vector2.zero;
    private Material _material;

	public void Start ()
	{
	    _material = GetComponent<Renderer>().material;
	    _offset = _material.GetTextureOffset("_MainTex");
	}
	
	public void Update ()
	{
	    _offset += Speed * Time.deltaTime;
        _material.SetTextureOffset("_MainTex",_offset);
	}
}
