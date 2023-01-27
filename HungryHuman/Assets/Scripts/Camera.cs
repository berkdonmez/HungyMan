using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Player _player;
    private Vector3 _offset = new Vector3(0, 3.6f, -3.8f);

    [Header("Follow Object")]
    public Transform PlayerTransform;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void LateUpdate()
    {
        if (_player.GameIsStart == true)
        {
            FollowThePlayer();
        }
    }

    public void FollowThePlayer()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTransform.position + _offset, Time.deltaTime);
    }

}
