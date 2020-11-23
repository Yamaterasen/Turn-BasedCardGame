using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;
    [SerializeField] RectTransform hp_txt;
    [SerializeField] RectTransform playerturn_txt;
    [SerializeField] GameObject enemythinkingobj;
    [SerializeField] Vector3 ScaleTo = new Vector3(2, 2, 2);
    [SerializeField] GameObject abilityCardPanel;
    [SerializeField] GameObject cardSlot;
    [SerializeField] GameObject shuffleButton;
    [SerializeField] RectTransform deck_txt;
    [SerializeField] RectTransform discard_txt;

    private void OnEnable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void Start()
    {
        //make sure text is disabled on start
        _enemyThinkingTextUI.gameObject.SetActive(false);
        LeanTween.textColor(hp_txt, Color.blue, 1f).setLoopPingPong();
        LeanTween.textColor(playerturn_txt, Color.yellow, 1f).setLoopPingPong();
        LeanTween.scale(enemythinkingobj, ScaleTo, 1f).setLoopPingPong();
        LeanTween.rotateZ(abilityCardPanel, -5f, 1f).setLoopPingPong();
        LeanTween.rotateZ(cardSlot, -5f, 1f).setLoopPingPong();
        LeanTween.rotateY(shuffleButton, 179f, 1f).setLoopPingPong();
        LeanTween.textColor(deck_txt, Color.green, 5f).setLoopPingPong();
        LeanTween.textColor(discard_txt, Color.cyan, 5f).setLoopPingPong();
    }

    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }

}
