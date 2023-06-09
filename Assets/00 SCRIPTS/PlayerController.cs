using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    float moveX,hp,timeCount;
    public float MoveX { get => moveX; set => moveX = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Hp { get => hp; set => hp = value; }

    Rigidbody2D rigi;
    [SerializeField] float speed, jumpForce;

    [SerializeField] bool isOnGround;

    [SerializeField] PlayerState playerState;

    PlayerAnimation playerAnimation;

    bool isImmute = false;

    private void OnEnable()
    {
        hp = 100;
        timeCount = 0;
        isImmute = true;
    }
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }
    void Update()
    {
        UpdateState();
        UpdateAnim();
        Jumping();
        timeCount+=Time.deltaTime;
    }
    void FixedUpdate()
    {
        Moving();
        Flip();
    }
    void Moving()
    {
        moveX = speed * Input.GetAxisRaw("Horizontal");
        rigi.velocity = new Vector2(moveX, rigi.velocity.y);
    }
    void Flip()
    {
        if (moveX > 0)
            transform.localScale = Vector3.one;
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rigi.AddForce(new Vector2(0, jumpForce));
        }
        if (rigi.velocity.y > 0 && !isOnGround)
        {
            playerState = PlayerState.Jump;
            if (Input.GetKey(KeyCode.C))
                playerState = PlayerState.FlyingKick;
        }
        else if(!isOnGround)
        {
            playerState = PlayerState.Fall;
        }
    }
    void UpdateState()
    {
        if (!isOnGround) 
            return;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKeyDown(KeyCode.C))
                playerState = PlayerState.CrouchKick;
            else playerState = PlayerState.Crouch;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            playerState = PlayerState.Attack;
        }
        else if (moveX != 0)
        {
            playerState = PlayerState.Walk;
        }
        else 
        {
            playerState = PlayerState.Idle;
        }
    }
    void UpdateAnim()
    {
        playerAnimation.ChangeAnim(playerState);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;

        if (isImmute)
            return;

        if (hp > 0)
        {
            hp--;
            isImmute = true;
            timeCount = 1;
            //hpBar.value = hp;
        }
        else
        {
            this.gameObject.SetActive(false);
            //GameManager.Instant.btnGameOver.SetActive(true);
            //GameManager.Instant.GameState = GAME_STATE.over;
        }
    }
}
public enum PlayerState
{
    Idle = 0,
    Walk = 1,
    Jump = 2,
    Fall = 3,
    Attack = 4,
    Crouch = 5,
    CrouchKick = 6,
    FlyingKick = 7,
    Hurt = 8,
}
