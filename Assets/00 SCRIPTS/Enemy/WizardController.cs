using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    //[SerializeField] float speed;

    [SerializeField] GameObject _bullet;
    [SerializeField] float maxTimeShoot;
    float countTime = 0;
    [SerializeField] GameObject shooting;
    WizardAnimations wizardAnimations;
    void Start()
    {
        wizardAnimations = GetComponentInChildren<WizardAnimations>();
    }
    void Update()
    {   
        Fire();
    }
    void Fire()
    {
        countTime-=Time.deltaTime;
        if (countTime > 0)
            return;
        wizardAnimations.anim.SetTrigger("Fire");
        countTime = maxTimeShoot;
    }
}
