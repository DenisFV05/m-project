    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rigidbody2D;
        private bool OnGround = false;

        public GameObject pewpew;

        public AudioSource audio;
        public AudioClip jumpSFX;
        private float height;
        private float jump;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            height = spriteRenderer.bounds.size.y; //https://discussions.unity.com/t/how-to-find-width-and-height-of-game-object-unity2d/137770
            Debug.Log("height muñeco: " + height);

            Debug.Log("Jump force: " + (height * 3));
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Ground")
            {
                OnGround = true;  
                animator.SetBool("Jumping", false);
            }
        }
        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            
            float verticalInput = Input.GetAxis("Vertical");
            
            
            Vector2 direction = new Vector2(horizontalInput, verticalInput);  // https://www.reddit.com/r/Unity2D/comments/xrpq8f/how_do_i_make_the_player_jump_only_once_pls_help/?rdt=45720



            if (horizontalInput > 0)                                //https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#jump_without_pyhsics_unity
            {
                transform.eulerAngles = new Vector3(0,0,0);
                animator.SetBool("Walking", true);
                rigidbody2D.AddForce(new Vector2(1000f*Time.deltaTime,0), ForceMode2D.Force);

            }
            else if (horizontalInput < 0)
            {
                transform.eulerAngles = new Vector3(0,180,0);
                animator.SetBool("Walking", true);

                rigidbody2D.AddForce(new Vector2(-1000f*Time.deltaTime,0));

            }
            else    
            {
                animator.SetBool("Walking", false);
            }

        if (verticalInput > 0 && OnGround)
            {
                rigidbody2D.AddForce(new Vector2(0, (height * 3)), ForceMode2D.Impulse);  
                animator.SetBool("Jumping", true);   
                audio.clip = jumpSFX;
                audio.Play();    
                OnGround = false;
                 }
            else {
                animator.SetBool("Jumping", false);
            }
            if (verticalInput < 0) 
            {
                animator.SetBool("Crouching", true);
            }

            else
            {
                animator.SetBool("Crouching", false);
            }
        }
        
    }