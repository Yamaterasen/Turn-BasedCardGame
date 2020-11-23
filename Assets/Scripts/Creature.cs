using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    public int _currentHealth = 10;
    [SerializeField] Slider enemyHealthBar;
    [SerializeField] GameObject victory_pnl;

    public void Kill()
    {
        Debug.Log("Kill the creature!");
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        // Update Health Bar
        enemyHealthBar.value = _currentHealth;
        Debug.Log("Took damage. Remaining health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            victory_pnl.SetActive(true);
            Kill();
        }
    }

    public void Target()
    {
        Debug.Log("Creature has been targeted.");
    }
}
