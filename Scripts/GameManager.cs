using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ganeOverPanel;
    private int _playerScore;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private GameObject _pauseBtn, _resumeBtn;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private AudioSource _audioClip;
    [SerializeField]
    private GameObject _player;
    [ContextMenu("Increase Score")]
    private void Start()
    {
        Time.timeScale = 1;
        _audioClip = GetComponent<AudioSource>();
        if(_audioClip == null)
        {
            Debug.LogError("AudioSource is not assigned with the componenet!!");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Resume();
        }
    }
    public void addScore()
    {
        PlayAudio();
        _playerScore += 10;
        _scoreText.text = _playerScore.ToString();
        Debug.Log(_playerScore);
    }
    public void GameOver()
    {
        _ganeOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        _pausePanel.SetActive(true);
        SetPlayerTransparency(0);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        _pausePanel.SetActive(false);
        SetPlayerTransparency(1f);
        Time.timeScale = 1;
    }
    void PlayAudio()
    {
        if(_audioClip != null)
        {
            _audioClip.Play();
        }
    }
    private void SetPlayerTransparency(float alpha)
    {
        SpriteRenderer playerRenderer = _player.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            Color color = playerRenderer.color;
            color.a = alpha;
            playerRenderer.color = color;
        }
        else
        {
            Debug.LogError("Player does not have a SpriteRenderer component!");
        }
    }
}
