using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CalcolaDistanzaScript : MonoBehaviour
{
    [SerializeField]Transform oggettoADistanza;
    [SerializeField]Transform secondoPosizione;
    [SerializeField] List<GameObject> oggettiDaAttivare;
    [SerializeField] List<VideoClip> videoPresa;
    [SerializeField] List<VideoClip> videoRilascia;
    [SerializeField] float distanza;
    [SerializeField] TutorialManager tutorialManager;

    bool playerVicino=false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Distanza: " + Vector3.Distance(this.transform.position, oggettoADistanza.position));
    }

    // Update is called once per frame
    void Update()
    {

        //if (Vector3.Distance(this.transform.position, oggettoADistanza.position) < distanza && !playerVicino)
        //{
        //    playerVicino = true;
        //    foreach (var obj in oggettiDaAttivare)
        //    {
        //        obj.SetActive(true);
        //    }
        //    tutorialManager.gameObject.GetComponent<VideoPlayer>().clip = videoPresa[0];
        //    tutorialManager.gameObject.GetComponent<VideoPlayer>().Play();
        //}
        //else if(Vector3.Distance(this.transform.position, oggettoADistanza.position) > distanza)
        //{
        //    playerVicino = false;
        //    tutorialManager.gameObject.GetComponent<VideoPlayer>().clip = videoPresa[1];
        //    tutorialManager.gameObject.GetComponent<VideoPlayer>().Play();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialManager.gameObject.GetComponents<VideoPlayer>()[0].clip = videoPresa[0];
            tutorialManager.gameObject.GetComponents<VideoPlayer>()[0].Play();
            foreach (var obj in oggettiDaAttivare)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tutorialManager.gameObject.GetComponents<VideoPlayer>()[0].clip = videoPresa[1];
            tutorialManager.gameObject.GetComponents<VideoPlayer>()[0].Play();
        }
    }

    public void PLayVideoRilascia()
    {
        var videoPlayerRilascio = tutorialManager.gameObject.GetComponents<VideoPlayer>()[1];
        if (videoPlayerRilascio.clip == null)
        {
            videoPlayerRilascio.clip = videoRilascia[0];
            videoPlayerRilascio.Play();
        }
    }
}
