using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private UIManager _u�Manager;
    private Player _player;

    void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void SawScore()
    {
        _u�Manager.FoodScore--;
        _u�Manager.PlayerScoreText.text = _u�Manager.FoodScore.ToString();
        _player.MinimizingThePlayer();
    }
}
