using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] Blocks;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject BrokenBlocksCanvas;

    private UIManager _u�Manager;
    private Player _player;

    [Header("Broken Blocks Score")]
    public int BrokenWallScore;

    private void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
        _u�Manager.FoodScore = _u�Manager.FoodScore - BrokenWallScore;
        _u�Manager.PlayerScoreText.text = _u�Manager.FoodScore.ToString();

        for (int i = 0; i < BrokenWallScore; i++)
        {
            _player.MinimizingThePlayer();
        }
    }
}
