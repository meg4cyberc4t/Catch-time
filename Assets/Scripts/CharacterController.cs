using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterController : MonoBehaviour {
        public float MaxSpeed = 6f;
        
        private float _move;
        private bool _facingRight = true;


        private void FixedUpdate () {
            _move = Input.GetAxis("Horizontal");
        }

        private void Update(){
            GetComponent<Rigidbody2D>().velocity = new Vector2 (_move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKey(KeyCode.LeftShift)) return;
            switch (_move)
            {
                case > 0 when !_facingRight:
                case < 0 when _facingRight:
                    Flip ();
                    break;
            }

        }

        private void Flip(){
            _facingRight = !_facingRight;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}