using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private const float _boundary = 1.6f;

    void Update()
    {
        PlayerLimit();
    }

    private void PlayerLimit()
    {
        if (transform.position.x > _boundary)
        {
            transform.position = new Vector3(_boundary, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < -_boundary)
        {
            transform.position = new Vector3(-_boundary, transform.position.y, transform.position.z);
        }
    }

}
