using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



namespace BNG
{
    public class BallerinaManager : MonoBehaviour
    {
        [SerializeField] Transform midAirPoint;
        [SerializeField] Transform[] pezziPos;

        MeshRenderer _myMeshRender;
        static int statoPezziPresi = 0;
        

        [SerializeField] GameObject[] oggettiDopoTesta;
        [SerializeField] GameObject[] oggettiDopoBraccio;
        [SerializeField] GameObject[] oggettiDopoGamba;

        private void Start()
        {
            _myMeshRender = GetComponent<MeshRenderer>();
            HideInteractionObjs(oggettiDopoTesta);
            HideInteractionObjs(oggettiDopoBraccio);
            HideInteractionObjs(oggettiDopoGamba);
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogWarning("1");
            if (!other.TryGetComponent(out PezzoBambola pezzo))
            {              
                return;
            }
            else
            {
                if (other.gameObject.tag == "Bambola" && statoPezziPresi == (int)pezzo.myself)
                {
                    Debug.LogWarning("2");

                    Rigidbody obj_rb = other.gameObject.GetComponent<Rigidbody>();

                    Debug.Log("Parte il tween");
                    obj_rb.isKinematic = true;
                    other.enabled = false;
                    other.transform.DOMove(midAirPoint.transform.position, 4f).OnComplete(() =>
                    other.transform.DOMove(pezziPos[(int)pezzo.myself].position, 4f));
                    other.transform.DOScale(1, 2);

                    //aggiorno la lo stato interno 
                    statoPezziPresi++;
                    CustomActions();
                    /*if (OnPieceDropped != null)
                        OnPieceDropped.Invoke();*/
                }
            }
                

            // l'oggetto per un attimo cade, sistemare questa cosa
           
        }

   

        public  void EnableMeshRendere(bool fallo)
        {
            _myMeshRender.enabled = fallo;
        }

        public void CustomActions()
        {
            Debug.LogError($"Pezzi presi: {statoPezziPresi}");
            CoseCheAccadonoPerPezzo(statoPezziPresi);
            
        }

        void CoseCheAccadonoPerPezzo(int pezziPresi)
        {
         
            Debug.Log("Accendo il Braccio"); 
            switch (statoPezziPresi)
            {
                case 1:
                  foreach(GameObject obj in oggettiDopoTesta)
                  {
                        obj.SetActive(true);
                        //add force al libro
                        //accendo luce
                        //accendo pezzo
                  }
                    break;
                case 2:
                    foreach (GameObject obj in oggettiDopoBraccio)
                    {
                        obj.SetActive(true);
                        // partire musica giradischi
                        //accendo il pezzo della gamba
                        // quando alzo il pezzo preso, nuova musica
                    }

                    break;
                case 3:
                    foreach (GameObject obj in oggettiDopoGamba)
                    {
                        obj.SetActive(true);
                    }
                    break;
                case 4:
                    int currentScene = SceneManager.GetActiveScene().buildIndex;
                    SceneManagerScript.ChangeScene(currentScene+1);
                    break;

            }


        }
        void CoseCheAccadonoPerPezzo2()
        {
            
        }

        void CoseCheAccadonoPerPezzo3()
        {
            //animazione finestre
            //audio finestre che sbatono + giocattoli
            //esplosione giocattoli
            //accendi pezzo gonna
            // dopo che ho posizionato l'oggetto senzo il suono della porta che viene sbloccata ---> deve aprirla per andare nella terza scena
        }
        private void HideInteractionObjs(GameObject[] array)
        {
            foreach (GameObject obj in array)
            {
                obj.SetActive(false);
            }
        }
    }

 
}



