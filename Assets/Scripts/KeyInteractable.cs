using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour
{
    [SerializeField] private AudioClip keySound;
    private KeyCounter keyCounter;

    private void OnTriggerEnter(Collider other)
    {
        keyCounter = other.GetComponent<KeyCounter>();
        if (other.GetComponent<PlayerController>() != null)
        {
            keyCounter.KeyFound.Invoke();
            other.GetComponent<AudioSource>().PlayOneShot(keySound);
            gameObject.SetActive(false);
        }
    }
}
