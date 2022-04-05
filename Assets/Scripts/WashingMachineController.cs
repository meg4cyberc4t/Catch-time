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

        public Transform camera;
        
        
        public int AllClothCounter;
        
        private Animator _playerAnimator;

        [CanBeNull] private GameObject user;

  
        private void Start()
        {
            _ebutton = gameObject.transform.GetChild(0).gameObject;
            norm = gameObject.transform.GetChild(1).gameObject;
            good = gameObject.transform.GetChild(2).gameObject;
            bad = gameObject.transform.GetChild(3).gameObject;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            user = other.gameObject;
            _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            user = null;
            _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        }

        private void Update()
        {
            if (user == null) return;
            _ebutton.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
            if (!Input.GetKeyDown(KeyCode.E)) return;
            CharacterController characterController =
                user.GetComponent<CharacterController>();
            characterController.Inventory = new List<GameObject>();
            AllClothCounter += characterController.GetCapacity();
            characterController.SetCapacity(0);

            if(AllClothCounter < 4)
            {
                bad.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
            }
            else if(AllClothCounter < 8)
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
                
            if (AllClothCounter == 12)
            {
                camera.position = new Vector3(-77, -13, -20);
                Time.timeScale = 0;
                Ending.GetEnding(AllClothCounter, StartCoroutine);
            }
        }
    }
}
