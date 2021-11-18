using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private RuchPostaci ruch;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer>attackCooldown && RuchPostaci.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }


    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }












    /*
    Rigidbody2D pocisk;
    // Start is called before the first frame update
    void Start()
    {
        pocisk = GetComponent<Rigidbody2D>();
        Invoke("DestroyS", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        pocisk.velocity = new Vector2(2, 0); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ziemia"))
        {
            DestroyS();
        }
    }
    private void DestroyS()
    {
        Destroy(gameObject);
    }
    */
}
