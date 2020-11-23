using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyTween : MonoBehaviour
{
    [SerializeField] float XMoveTo = 1f;
    [SerializeField] float YMoveTo = 0f;
    [SerializeField] float XMoveTime = 5f;
    [SerializeField] float YMoveTime = .2f;
    [SerializeField] float ScaleTo = 1.25f;
    [SerializeField] float ScaleTime = .2f;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveX(this.gameObject, 1f, 5f).setLoopPingPong();
        LeanTween.moveY(this.gameObject, 0f, .2f).setLoopPingPong();
        LeanTween.scaleY(this.gameObject, 1.25f, .2f).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
