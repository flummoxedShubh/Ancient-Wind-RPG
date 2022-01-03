using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        void LateUpdate() //Called after update, let's player move first then follows his position
        {
            transform.position = target.position;
        }
    }

}