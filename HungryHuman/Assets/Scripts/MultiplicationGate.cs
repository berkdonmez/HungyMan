using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationGate : MonoBehaviour
{
    private UIManager _uıManager;
    private Player _player;

    [Header("Multiplication Gate Score")]
    public int MultiplicationTextScore;

    void Awake()
    {
        _uıManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void MultiplicationScore()
    {
        _uıManager.FoodScore = _uıManager.FoodScore * MultiplicationTextScore;
        _uıManager.PlayerScoreText.text = _uıManager.FoodScore.ToString();

        for (int i = 0; i < MultiplicationTextScore; i++)
        {
            _player.EnLargeThePlayer();
        }

    }
}
