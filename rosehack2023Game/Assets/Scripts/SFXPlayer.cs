using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip breakCrate;
    [SerializeField] AudioClip pickupCrate;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBreakCrateSFX()
    {
        audioSource.PlayOneShot(breakCrate);
    }
    public void PlayPickupCrateSFX()
    {
        audioSource.PlayOneShot(pickupCrate);
    }
}
