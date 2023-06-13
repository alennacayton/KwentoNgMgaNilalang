using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource music;

    [SerializeField]
    AudioClip backgroundMusic;
    [SerializeField]
    AudioClip levelOneMusic;
    [SerializeField]
    AudioClip levelTwoMusic;
    [SerializeField]
    AudioClip levelThreeMusic;
    [SerializeField]
    AudioClip levelFourMusic;
    [SerializeField]
    AudioClip combatMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        music.clip = backgroundMusic;
        music.Play();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            music.Stop();
    }
}
