using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchPostaci : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
        
            transform.localScale = new Vector3(3,3,3);
        
        else if (horizontalInput < -0.01f)
        
            transform.localScale = new Vector3(-3,3,3);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
               
            
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        }
    private void Jump()
    { 
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") ;
        grounded = true;
    }


}

    /*
    public float skok = 5.0f;
    public float gravity = 20.0f;
    public float predkosc = 8.0f;
    private bool jumplock = false;

    CharacterController characterController;
    private Vector2 ruch = Vector2.zero;
    Animator animator;
    Object pocisk;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var poziom = Input.GetAxis("Horizontal");
        var pion = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(poziom, pion) * (predkosc * Time.deltaTime));
        
        if (characterController.isGrounded)
        {
            jumplock = false;
            ruch = new Vector2(poziom, pion);
            ruch *= predkosc;
            if(Input.GetButton("Jump"))
            {
                ruch.y = skok;
                jumplock = true;
                animator.Play("PlayerJump");
            }
        }

        ruch.y -= gravity * Time.deltaTime;
        characterController.Move(ruch * Time.deltaTime);
        if(ruch == Vector2.zero)
        {
            animator.Play("PlayerStand");
        }
        else if (ruch != Vector2.zero && !Input.GetButtonDown("Fire"))
        {
            animator.Play("PlayerRunning");
        }
        if(Input.GetButtonDown("Fire")&&jumplock==false)
        {
            if (ruch == Vector2.zero)
                animator.Play("PlayerShoot");
            else
                animator.Play("PlayerRunAndGun");
            GameObject pocisk1 = (GameObject)Instantiate(pocisk);
            pocisk1.transform.position = new Vector2(transform.position.x * .3f, transform.position.y * .3f);
        }
    */
    

