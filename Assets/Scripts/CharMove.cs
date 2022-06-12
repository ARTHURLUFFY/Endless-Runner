using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour
{
    public float maxTime;
    public float minSwipeDistance;

    private float startTime;
    private float endTime;

    Vector3 startPos;
    Vector3 endPos;

    private float swipeDistance;
    private float swipeTime;

    bool swipe = false;
    bool button = true;

    public Text controlText;

    // Start is called before the first frame update
    void Start()
    {
        
        if (swipe)
            controlText.text = "Swipe";
        else if (button)
            controlText.text = "Buttons";
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >0 && swipe)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDistance)
                {
                    Swipe();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FindObjectOfType<Character>().MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindObjectOfType<Character>().MoveDown();
        }
    }

    void Swipe()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs (distance.y) > Mathf.Abs(distance.x))
        {
            if (distance.y >0)
            {
                FindObjectOfType<Character>().MoveUp();
            }
            else if (distance.y <0)
            {
                FindObjectOfType<Character>().MoveDown();
            }

        }
    }

    public void ChangeControl ()
    {
        if (!swipe && button)
        {
            swipe = true;
            button = false;
            controlText.text = "Swipe";
        }
        else if (swipe && !button)
        {
            
            swipe = false;
            button = true;
            controlText.text = "Buttons";
        }
    }
}
