using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public Transform enemyAttackPoint;
    public LayerMask playerLayers;

    public float enemyAttackRange = 0.5f;
    public int enemyAttackDamage = 40;


    public void DamagePlayer()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(enemyAttackPoint.position, enemyAttackRange, playerLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Character_Health>().TakeDamage(enemyAttackDamage);
        
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (enemyAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(enemyAttackPoint.position, enemyAttackRange);
    }

}
