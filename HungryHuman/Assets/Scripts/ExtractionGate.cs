using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionGate : MonoBehaviour
{
    private UIManager _u�Manager;
    private Player _player;

    [Header("Extraction Gate Score")]
    public int ExtractionTextScore;

    void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void ExtractionScore()
    {
        _u�Manager.FoodScore = _u�Manager.FoodScore - ExtractionTextScore;
        _u�Manager.PlayerScoreText.text = _u�Manager.FoodScore.ToString();
        for (int i = 0; i < ExtractionTextScore; i++)
        {
            _player.MinimizingThePlayer();
        }

    }
}
