using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHealPlayEffect",
    menuName = "CardData/PlayEffects/HealSelf")]

public class HealPlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 0;
    [SerializeField] int healAmount = 1;
    EnemyTurnCardGameState enemyTurnCardGameState = FindObjectOfType<EnemyTurnCardGameState>();


    public override void Activate(ITargetable target)
    {
        //test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;
        //if it is, apply damage
        if (objectToDamage != null)
        {
            objectToDamage.TakeDamage(_damageAmount);
            Debug.Log("Add damage to the target");
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }

    }
}
