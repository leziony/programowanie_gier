using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DziałkoStraznicze : MonoBehaviour
{

    Rigidbody2D rigid;
    Object Pocisk;
    private bool alive = true;
    private int delay = 30;
    private bool selfdestruct = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            animator.Play()
            if (delay == 0)
            {
                GameObject pocisk1 = (GameObject)Instantiate(Pocisk);
                pocisk1.transform.position = new Vector2(transform.position.x * .3f, transform.position.y * .3f);
                delay = 30;
            }
            else
                delay--;
        }
        else
        {
            if (selfdestruct == false)
            {
                Invoke("Destruction", 6f);
                selfdestruct = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        alive = false;
        animator.Play("boom");
    }
    private void Destruction()
    {
        Destroy(gameObject);
    }
}
