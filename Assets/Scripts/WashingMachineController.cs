using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class WashingMachineController : MonoBehaviour
    {
        private GameObject _ebutton;

        public int AllClothCounter;
        
        private Animator _playerAnimator;

  
        private void Start()
        {
            _ebutton = gameObject.transform.GetChild(0).gameObject;
        }
        
        private void OnTriggerStay2D([NotNull] Collider2D other)
        {
            _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
            if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
            {
                
                CharacterController characterController =
                    other.gameObject.GetComponent<CharacterController>();
                characterController.Inventory = new List<GameObject>();
                AllClothCounter += characterController.GetCapacity();
                characterController.SetCapacity(0);
                Debug.Log("Добрая мама");
            }
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other.tag == "Player")
            {
                _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
            } 
        }
    }
}
