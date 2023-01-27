using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionGate : MonoBehaviour
{
    private UIManager _u�Manager;
    private Player _player;

    [Header("Division Gate Score")]
    public int DivisionTextScore;

    void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void DivisionScore()
    {
        _u�Manager.FoodScore = _u�Manager.FoodScore / DivisionTextScore;
        _u�Manager.PlayerScoreText.text = _u�Manager.FoodScore.ToString();

        for (int i = 0; i < DivisionTextScore; i++)
        {
            _player.MinimizingThePlayer();
        }

    }
}
