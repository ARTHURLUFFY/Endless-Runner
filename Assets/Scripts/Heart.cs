using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    //public GameObject heartSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Heart");
            //Instantiate(heartSound, transform.position, Quaternion.identity);
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            other.GetComponent<Character>().health++;
            other.GetComponent<Character>().score++;
        }
    }
}
