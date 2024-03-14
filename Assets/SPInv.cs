using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPInv : MonoBehaviour
{
    SpaceshipManager spaceshipManager;
    ScoreManager scoreManager;
    TableMove tableMove;
    public bool isSpecial = false;
    public int SPInvValue;
    public bool isShooter;
    public GameObject bulletPrefab;
    public bool isDead = false;
    private float nextShootTime;
    public float shootInterval = 5f;
    private Animator animator;
    public AudioClip shootSound;
    public AudioClip boomSound;
    private AudioSource audioSource;
    

    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        tableMove = FindObjectOfType<TableMove>();
        nextShootTime = Time.time + Random.Range(0f, shootInterval);
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    void LateUpdate()
    {
        if (!isDead && isShooter && Time.time >= nextShootTime)
        {
            ShootBullet();
            nextShootTime = Time.time + Random.Range(shootInterval * 0.5f, shootInterval * 1.5f);
            audioSource.PlayOneShot(shootSound);
        }
    }

    void ShootBullet()
    {
        Vector3 pos = transform.position;
        Instantiate(bulletPrefab, pos, transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isDead && other.gameObject.tag == "Bullet")
        {
            if(!isSpecial)
            {
                scoreManager.enemyRemaining--;
            }
            isDead = true;
            animator.Play("Explosion");
            audioSource.PlayOneShot(boomSound);
            StartCoroutine(DestroyAfterDelay(0.4f));

            Destroy(other.gameObject);
            spaceshipManager.bulletShoted = false;
            scoreManager.enemyKilledValue = SPInvValue;
            tableMove.enemyDie = true;
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
