using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public float speed;

    public float endX;
    public float startX;

    private void Start()
    {
        startX = GetComponent<SpriteRenderer>().bounds.size.x * 2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            transform.position = new Vector2(transform.position.x + startX -0.01f, transform.position.y);

        }
    }
}
