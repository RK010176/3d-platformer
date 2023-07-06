using UnityEngine;
using Common;
using System;

namespace Game
{
   
    public class PlayerController : MonoBehaviour
    {
        public PlayerSpecs PlayerSpecs { get; set; }

        private  Rigidbody _rb;
        public float JumpForce = 2f;
        private bool _isJumping = false;        
        private Animator _animator;
        
        private AudioSource _audioSource;        
        private AudioManager _audioManager;

        public FloatVal Health;
        public event Action<float> OnHealthPctChanged = delegate { };
        private ObjectPool _pool;

        private void Awake()
        {
            gameObject.name = "Player";
            _rb = GetComponent<Rigidbody>();            
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();            
            _audioManager = new AudioManager();
            _pool = GameObject.Find("HitPool").GetComponent<ObjectPool>();
        }

        private void Start()
        {
            _audioManager.Sounds = PlayerSpecs.Sounds;
            _audioManager.AudioSource = _audioSource;
            Health.Value = PlayerSpecs.Health;            
        }
        

       

        private void Update()
        {
            // Forward
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.forward * PlayerSpecs.MovingSpeed * Time.deltaTime ;                                
                _animator.SetBool("Walk", true);
                _audioManager.PlaySound(0, false);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
                _animator.SetBool("Walk", false);

            // Backward
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= transform.forward * PlayerSpecs.MovingSpeed * Time.deltaTime;
                _animator.SetBool("Walk", true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
                _animator.SetBool("Walk", false);

            // Rotation
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(transform.up, 1f);
            if (Input.GetKey(KeyCode.LeftArrow)) 
                transform.Rotate(transform.up, -1f);


            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
            {
                _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                _isJumping = true;

                _animator.SetTrigger("Jump");                
                _audioManager.PlaySound(2, false);
            }                                              

        }    

        private void OnCollisionEnter(Collision collision)
        {            
            if (collision.gameObject.layer == 8) // Layer Enemy
            {
                Debug.Log(collision.collider.name);
                float currenthealthPct = Health.Value / 100f;
                OnHealthPctChanged(currenthealthPct);
                _animator.SetTrigger("Hit");

                GameObject effect = _pool.GetPooledObject();
                effect.transform.position = transform.position;

                if (Health.Value <= 0)
                {
                    
                    Debug.Log(Health.Value);

                }
            }

            if (collision.gameObject.CompareTag("Ground"))
            {
                _isJumping = false;
            }
        }

    }
}