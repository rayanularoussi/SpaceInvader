using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceshipManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool bulletShoted = false;
    private int lives = 3;
    public TMP_Text livesText;
    public GameObject life1;
    public GameObject life2;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !bulletShoted)
        {
            Vector3 pos = transform.position;
            GameObject instance = Instantiate(bulletPrefab, pos, transform.rotation);
            bulletShoted = true;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.01f, 0, 0);
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
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
            lives--;
            LivesUpdate();
            animator.Play("shield");
        }
    }
}
