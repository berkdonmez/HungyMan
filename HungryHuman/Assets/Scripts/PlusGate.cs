using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGate : MonoBehaviour
{
    private UIManager _uıManager;
    private Player _player;

    [Header("Plus Gate Score")]
    public int PlusTextScore;

    void Awake()
    {
        _uıManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlusScore()
    {
        _uıManager.FoodScore = _uıManager.FoodScore + PlusTextScore;
        _uıManager.PlayerScoreText.text = _uıManager.FoodScore.ToString();

        for (int i = 0; i < PlusTextScore; i++)
        {
            _player.EnLargeThePlayer();
        }

    }
}
