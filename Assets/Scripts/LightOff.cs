using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    public GameObject light;
    public int whenToDark;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Character>().score >= whenToDark)
        {
            light.SetActive(false);
        }
    }
}
