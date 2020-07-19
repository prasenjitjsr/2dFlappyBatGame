using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    private BoxCollider2D groundCollider; 
    private float groundHorizontalLength;

    private void Awake ()
    {
        groundCollider = GetComponent<BoxCollider2D> ();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
            transform.position = (Vector2) transform.position + groundOffSet;
        }
    }
}
