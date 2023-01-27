using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private Transform _player;

    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        FollowThePlayerTransform();
    }

    private void FollowThePlayerTransform()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z);
    }
}
