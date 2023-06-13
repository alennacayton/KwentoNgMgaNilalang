using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] AudioClip inventoryOpen;
    [SerializeField] AudioClip inventoryClose;

    [SerializeField] AudioClip almanacOpen;
    [SerializeField] AudioClip almanacClose;

    [SerializeField] List<AudioClip> almanacPageTurning = new List<AudioClip>();

    [SerializeField] AudioClip chestOpen;

    [SerializeField] AudioClip pickupItem;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayInventoryClick(bool isOpening)
    {
        if (isOpening)
        {
            PlayAudioClip(inventoryOpen);
        }
        else
        {
            PlayAudioClip(inventoryClose);
        }
    }

    public void PlayAlmanacClick(bool isOpening)
    {
        if (isOpening)
        {
            PlayAudioClip(almanacOpen);
        }
        else
        {
            PlayAudioClip(almanacClose);
        }
    }

    public void PlayTurnAlmanacPage()
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(almanacPageTurning.Count);

        PlayAudioClip(almanacPageTurning[randomIndex]);
    }

    public void PlayOpenChest()
    {
        PlayAudioClip(chestOpen);
    }

    public void PlayPickupItem()
    {
        PlayAudioClip(pickupItem);
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
