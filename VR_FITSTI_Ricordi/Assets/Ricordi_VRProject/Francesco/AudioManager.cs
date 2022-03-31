using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

    public class AudioManager : MonoBehaviour
    {
    
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

            
            DontDestroyOnLoad(gameObject);
        }

    public void PlayAudioSource(int i, float t)
    {
        StartCoroutine(playaudiosource(i, t));
    }

    IEnumerator playaudiosource(int i, float t)
    {
        yield return new WaitForSeconds(t);
        if (i < 7 && sources[i] != null)
        {
            sources[i].Play();
            if (i == 3)
            {
                yield return new WaitForSeconds(5.7f);
                Switchnplay005();
            }
            else if (i == 1)
            {
                yield return new WaitForSeconds(3f);
                Switchnplay003();
            }
            else Debug.Log("Audiosource " + i + " doesn't exists!");
        }
    }

    public void Switchnplay003()
    {
        sources[3].clip = clips[3];
        sources[3].Play();
    }

    public void Switchnplay005()
    {
        if (sources[5].clip == clips[5])
        {
            sources[5].clip = clips[6];
            sources[5].loop = true;
        }
        else
        {
            //come ci arrivo qui?
            sources[5].clip = clips[7];
            sources[5].loop = false;
        }
            sources[5].Play();
    }

}