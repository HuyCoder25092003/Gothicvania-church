using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : AbstractEnemy,IDamageable
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float maxTimeShoot = 3;
    float countTime;
    [SerializeField] GameObject shooting;
    WizardAnimations wizardAnimations;
    [SerializeField] WizardState wizardState;
    void Start()
    {
        wizardAnimations = GetComponentInChildren<WizardAnimations>();
    }
    void Update()
    {
        Fire();
        UpdateAnim();
    }
    void Fire()
    {
        if(countTime >= 0)
        {
            countTime -= Time.deltaTime;
            ChangeState(WizardState.Idle);
        }     
        else if (countTime < 0)
        {
            ChangeState(WizardState.Fire);
            countTime = maxTimeShoot;  
        }
    }
    void ChangeState(WizardState state)
    {
        wizardState = state;
    }
    void UpdateAnim()
    {
        wizardAnimations.ChangeAnim(wizardState);
    }
    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }
}