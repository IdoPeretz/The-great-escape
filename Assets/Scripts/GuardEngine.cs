using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEngine : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anm.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anm.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
