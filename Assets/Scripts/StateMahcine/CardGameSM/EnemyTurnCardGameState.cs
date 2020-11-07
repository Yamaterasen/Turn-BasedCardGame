using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;
    [SerializeField] int playerHealth = 10;
    [SerializeField] Slider playerHealthSlider;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        playerHealth--;
        playerHealthSlider.value = playerHealth;
        

        EnemyTurnEnded?.Invoke();
        //turn over. Go back to Player.
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }
}
