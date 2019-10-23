using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2d : MonoBehaviour
{
    private float timeBtwAtk;
    public float startTimeBtwAtk;
    public Transform attackPos;
    public float attackRange;
    public LayerMask onlyEnemy;
    public Animator animator2;
    public int damage;
    // Start is called before the first frame update

    public void BtnAttack()
    {
       
     
            animator2.SetTrigger("attack");
            Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(attackPos.position, attackRange, onlyEnemy);
            for (int i = 0; i < enemiesToDmg.Length; i++)
            {
                enemiesToDmg[i].GetComponent<Slime>().TakeDamage(damage);
            }
            timeBtwAtk = startTimeBtwAtk;
      

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
