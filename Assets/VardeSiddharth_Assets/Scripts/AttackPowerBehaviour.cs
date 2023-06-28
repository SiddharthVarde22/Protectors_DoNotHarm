using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAttack playerAttack;
        if(collision.TryGetComponent<PlayerAttack>(out playerAttack))
        {
            playerAttack.OnAttackPowerGained();
            Destroy(gameObject);
        }
    }
}
