using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterController : MonoBehaviour {
        private const float MaxSpeed = 10f;
        private bool _facingRight = true;
        public Transform GroundCheck;
        public float GroundRadius = 0.2f;
        private float _move = 0f;

        private void FixedUpdate () {
            _move = Input.GetAxis("Horizontal");
        }

        private void Update(){
            GetComponent<Rigidbody2D>().velocity = new Vector2 (_move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            switch (_move)
            {
                case > 0 when !_facingRight:
                case < 0 when _facingRight:
                    Flip ();
                    break;
            }
            
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        private void Flip(){
            _facingRight = !_facingRight;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }	
        
        // void OnTriggerEnter(Collider other)
        // {
        //     print("Collision detected with trigger object " + other.name);
        // }
    }
}