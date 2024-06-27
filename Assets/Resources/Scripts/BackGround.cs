using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGround : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Vector2 cameraSize;
    Vector2 spriteSize;
    Vector2 scale;
    float cameraHeight;

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {

        cameraHeight = Camera.main.orthographicSize * 2;
        cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        spriteSize = spriteRenderer.sprite.bounds.size;

        scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.position = Vector2.zero; // Optional
        transform.position = new Vector3(0, 0, 1);
        transform.localScale = scale;
    }
}
