using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGate : MonoBehaviour
{
    private UIManager _u�Manager;
    private Player _player;

    [Header("Plus Gate Score")]
    public int PlusTextScore;

    void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlusScore()
    {
        _u�Manager.FoodScore = _u�Manager.FoodScore + PlusTextScore;
        _u�Manager.PlayerScoreText.text = _u�Manager.FoodScore.ToString();

        for (int i = 0; i < PlusTextScore; i++)
        {
            _player.EnLargeThePlayer();
        }

    }
}
