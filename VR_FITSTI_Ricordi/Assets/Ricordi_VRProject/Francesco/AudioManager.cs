using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

    public class AudioManager : MonoBehaviour
    {
    /*
        public enum AudioType
        {
            None =0,

            suonoEsempio,
            cadutaLibro

            //qua nomi dei suoni da eseguire
            
        }
        
        [System.Serializable]
        public class SoundLibrary
        {
            public AudioType type;

            public AudioClip clip;
            [Range(0, 1)]
            public float volume;
            [Range(0.1f, 3f)]
            public float pitch;

            public bool loop;

           
            public AudioSource source;
        }*/


    //public SoundLibrary[] sounds;
        public AudioClip[] clips;
        public AudioSource[] sources;

        public static AudioManager Instance;

        private void Awake()
        {
            //singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            //
            DontDestroyOnLoad(gameObject);

           /* foreach (SoundLibrary s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }*/
        }

    public void PlayAudioSource(int i)
    {
        if (i < 7 && sources[i] != null) sources[i].Play();        
        else Debug.Log("Audiosource " + i + " doesn't exists!");
    }

    public void Switchnplay003()
    {
        sources[3].clip = clips[3];
        sources[3].Play();
    }

    public void Switchnplay005()
    {
        if (sources[5].clip == clips[5]) sources[5].clip = clips[6];
        else sources[5].clip = clips[7];
        sources[5].Play();
    }

    /*public void Play(AudioType type)
    {
        SoundLibrary sound = null;

        foreach (SoundLibrary s in sounds)
        {
            if (s.type == type)
            {
                sound = s;
            }
        }

        if (sound != null)
        {
            sound.source.Play();

        }
        else
        {
            Debug.LogWarning("Errore, nessun suono con questo nome");
            return;
        }
    }*/
}