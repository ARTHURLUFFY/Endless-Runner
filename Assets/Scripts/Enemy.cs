using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public float speed;
    public GameObject effect;

    //public GameObject explosionSound;

    private Shake shake;


    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    private void Update()
    {

        if (FindObjectOfType<Character>().score > 100)
        {
            speed = 10;
        }
        


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            shake.CamShake();
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            //Instantiate(explosionSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            /// camera shake

            if (other.GetComponent<Character>().invisibilityTime <=0)
            {
                if (damage > other.GetComponent<Character>().health)
                    damage = other.GetComponent<Character>().health;
                other.GetComponent<Character>().health -= damage;
                other.GetComponent<Character>().invisibilityTime = 0.2f;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
