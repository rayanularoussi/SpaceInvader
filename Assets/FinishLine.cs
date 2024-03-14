using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    SpaceshipManager spaceshipManager;
    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
