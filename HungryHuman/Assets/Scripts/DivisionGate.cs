using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionGate : MonoBehaviour
{
    private UIManager _uýManager;
    private Player _player;

    [Header("Division Gate Score")]
    public int DivisionTextScore;

    void Awake()
    {
        _uýManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void DivisionScore()
    {
        _uýManager.FoodScore = _uýManager.FoodScore / DivisionTextScore;
        _uýManager.PlayerScoreText.text = _uýManager.FoodScore.ToString();

        for (int i = 0; i < DivisionTextScore; i++)
        {
            _player.MinimizingThePlayer();
        }

    }
}
