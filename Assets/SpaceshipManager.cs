using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceshipManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool bulletShoted = false;
    private int lives = 3;
    public TMP_Text livesText;
    public GameObject life1;
    public GameObject life2;
    private Animator animator;
    public AudioClip shootSound;
    public AudioClip boomSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && !bulletShoted)
        {
            Vector3 pos = transform.position;
            GameObject instance = Instantiate(bulletPrefab, pos, transform.rotation);
            audioSource.PlayOneShot(shootSound);
            animator.Play("Shoot");
            bulletShoted = true;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(-0.02f, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.02f, 0, 0);
        }
    }
    void LivesUpdate()
    {
        livesText.text = lives.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            if(lives == 3)
            {
                life1.SetActive(false);
            }
            else if(lives == 2)
            {
                life2.SetActive(false);
            }
            else
            {
                StartCoroutine(LoadNextSceneAfterDelay(0.5f));
            }
            Destroy(other.gameObject);
            lives--;
            LivesUpdate();
            audioSource.PlayOneShot(boomSound);
            animator.Play("shield");
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Credits");
    }
}
