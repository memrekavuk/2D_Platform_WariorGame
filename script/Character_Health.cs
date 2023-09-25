using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Health : MonoBehaviour
{   
    //HealthValues
    public int maxHealth = 100;
    public int currentHealth;
    public Health_Bar healthBar;
    public LayerMask Player;


    //EnemySpacing

    public bool enemyattack;

    public float enemytimer;

    public Animator anim;
    




    void Start()
    {
        currentHealth = maxHealth;
        enemytimer = 1.5f;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame


    //Enemy damage deal cooldown
    void EnemyAttackSpacing()
    {
        if (enemyattack == false) 
        {
            enemytimer-=Time.deltaTime;
        }
        if (enemytimer<0)
        {
            enemytimer = 0f;
        }
        if (enemytimer==0f)
        {
            enemyattack = true;
            enemytimer = 1.5f;
        }



    }

    //Making enemy cant attack u if u hit it
    void CharacterDamage()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            enemyattack = false;
        }
    }

    //What happens when character damaged
    public void TakeDamage(int damage)
    {
        if (enemyattack)
        {
            currentHealth -= 20;
            enemyattack=false;
            anim.SetTrigger("IsHurt");
        }

        healthBar.SetHealth(currentHealth);


            if (currentHealth<= 0)
        {
            Die();
            currentHealth = 0;

        }
        
    }

    void Update()
    {
        EnemyAttackSpacing();
        CharacterDamage();
        


        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20);
        }
    }

    void Die()
    {
        anim.SetBool("IsDead", true);
        GetComponent<Character_Move>().enabled = false;
        Destroy(gameObject, 2f);
        gameObject.layer = LayerMask.NameToLayer(default);




    }

}
