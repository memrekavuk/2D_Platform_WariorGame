using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    

    public void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Behaviour>().takeDamage(attackDamage);
            FindObjectOfType<Audio_Manager>().Play("Enemy_Hurt");
            FindObjectOfType<Audio_Manager>().Play("Sword_Sound2");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

   
}
