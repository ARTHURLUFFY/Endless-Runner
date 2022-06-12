using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    //public GameObject diamondSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Diamond");
            //Instantiate(diamondSound, transform.position, Quaternion.identity);
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            other.GetComponent<Character>().score+=5;

        }
    }
}
