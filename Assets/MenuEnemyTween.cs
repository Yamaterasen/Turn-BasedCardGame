using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnemyTween : MonoBehaviour
{
    public float XMoveTo = 20f;
    public float YMoveTo = 0f;
    public float XMoveTime = 10f;
    public float YMoveTime = .2f;
    public float ScaleTo = 1.25f;
    public float ScaleTime = .2f;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveX(this.gameObject, XMoveTo, XMoveTime).setLoopClamp();
        LeanTween.moveY(this.gameObject, YMoveTo, YMoveTime).setLoopPingPong();
        LeanTween.scaleY(this.gameObject, ScaleTo, ScaleTime).setLoopPingPong();
    }
}
