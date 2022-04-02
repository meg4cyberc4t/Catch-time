using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class CircleScript : MonoBehaviour
    {
        private void OnTriggerEnter2D([NotNull] Collider2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (other.tag == "Player")
            {
                GetComponent<AudioSource>().Play();
                Debug.Log("Чел в зоне достигаемости " + other.name);
            }
        }
        
        private void OnTriggerExit2D([NotNull] Collider2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (other.tag == "Player")
            {
                Debug.Log("Чел вне зоны достигаемости " + other.name);
            }
        }
    }
}
