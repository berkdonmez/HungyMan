using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationGate : MonoBehaviour
{
    private UIManager _u�Manager;
    private Player _player;

    [Header("Multiplication Gate Score")]
    public int MultiplicationTextScore;

    void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void MultiplicationScore()
    {
        _u�Manager.FoodScore = _u�Manager.FoodScore * MultiplicationTextScore;
        _u�Manager.PlayerScoreText.text = _u�Manager.FoodScore.ToString();

        for (int i = 0; i < MultiplicationTextScore; i++)
        {
            _player.EnLargeThePlayer();
        }

    }
}
