using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class СlothController : MonoBehaviour
    {
        /// <summary>
        /// Вес вещи, которую мы подняли
        /// </summary>
        [Range(1, 3)] public int Weight; 

        private GameObject _ebutton;
        
        private Animator _playerAnimator;

  
        private void Start()
        {
            _ebutton = gameObject.transform.GetChild(0).gameObject;
        }
        
        private void OnTriggerStay2D([NotNull] Collider2D other)
        {
            if (other.tag == "Player")
            {
                CharacterController characterController =
                    other.gameObject.GetComponent<CharacterController>();
                characterController.NearCloth = gameObject;
                _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
            }   
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<CharacterController>().NearCloth = null;
                _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
            } 
        }
    }
}
