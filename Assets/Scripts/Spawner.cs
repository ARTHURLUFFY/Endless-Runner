using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPatterns;
    public GameObject[] enemy2Patterns;
    public GameObject[] enemy3Patterns;
    public GameObject[] heartPatterns;
    public GameObject[] coinPatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    public Character character;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            

            if (character.score <30)
            {
                int rand = Random.Range(0, enemyPatterns.Length);
                Instantiate(enemyPatterns[rand], transform.position, Quaternion.identity);
            }
            else
            {
                int rand1 = Random.Range(0, 1000);
                if (rand1 < 80)
                {
                int rand = Random.Range(0, heartPatterns.Length);
                Instantiate(heartPatterns[rand], transform.position, Quaternion.identity);
                }

                else if (rand1<200)
                {
                int rand = Random.Range(0, coinPatterns.Length);
                Instantiate(coinPatterns[rand], transform.position, Quaternion.identity);
                }

                else
                {
                    if (character.score<100)
                    {
                    int rand = Random.Range(0, enemyPatterns.Length);
                    Instantiate(enemyPatterns[rand], transform.position, Quaternion.identity);
                    }
                    else if (character.score < 300)
                    {
                        int rand = Random.Range(0, enemy2Patterns.Length);
                        Instantiate(enemy2Patterns[rand], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        int rand = Random.Range(0, enemy3Patterns.Length);
                        Instantiate(enemy3Patterns[rand], transform.position, Quaternion.identity);
                    }
                
                }
            }
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            { 
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
