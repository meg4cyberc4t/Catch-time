using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class WashingMachineController : MonoBehaviour
    {
        private GameObject _ebutton;
        private GameObject norm;
        private GameObject good;
        private GameObject bad;

        public int AllClothCounter;
        
        private Animator _playerAnimator;

  
        private void Start()
        {
            _ebutton = gameObject.transform.GetChild(0).gameObject;
            norm = gameObject.transform.GetChild(1).gameObject;
            good = gameObject.transform.GetChild(2).gameObject;
            bad = gameObject.transform.GetChild(3).gameObject;
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

                if(AllClothCounter < 5)
                {

                    bad.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
                }
                else if(AllClothCounter < 10)
                {

                    norm.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
                    good.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
                    bad.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
                }
                else
                {
                    norm.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
                    good.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
                    bad.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
                }

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
