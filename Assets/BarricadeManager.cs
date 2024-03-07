using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeManager : MonoBehaviour
{
    int stage = 3;
    public GameObject stageFull;
    public GameObject stageHalf;
    public GameObject stageThird;
    SpaceshipManager spaceshipManager;

    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
    }
    void Update()
    {
        if(stage >= 0)
        {
            if(stage == 2)
            {
                Destroy(stageFull);
            }
            else if(stage == 1)
            {
                Destroy(stageHalf);
            }
            else if(stage == 0)
            {
                Destroy(gameObject);
                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            spaceshipManager.bulletShoted = false;
            stage--;
        }
    }
}
