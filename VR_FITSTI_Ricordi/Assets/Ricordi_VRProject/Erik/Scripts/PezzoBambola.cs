using UnityEngine;
using UnityEngine.Events;
namespace BNG 
{ 
public class PezzoBambola : MonoBehaviour
{

   Grabbable _grabbableComponent;

   BallerinaManager _managerBall;
   [SerializeField] public UnityEvent OnGrab;

   public enum PieceName
   {
        TESTA_0, //0
        BRACCIO_1, //1
        GAMBA_2, //2
        GONNA_3 //3

   }

   public PieceName myself;

        private void Awake()
        {
            _managerBall = FindObjectOfType<BallerinaManager>();

        }

        private void Start()
        {
            _grabbableComponent = GetComponent<Grabbable>(); 
            
        }

        private void Update()
        {
            if (!_grabbableComponent.BeingHeld)
            {
                //_managerBall.EnableMeshRendere(_grabbableComponent.BeingHeld);
            }
            else
            {
                _managerBall.EnableMeshRendere(!_grabbableComponent.BeingHeld);
                //if(OnGrab)
            }

          
        }

        


    }
}
