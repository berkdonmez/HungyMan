using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Player _player;

    [Header("Food Score Settings")]
    public int FoodScore;
    public TextMeshProUGUI PlayerScoreText;

    [Header("Canvas Settings")]
    public GameObject RestartCanvas;
    public GameObject WinCanvas;
    public GameObject StartCanvas;
    public GameObject ScoreCanvas;

    void Awake()
    {
        FoodScore = 0;
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayerScoreCounter()
    {
        FoodScore++;
        PlayerScoreText.text = FoodScore.ToString();
        _player.EnLargeThePlayer();
    }

}
