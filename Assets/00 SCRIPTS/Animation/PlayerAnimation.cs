using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour,IAnimation
{
    Animator animator;
    PlayerState oldState;
    PlayerController playerController;
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
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

        if (Input.GetKey(KeyCode.C))
        {
            if (PlayerController.Instant.PlayerState == PlayerState.Fall || PlayerController.Instant.PlayerState == PlayerState.Jump)
            {
                animator.SetFloat("AttackState", 2);
            }
        }

        if (PlayerController.Instant.PlayerState == PlayerState.Idle 
            || PlayerController.Instant.PlayerState == PlayerState.Walk)
        {
            if (Input.GetKey(KeyCode.C))
            {
                PlayerController.Instant.AttackState = AttackState.Kick;
                animator.SetFloat("AttackState",(int)AttackState.Kick);
            }
            else
            {
                PlayerController.Instant.AttackState = AttackState.None;
                animator.SetFloat("AttackState", (int)AttackState.None);
            }
        }
        if (PlayerController.Instant.PlayerState == PlayerState.Crouch && Input.GetKeyDown(KeyCode.C))
        {
            animator.SetFloat("AttackState", 1);
        }

    }
    public void DoAttack()
    {
        playerController.Attack();
    }
    public void FinishCombo()
    {
        if (Input.GetKey(KeyCode.C) && PlayerController.Instant.AttackState == AttackState.Kick)
        {
            PlayerController.Instant.AttackState = AttackState.Punch;
            animator.SetFloat("AttackState",(int)AttackState.Punch);
            return;
        }

        animator.SetFloat("AttackState", (int)AttackState.None);
        PlayerController.Instant.AttackState = AttackState.None;
        PlayerController.Instant.PlayerState = PlayerState.Idle;
    }

    public void ChangeAnim(PlayerState playerState)
    {
        animator.SetTrigger(playerState.ToString());
        if (playerState == PlayerState.Idle && oldState == PlayerState.Fall || oldState == PlayerState.Jump)
        {
            animator.SetFloat("AttackState", 0);
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
