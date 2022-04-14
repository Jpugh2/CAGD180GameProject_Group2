using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroyer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.y > 10f)
        {
            Destroy(this.gameObject);
        }
        if (GetComponent<Transform>().position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }
}
