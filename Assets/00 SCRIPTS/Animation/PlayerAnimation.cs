using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour,IAnimation
{
    Animator animator;
    PlayerController.PlayerState oldState;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CrouchAttack();
        Attack();
    }

    void CrouchAttack()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.C))
            animator.SetFloat("AttackState", 1);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("AttackState", 0);
            return;
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
            return;
        }
    }
    void Attack()
    {
        if (!Input.GetKey(KeyCode.C))
            return;
        else
        {
            animator.SetFloat("AttackState", 0);
            if (!Input.GetKey(KeyCode.C))
                return;
            else animator.SetFloat("AttackState", Random.Range(0, 2));
        }
    }
    public void ChangeAnim(PlayerController.PlayerState playerState)
    {
        if(playerState == oldState)
            return;
        animator.SetTrigger(playerState.ToString());
        oldState = playerState;
    }
}
