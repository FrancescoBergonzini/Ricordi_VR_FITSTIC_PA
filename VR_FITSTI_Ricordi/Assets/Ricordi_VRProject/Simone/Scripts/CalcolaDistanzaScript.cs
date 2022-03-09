using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Threading.Tasks;
public class CalcolaDistanzaScript : MonoBehaviour
{
    [SerializeField]Transform oggettoADistanza;
    [SerializeField]Transform secondaPosizione;
    [SerializeField] List<GameObject> oggettiDaAttivare;
    [SerializeField] List<VideoClip> videoPresa;
    [SerializeField] List<VideoClip> videoRilascia;
    [SerializeField] float distanza;
    [SerializeField] TutorialManager tutorialManager;
    [SerializeField] VideoPlayer videoPlayer;

    private bool pallaRaccolta = false;

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
        if (other.gameObject.tag == "Player" && !pallaRaccolta)
        {
            videoPlayer.clip= videoPresa[0];
            videoPlayer.Play();
            foreach (var obj in oggettiDaAttivare)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !pallaRaccolta)
        {
            videoPlayer.clip = videoPresa[1];
            videoPlayer.Play();
        }
    }

    public async void PLayVideoRilascia()
    {
        
            videoPlayer.clip = videoPresa[1];
            videoPlayer.Play();
        await Task.Delay(1500);
        var nuovaPosizione = new Vector3(secondaPosizione.position.x, secondaPosizione.position.y, secondaPosizione.position.z);
        videoPlayer.transform.position = nuovaPosizione;
        videoPlayer.transform.position = secondaPosizione.position;
            videoPlayer.clip = videoRilascia[0];
            videoPlayer.Play();
            pallaRaccolta = true;
        
        
    }

}
