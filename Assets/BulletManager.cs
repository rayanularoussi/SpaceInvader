using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public int direction = 1;

    void Update()
    {
        transform.position += new Vector3(0, direction * 0.04f, 0);
    }
}
