using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    SpaceshipManager spaceshipManager;
    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
    }

    void OnTriggerEnter(Collider other)
    {

        Destroy(other.gameObject);
        spaceshipManager.bulletShoted = false;
    }
}
