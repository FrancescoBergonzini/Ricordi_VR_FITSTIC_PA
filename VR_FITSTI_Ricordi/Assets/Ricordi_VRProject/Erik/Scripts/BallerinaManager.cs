using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;



namespace BNG
{
    public class BallerinaManager : MonoBehaviour
    {
        [SerializeField] Transform midAirPoint;
        [SerializeField] Transform[] pezziPos;

        MeshRenderer _myMeshRender;
        static int statoPezziPresi = 0;
        [SerializeField] UnityEvent OnPieceDropped;

        [SerializeField] GameObject[] oggettiDopoTesta;
        [SerializeField] GameObject[] oggettiDopoBraccio;
        [SerializeField] GameObject[] oggettiDopoGamba;

        private void Start()
        {
            _myMeshRender = GetComponent<MeshRenderer>();
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
                    if (OnPieceDropped != null)
                        OnPieceDropped.Invoke();
                }
            }
                

            // l'oggetto per un attimo cade, sistemare questa cosa
           
        }

       /* private void Update()
        {
            if (PezzoBambola.oneOfAsIsGrabbed)
            {
                cilindermat.color = Color.yellow;
                
            }
            else
            {
                cilindermat.color = Color.blue;
            }
        }*/

        public  void EnableMeshRendere(bool fallo)
        {
            _myMeshRender.enabled = fallo;
        }

        public void CustomActions()
        {
            switch (statoPezziPresi)
            {
                case 1:
                    CoseCheAccadonoPerPezzo1();
                    break;
                case 2:
                    CoseCheAccadonoPerPezzo2();
                    break;
                case 3:
                    CoseCheAccadonoPerPezzo3();
                    break;
                 
            }
        }

        void CoseCheAccadonoPerPezzo1()
        {
            //add force al libro
            //accendo luce
            //accendo pezzo
            Debug.Log("Accendo il Braccio");
        }
        void CoseCheAccadonoPerPezzo2()
        {
            // partire musica giradischi
            //accendo il pezzo della gamba
            // quando alzo il pezzo preso, nuova musica
        }

        void CoseCheAccadonoPerPezzo3()
        {
            //animazione finestre
            //audio finestre che sbatono + giocattoli
            //esplosione giocattoli
            //accendi pezzo gonna
            // dopo che ho posizionato l'oggetto senzo il suono della porta che viene sbloccata ---> deve aprirla per andare nella terza scena
        }
    }
}



