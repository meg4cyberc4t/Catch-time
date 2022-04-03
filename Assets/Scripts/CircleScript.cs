using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class CircleScript : MonoBehaviour
    {
        private bool _characterNearby = false;
        private Animator _playerAnimator;
        private void FixedUpdate()
        {
            if (!_characterNearby) return;
            if (!Input.GetKeyDown(KeyCode.E)) return;
            _playerAnimator.SetTrigger("IsTake");
            // _playerAnimator.Play("Take");
            GetComponent<AudioSource>().Play();
            // Destroy(gameObject);
            //
            Debug.Log("Убрали чела");
        }
        
        private void OnTriggerEnter2D([NotNull] Collider2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (other.tag != "Player") return;
            _playerAnimator = other.gameObject.GetComponent<Animator>();
            _characterNearby = true;
            
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (other.tag != "Player") return;
            _characterNearby = false;
        }
    }
}
