using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG {

    public class DisableController : MonoBehaviour
    {
        GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("PlayerController");

            player.GetComponent<BNGPlayerController>().enabled = false;

            player.GetComponent<LocomotionManager>().enabled = false;

            player.GetComponent<SmoothLocomotion>().enabled = false;

            player.GetComponent<PlayerTeleport>().enabled = false;

            player.GetComponent<TimeController>().enabled = false;

            player.GetComponent<PlayerRotation>().enabled = false;

            player.GetComponent<PlayerClimbing>().enabled = false;

            player.GetComponent<HandModelSelector>().enabled = false;

            player.GetComponent<PlayerMovingPlatformSupport>().enabled = false;


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}