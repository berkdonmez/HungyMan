using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private UIManager _uıManager;
    private Player _player;

    void Awake()
    {
        _uıManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void SawScore()
    {
        _uıManager.FoodScore--;
        _uıManager.PlayerScoreText.text = _uıManager.FoodScore.ToString();
        _player.MinimizingThePlayer();
    }
}
