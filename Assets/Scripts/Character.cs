using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
public class Character : MonoBehaviour
{
    private Vector2 targetPos;
    public float movement;
    public float speed;
    public float maxHeight;
    public int health;

    public GameObject effectUp;
    public GameObject effectDown;

    //public Text healthDisplay;
    public Text scoreDisplay;
    public TextMeshPro scoreDisp;

    public int score;

    public GameObject heart1, heart2, heart3, heart4, heart5;
    public GameObject gameOver;
    //public GameObject moveSound;

    private float timeUntilMove;
    public float startTimeUntilMove;
    public float invisibilityTime = 0.2f;

    [HideInInspector]
    public int highScore;
    [HideInInspector]
    public int continues=1;

    private void Start()
    {
        targetPos = transform.position;
        timeUntilMove = startTimeUntilMove;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilMove -= Time.deltaTime;
        invisibilityTime -= Time.deltaTime;
        //healthDisplay.text = health.ToString();
        scoreDisplay.text = score.ToString();

        if (health > 5)
            health = 5;

        switch (health)
        {
            case 5:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;

            case 4:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(false);
                break;

            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                if (continues >= 1)
                {
                    Time.timeScale = 0;
                    gameOver.SetActive(true);
                }
                else
                    FindObjectOfType<GameManager>().Restart();
                //Destroy(gameObject);
                break;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

       


    }




    public void Score()
    {
        score++;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void MoveUp()
    {
        if (transform.position.y < maxHeight && timeUntilMove <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerMove");
            //Instantiate(moveSound, transform.position, Quaternion.identity);
            Instantiate(effectUp, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + movement);
            timeUntilMove = startTimeUntilMove;
        }
    }

    public void MoveDown()
    {
        if (transform.position.y > -maxHeight && timeUntilMove <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerMove");
            //Instantiate(moveSound, transform.position, Quaternion.identity);
            Instantiate(effectDown, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - movement);
            timeUntilMove = startTimeUntilMove;
        }
        
    }
}
