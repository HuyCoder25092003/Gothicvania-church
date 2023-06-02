using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public enum PlayerState
    {
        Idle=0,
        Walk=1,
        Jump =2,
        Fall=3,
        Kick=4,
        Crouch=5,
        CrouchKick=6,
        FlyingKick=7,
        Hurt=8,
        Punch=9,
    }

    float moveX;
    public float MoveX { get => moveX; set => moveX = value; }
    public float Speed { get => speed; set => speed = value; }

    Rigidbody2D rigi;
    [SerializeField] float speed, jumpForce;

    [SerializeField] bool isOnGround;

    [SerializeField] PlayerState playerState;

    PlayerAnimation playerAnimation;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }
    void Update()
    {
        Jumping();
        UpdateState();
        UpdateAnim();
    }
    void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        moveX = speed * Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(moveX, rigi.velocity.y);

        if (moveX > 0)
            transform.localScale = Vector3.one;
        else if (moveX < 0)
            transform.localScale = new Vector3(-1,1,1);
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rigi.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
    void UpdateState()
    {
        if(isOnGround)
        {
            if (moveX == 0)
                playerState = PlayerState.Idle;
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.C))
                    playerState = PlayerState.CrouchKick;
                else playerState = PlayerState.Crouch;
            }
            else if (Input.GetKey(KeyCode.C))
            {
                playerState = PlayerState.Kick;
                if (Input.GetKey(KeyCode.C))
                {
                    playerState = (PlayerState)Random.Range((float)PlayerState.Kick, (float)PlayerState.Punch + 1);
                }
            }
            else playerState = PlayerState.Walk;
        }
        else
        {
            if (rigi.velocity.y > 0)
            {
                playerState = PlayerState.Jump;
                if (Input.GetKey(KeyCode.C))
                    playerState = PlayerState.FlyingKick;
            }
            else playerState = PlayerState.Fall;
        }
    }
    void UpdateAnim()
    {
        playerAnimation.ChangeAnim(playerState);
    }

}
