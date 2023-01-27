using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionGate : MonoBehaviour
{
    private UIManager _uýManager;
    private Player _player;

    [Header("Extraction Gate Score")]
    public int ExtractionTextScore;

    void Awake()
    {
        _uýManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void ExtractionScore()
    {
        _uýManager.FoodScore = _uýManager.FoodScore - ExtractionTextScore;
        _uýManager.PlayerScoreText.text = _uýManager.FoodScore.ToString();
        for (int i = 0; i < ExtractionTextScore; i++)
        {
            _player.MinimizingThePlayer();
        }

    }
}
