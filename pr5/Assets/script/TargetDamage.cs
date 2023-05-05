using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDamage : MonoBehaviour
{
    private int HP = 30;
    [SerializeField] Animator animator;
    public void TakeDamage(int damageBow)
    {
        HP -= damageBow;

        if (HP <= 0)
        {
            animator.SetTrigger("died");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("pushed");
        }
    }
}
