using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class CircleScript : MonoBehaviour
    {
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
                other.gameObject.GetComponent<CharacterController>().NearCloth = gameObject;
                Ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
            }   
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<CharacterController>().NearCloth = null;
                Ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
            } 
        }
    }
}
