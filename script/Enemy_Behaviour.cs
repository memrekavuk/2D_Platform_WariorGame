using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;

    Enemy_AI enemyai;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyai = GetComponent<Enemy_AI>();
        
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth < 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("IsDead", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        enemyai.followspeed = 0;
        Destroy(gameObject, 2f);
    }


}

