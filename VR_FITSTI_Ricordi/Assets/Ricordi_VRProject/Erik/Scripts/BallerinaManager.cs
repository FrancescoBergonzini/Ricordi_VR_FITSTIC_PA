using UnityEngine;
using DG.Tweening;



namespace BNG
{
    public class BallerinaManager : MonoBehaviour
    {
        [SerializeField] Transform midAirPoint;
        [SerializeField] Transform[] pezziPos;

        MeshRenderer _myMeshRender;
        static int statoPezziPresi = 0;

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

    }
}



