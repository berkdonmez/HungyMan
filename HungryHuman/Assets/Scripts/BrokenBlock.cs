using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] Blocks;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject BrokenBlocksCanvas;

    private UIManager _uýManager;
    private Player _player;

    [Header("Broken Blocks Score")]
    public int BrokenWallScore;

    private void Awake()
    {
        _uýManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            block.SetActive(false);
            BrokenBlocksCanvas.SetActive(false);

            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].transform.parent = null;
                Blocks[i].GetComponent<Rigidbody>().isKinematic = false;
                Destroy(Blocks[i],4f);
            }

            BrokenBlocks();
        }
    }

    public void BrokenBlocks()
    {
        _uýManager.FoodScore = _uýManager.FoodScore - BrokenWallScore;
        _uýManager.PlayerScoreText.text = _uýManager.FoodScore.ToString();

        for (int i = 0; i < BrokenWallScore; i++)
        {
            _player.MinimizingThePlayer();
        }
    }
}
