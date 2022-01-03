using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; //Playable Director

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool alreadyTriggered = false;
        private void OnTriggerEnter(Collider other) {
            if(!alreadyTriggered && other.gameObject.tag == "Player"){
                alreadyTriggered = true;
                GetComponent<PlayableDirector>().Play();
            }

        }
    }

}
