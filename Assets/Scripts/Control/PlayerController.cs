using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control{
    public class PlayerController : MonoBehaviour
    {
        Health health;
        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (health.IsDead()) return;
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            //print("Nothing to do");
        }

        private bool InteractWithCombat(){
            
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits){
                
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                
                if (target == null) continue;

                if(!GetComponent<Fighter>().CanAttack(target.gameObject)) continue; //if can't attack, goto the next iteration

                if(Input.GetMouseButton(0)){
                    GetComponent<Fighter>().Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }
        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); //Storing RayCast hit in hit variable.

            if (hasHit)
            {
                if (Input.GetMouseButton(0)){
                    GetComponent<Mover>().StartMoveAction(hit.point, 1f); //full speed (1 = max value)
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}