using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene _scene;
    [SerializeField] private AudioSource _audioSource;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Scenes/1");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("start");
        Score.lives = 3;
    }
}
