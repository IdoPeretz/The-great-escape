using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    float speed;
    Animator anm;
    public Transform AttackPoint;
    public float AttackRange;
    public LayerMask enemyLayers;

    void Start()
    {
        speed = 0.08f;
        anm = GetComponent<Animator>();
        AttackRange = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        transform.Translate(x, 0, 0);
        if (x == 0 && Input.GetKey(KeyCode.Space) == false)
        {
            anm.SetBool("is Walking", false);
            anm.SetBool("is Attacking", false);
        }
        else if (x == 0 && Input.GetKey(KeyCode.Space) == true)
        {
            anm.SetBool("is Walking", false);
            anm.SetBool("is Attacking", true);
        }
        else if (x > 0 && Input.GetKey(KeyCode.Space) == false)
        {
            anm.SetBool("is Walking", true);
            anm.SetBool("is Attacking", false);
            transform.localScale = new Vector3(0.2561325f, 0.2308973f, 0);
        }
        else if (x < 0 && Input.GetKey(KeyCode.Space) == false)
        {
            anm.SetBool("is Walking", true);
            anm.SetBool("is Attacking", false);
            transform.localScale = new Vector3(-0.2561325f, 0.2308973f, 0);
        }
        else if (x > 0 && Input.GetKey(KeyCode.Space) == true)
        {
            anm.SetBool("is Walking", false);
            anm.SetBool("is Attacking", true);
            transform.localScale = new Vector3(0.2561325f, 0.2308973f, 0);
        }
        else if (x < 0 && Input.GetKey(KeyCode.Space) == true)
        {
            anm.SetBool("is Walking", false);
            anm.SetBool("is Attacking", true);
            transform.localScale = new Vector3(-0.2561325f, 0.2308973f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackFn();
        }

    }
    void AttackFn()
    {
        //detect enemies in range of attack
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);
        //damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<GuardEngine>().TakeDamage(40);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            anm.SetTrigger("Die");
        }
    }
}
