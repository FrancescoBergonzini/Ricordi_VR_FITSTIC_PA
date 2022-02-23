using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class AudioManagerChitarra : MonoBehaviour
    {
        AudioSource audioSource;
        [SerializeField] List<AudioClip> listNote = new List<AudioClip>();
        int indice = 0;
        bool notaSuonata = false;

        [SerializeField] Grabbable chitarraGrabbable;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "HandTrigger" && !notaSuonata)
            {
                notaSuonata = true;
                if (chitarraGrabbable.BeingHeld)
                {
                    audioSource.clip = listNote[indice];
                    audioSource.Play();
                    indice = indice + 1;
                    if (indice >= listNote.Count)
                    {
                        indice = 0;
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "HandTrigger")
            {
                notaSuonata = false;
            }
        }
    }
}
