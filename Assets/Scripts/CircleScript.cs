using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class CircleScript : MonoBehaviour
    {
        private bool _characterNearby = false;
        private void FixedUpdate()
        {
            if (!_characterNearby) return;
            if (!Input.GetKeyDown(KeyCode.E)) return;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            Debug.Log("Убрали чела");
        }
        
        private void OnTriggerEnter2D([NotNull] Collider2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (other.tag != "Player") return;
            _characterNearby = true;
            
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (other.tag != "Player") return;
            _characterNearby = true;
        }
    }
}
