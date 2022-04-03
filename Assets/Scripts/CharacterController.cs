using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts
{
    public class CharacterController : MonoBehaviour {
        public float MaxSpeed = 5f;

        [Range(0,4)] private int _capacity = 0;
        public List<GameObject> Inventory;

        [CanBeNull] public GameObject NearCloth; 

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
            GetComponent<Rigidbody2D>().velocity = new Vector2 (_move * (1  - (float) _capacity  /5.5f) * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            switch (_move)
            {
                case > 0:
                    _anim.SetBool("Take", false);
                    _anim.SetBool("IsMove", true);
                    _spriteRenderer.flipX = false;
                    break;
                case < 0:
                    _anim.SetBool("Take", false);
                    _anim.SetBool("IsMove", true);
                    _spriteRenderer.flipX = true;
                    break;
                default:
                    _anim.SetBool("Take", false);
                    _anim.SetBool("IsMove", false);
                    break;
            }
       
            if(NearCloth != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                     _anim.SetBool("Take", true);
                     int clothWeight = NearCloth.GetComponent<СlothController>().Weight;
                     if (_capacity + clothWeight > 4) return; // Ты слишком много на себя берёшь
                     _capacity += clothWeight;
                     Inventory.Add(NearCloth);
                     NearCloth.transform.position = new Vector3( NearCloth.transform.position.x, NearCloth.transform.position.y, 20f);
                     var nearClothColor  = NearCloth.GetComponent<SpriteRenderer>().color;
                     NearCloth.GetComponent<SpriteRenderer>().color = new Color(nearClothColor.r, 
                         nearClothColor.g, 
                         nearClothColor.b, 
                         0);
                     NearCloth.GetComponent<CircleCollider2D>().enabled = false;
                     NearCloth = null;
                }
            }
            
            // ВРЕМЕННО!
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Когда девчонка падает
                foreach (var o in Inventory)
                {
                    var nearClothColor  = o.GetComponent<SpriteRenderer>().color;
                    o.GetComponent<SpriteRenderer>().color = new Color(nearClothColor.r, 
                        nearClothColor.g, 
                        nearClothColor.b, 
                        1);
                    o.transform.position = new Vector3( o.transform.position.x, o.transform.position.y, -2f);
                    o.GetComponent<CircleCollider2D>().enabled = true;
                    _capacity = 0;
                }
            }


        }
    }
}