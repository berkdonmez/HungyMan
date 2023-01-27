using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager _u�Manager;
    private Player _player;

    void Awake()
    {
        _u�Manager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void StartTheGame()
    {
        _player.GameIsStart = true;
        _u�Manager.StartCanvas.SetActive(false);
        _player.GetComponent<Animator>().SetTrigger("Run");
    }

    public void RestartTheGame()
    {
        _u�Manager.RestartCanvas.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
