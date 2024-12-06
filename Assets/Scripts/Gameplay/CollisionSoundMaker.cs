using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class CollisionSoundMaker : MonoBehaviour
{
    public AudioClip[] Sounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Sounds != null && Sounds.Length > 0)
        {
            int randomIndex = RandomNumberGenerator.GetInt32(0, Sounds.Length);
            audioSource.clip = Sounds[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.Log("오디오소스를 찾을 수 없습니다.");
        }
    }
}
