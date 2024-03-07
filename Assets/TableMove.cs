using System.Collections;
using UnityEngine;

public class TableMove : MonoBehaviour
{
    int moveValue = 12;
    int direction = 1;
    float speedTime = 1f;
    public bool enemyDie = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    void Update()
    {
        if(enemyDie)
        {
            enemyDie = false;
            speedTime /= 1.02f;
        }
    }

    IEnumerator Movement()
    {
        while (true)
        {
            if (moveValue > 24)
            {
                direction = -direction;
                transform.position += new Vector3(0, -0.5f, 0);
                moveValue = 0;
            }
            else
            {
                transform.position += new Vector3(direction * 0.25f, 0, 0);
                moveValue++;
            }

            yield return new WaitForSeconds(speedTime);
        }
    }
}
