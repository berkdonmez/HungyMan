using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _playerRb;
    private UIManager _uýManager;
    private PlusGate _plusGate;
    private DivisionGate _divisionGate;
    private MultiplicationGate _multiplicationGate;
    private ExtractionGate _extractionGate;
    private SoundLibrary _audioManager;
    private Saw _saw;
    private Animator _anim;
    private Camera _cam;

    [Header("Movement Settings")]
    public float PlayerForwardSpeed;
    public float PlayerHorizontalSpeed;

    [Header("Grow Up Settings")]
    public float GrowingRange = 0.05f;

    [Header("Start Game Controller")]
    public bool GameIsStart;

    [Header("Victory Object")]
    public GameObject Cup;

    [Header("Particle System")]
    public ParticleSystem ConfettiPS;


    void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _uýManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _anim = GetComponent<Animator>();
        _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        _plusGate = GameObject.Find("PlusGate").GetComponent<PlusGate>();
        _divisionGate = GameObject.Find("DivisionGate").GetComponent<DivisionGate>();
        _multiplicationGate = GameObject.Find("MultiplicationGate").GetComponent<MultiplicationGate>();
        _extractionGate = GameObject.Find("ExtractionGate").GetComponent<ExtractionGate>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<SoundLibrary>();
        _saw = GameObject.Find("Saw").GetComponent<Saw>();
    }


    void FixedUpdate()
    {
        if (GameIsStart == true)
        {
            MovePlayerForward();
        }
    }

    private void Update()
    {
        if (GameIsStart == true)
        {
            MovePlayerHorizontal();
        }

        if (_uýManager.FoodScore < 0)
        {
            DieAnim();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.GameOverAudio);
            _uýManager.FoodScore = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Magnification"))
        {
            other.gameObject.SetActive(false);
            _uýManager.PlayerScoreCounter();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.PopAudio);
            Debug.Log("touched");
        }

        else if (other.gameObject.CompareTag("Plus"))
        {
            other.gameObject.SetActive(false);
            _plusGate.PlusScore();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.PositiveAudio);
        }

        else if (other.gameObject.CompareTag("Division"))
        {
            other.gameObject.SetActive(false);
            _divisionGate.DivisionScore();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.NegativeAudio);
        }

        else if (other.gameObject.CompareTag("Multiplication"))
        {
            other.gameObject.SetActive(false);
            _multiplicationGate.MultiplicationScore();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.PositiveAudio);
        }

        else if (other.gameObject.CompareTag("Extraction"))
        {
            other.gameObject.SetActive(false);
            _extractionGate.ExtractionScore();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.NegativeAudio);
        }

        else if (other.gameObject.CompareTag("TriggerVictoryAnim"))
        {
            GameIsStart = false;
            _uýManager.ScoreCanvas.SetActive(false);
            Cup.SetActive(true);
            _anim.SetTrigger("TriggerVictory");
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.WinAudio);
            ConfettiPS.Play(ConfettiPS);
            _uýManager.WinCanvas.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Saw"))
        {
            _saw.SawScore();
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.HurtAudio);
        }

        else if (collision.gameObject.CompareTag("BrokenBlock"))
        {
            _cam.GetComponent<AudioSource>().PlayOneShot(_audioManager.BrokenWallAudio);
        }
    }

    public void MovePlayerForward()
    {
        _playerRb.velocity = Vector3.forward * PlayerForwardSpeed;
    }

    public void MovePlayerHorizontal()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - PlayerHorizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z), 1f);
            }

            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + PlayerHorizontalSpeed * Time.deltaTime, transform.position.y, transform.position.z), 1f);
            }
        }
    }

    public void EnLargeThePlayer()
    {
        transform.localScale = new Vector3(transform.localScale.x + GrowingRange, transform.localScale.y + GrowingRange, transform.localScale.z + GrowingRange);
    }

    public void MinimizingThePlayer()
    {
        transform.localScale = new Vector3(transform.localScale.x - GrowingRange, transform.localScale.y - GrowingRange, transform.localScale.z - GrowingRange);
    }

    public void DieAnim()
    {
        GameIsStart = false;
        _uýManager.ScoreCanvas.SetActive(false);
        _uýManager.RestartCanvas.SetActive(true);
        _anim.SetTrigger("Die");
    }

}
