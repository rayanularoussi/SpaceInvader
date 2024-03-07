using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0.01f, 0, 0);
    }
}
