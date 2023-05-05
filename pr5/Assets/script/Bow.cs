using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if(collision.gameObject.TryGetComponent<TargetDamage>(out TargetDamage enemyComponent))
        {
            enemyComponent.TakeDamage(10);
        }
    }
}
