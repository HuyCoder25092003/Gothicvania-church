using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour,IAnimation
{
    public Animator animator;
    PlayerState oldState;
    [SerializeField]int combo;
    bool isCombo;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Jump();
        CrouchAttack();
        
    }

    void CrouchAttack()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.C))
            animator.SetFloat("AttackState", 1);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("AttackState", 0);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.C))
                animator.SetFloat("AttackState", 1);
            else
                animator.SetFloat("AttackState", 0.5f);
        }
        else
        {
            animator.SetFloat("AttackState", 0);
        }
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.C) &&!isCombo)
        {       
            isCombo = true;
            animator.SetFloat("AttackState", combo);
        }
    }

    public void StartCombo()
    {
        isCombo=false;
        if (combo < 1)
            combo++;
    }
    public void FinishCombo()
    {
        isCombo = false;
        combo = 0;
    }

    public void ChangeAnim(PlayerState playerState)
    {
        if(playerState == oldState)
            return;
        animator.SetTrigger(playerState.ToString());
        oldState = playerState;
    }
}
