using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchPostaci : MonoBehaviour
{
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
    }
}
