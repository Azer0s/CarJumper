using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour
{
    public int TextureSize = 64;
    public bool ScaleHorizontally = true;
    public bool ScaleVertically = true;

	void Start ()
	{
	    var newWidth = !ScaleHorizontally ? 1 : (Mathf.Ceil(Screen.width / (TextureSize * PixelPerfectCamera.Scale)));
	    var newHeight = !ScaleVertically ? 1 : Mathf.Ceil(Screen.height / (TextureSize * PixelPerfectCamera.Scale));
        transform.localScale = new Vector3(newWidth * TextureSize, newHeight * TextureSize, 1);
        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight,1);
	}
}
