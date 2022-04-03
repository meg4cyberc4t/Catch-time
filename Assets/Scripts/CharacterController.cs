using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterController : MonoBehaviour {
        public float MaxSpeed = 6f;

        private SpriteRenderer _spriteRenderer;
        private float _move;

        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        private void FixedUpdate () {
            _move = Input.GetAxis("Horizontal");
        }

        private void Update(){
            GetComponent<Rigidbody2D>().velocity = new Vector2 (_move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (_move != 0) Debug.Log("Ходит");
            _anim.SetBool("IsMove", _move !=0);
            switch (_move)
            {
                case > 0:
                    _spriteRenderer.flipX = false;
                    break;
                case < 0:
                    _spriteRenderer.flipX = true;
                    break;
            }

        }
    }
}