using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IRecycle
{
    public Sprite[] Sprites;
    public Vector2 ColliderOffset = Vector2.zero;

    public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = Sprites[Random.Range(0,Sprites.Length)];

        var collider = GetComponent<BoxCollider2D>();
        var size = renderer.bounds.size;

        size.y += ColliderOffset.y;
        collider.size = size;
        collider.offset = new Vector2(-ColliderOffset.x,collider.size.y / 2 - ColliderOffset.y);
    }

    public void Shutdown()
    {
    }
}
