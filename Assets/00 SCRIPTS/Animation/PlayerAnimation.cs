using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour,IAnimation
{
    Animator animator;
    PlayerState oldState;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Crouch();
        Attack();
    }
    void Crouch()
    {
        if (Input.GetKey(KeyCode.C))
            return;
        if(PlayerController.Instant.PlayerState == PlayerState.Crouch)
            animator.SetFloat("AttackState", 0);
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.C))
            return;
        if (PlayerController.Instant.PlayerState == PlayerState.Jump)
            animator.SetFloat("AttackState", 0);
        else animator.SetFloat("AttackState", 1);
    }
    void Attack()
    {
        if (PlayerController.Instant.gameObject == null)
            return;

        if(PlayerController.Instant.PlayerState == PlayerState.Fall || PlayerController.Instant.PlayerState == PlayerState.Jump)
        {
            if (Input.GetKey(KeyCode.C))
            {
                animator.SetFloat("AttackState", 2);
            }
        }

        if (PlayerController.Instant.PlayerState == PlayerState.Idle 
            || PlayerController.Instant.PlayerState == PlayerState.Walk)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                PlayerController.Instant.AttackState = AttackState.Kick;
                animator.SetTrigger(AttackState.Kick.ToString());
            }
            else
            {
                PlayerController.Instant.AttackState = AttackState.None;
                animator.SetTrigger(AttackState.None.ToString());
            }
        }
        if (PlayerController.Instant.PlayerState == PlayerState.Crouch && Input.GetKeyDown(KeyCode.C))
        {
            animator.SetFloat("AttackState", 1);
        }

    }
    public void FinishCombo()
    {
        if (Input.GetKey(KeyCode.C) && PlayerController.Instant.AttackState == AttackState.Kick)
        {
            PlayerController.Instant.AttackState = AttackState.Punch;
            animator.SetTrigger(PlayerController.Instant.AttackState.ToString());
            return;
        }

        animator.SetTrigger(AttackState.None.ToString());
        PlayerController.Instant.AttackState = AttackState.None;
        PlayerController.Instant.PlayerState = PlayerState.Idle;
    }

    public void ChangeAnim(PlayerState playerState)
    {
        animator.SetTrigger(playerState.ToString());
        if (playerState == PlayerState.Idle && oldState == PlayerState.Fall || oldState == PlayerState.Jump)
        {
            animator.SetTrigger(AttackState.None.ToString());
            PlayerController.Instant.AttackState = AttackState.None;
        }    
        oldState = playerState;
    }
    public void ChangeAnim(GhoulState ghoulState)
    {
        
    }

    public void ChangeAnim(WizardState wizardState)
    {
        
    }

    public void ChangeAnim(AngleState angleState)
    {
        
    }
}
