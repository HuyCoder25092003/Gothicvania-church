using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : AbstractEnemy,IDamageable
{
    AngelAnimations angelAnimations;
    [SerializeField] AngleState angleState;
    void Start()
    {
        angelAnimations = GetComponentInChildren<AngelAnimations>();
        angleState = AngleState.Idle;

    }
    void Update()
    {
        UpdateState();
        UpdateAnim();
    }
    void UpdateState()
    {
        if (this.transform.position.x - PlayerController.Instant.transform.position.x > 10f)
        {
            angleState = AngleState.Idle;
            return;
        }
        angleState = AngleState.Attack;
    }
    void UpdateAnim()
    {
        angelAnimations.ChangeAnim(angleState);
    }

    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }

}

