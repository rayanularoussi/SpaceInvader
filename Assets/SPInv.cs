using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPInv : MonoBehaviour
{
    SpaceshipManager spaceshipManager;
    ScoreManager scoreManager;
    TableMove tableMove;
    public int SPInvValue;
    public bool isShooter;
    public GameObject bulletPrefab;
    private float nextShootTime;
    public float shootInterval = 5f;

    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        tableMove = FindObjectOfType<TableMove>();
        nextShootTime = Time.time + Random.Range(0f, shootInterval);
    }

    void LateUpdate()
    {
        if (isShooter && Time.time >= nextShootTime)
        {
            ShootBullet();
            nextShootTime = Time.time + Random.Range(shootInterval * 0.5f, shootInterval * 1.5f);
        }
    }

    void ShootBullet()
    {
        Vector3 pos = transform.position;
        Instantiate(bulletPrefab, pos, transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spaceshipManager.bulletShoted = false;
            scoreManager.enemyKilledValue = SPInvValue;
            tableMove.enemyDie = true;
        }
    }
}
