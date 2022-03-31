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
            } else if (i == 1)
            {
                yield return new WaitForSeconds(3f);
                sources[3].clip = clips[3];
            }
        }
        else Debug.Log("Audiosource " + i + " doesn't exists!");
    }

    public void Switch003()
    {
        if (sources[3].clip != clips[3])
        {
            sources[5].Stop();
            sources[3].clip = clips[3];
        }
        
    }

    public void Switchnplay005()
    {
        if (sources[3].clip == clips[5])
        {
            sources[3].Stop();
            sources[3].clip = clips[6];
            sources[3].loop = true;
            sources[3].Play();
        }
        /*else if (sources[3].clip == clips[6])
        {
            //come ci arrivo qui?
            sources[3].clip = clips[7];
            sources[3].loop = false;
        }*/
    }

}