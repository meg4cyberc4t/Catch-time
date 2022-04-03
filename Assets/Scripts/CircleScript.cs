using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class CircleScript : MonoBehaviour
    {
        private bool _characterNearby = false;
        GameObject Ebutton;


        private Animator _playerAnimator;

  
        void Start()
        {
            Ebutton = gameObject.transform.GetChild(0).gameObject;
        }

        private void OnTriggerEnter2D([NotNull] Collider2D other)
        {
            if (other.tag == "Player")
            {

                other.gameObject.GetComponent<CharacterController>().isNear = true;
                Debug.Log(other.gameObject.GetComponent<CharacterController>().isNear);

                Ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);

            }   
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<CharacterController>().isNear = false;
                Ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
            } 
        }
    }
}
