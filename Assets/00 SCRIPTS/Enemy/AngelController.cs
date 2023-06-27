using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : AbstractEnemy,IDamageable
{
    AngelAnimations angelAnimations;
    [SerializeField] AngleState angleState;
    void Awake()
    {
        ActiveManager.Instant.Objects.Add(this.gameObject);
    }
    void Start()
    {
        angelAnimations = GetComponentInChildren<AngelAnimations>();
        angleState = AngleState.Idle;
    }
    void Update()
    {
        if (!CheckGameState())
        {
            gameObject.SetActive(false);
            return;
        }
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
        SetFx(transform.position,3);
        gameObject.SetActive(false);
    }
}

