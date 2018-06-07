using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZoneComponent : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var audioSource = collision.gameObject.GetComponent<AudioSource>();

            if (audioSource == null)
                return;

            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
