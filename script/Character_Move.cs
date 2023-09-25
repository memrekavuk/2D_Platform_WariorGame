using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D rb2d;
    float moveHorizontal;
    public bool facingRight;
    public float JumpForce;
    public bool IsGrounded;
    public bool CanDoubleJump;

    Player_Combat playercombat;

    public bool characterAttack;
    public float characterTimer;

    public 



    
    void Start()
    {
        moveSpeed = 10;
        moveHorizontal = Input.GetAxis("Horizontal");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        playercombat = GetComponent<Player_Combat>();
        rb2d.freezeRotation = true;
        characterTimer = 0.7f;

    }

    // Update is called once per frame
    void Update()
    { 
        CharacterMovement();
        CharacterAnimation();
        CharacterAttack();
        CharacterRunAttack();
        CharacterJump();
        CharacterAttackSpacing();
    }

    void CharacterMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);
    }
    void CharacterAnimation()
    {
        if (moveHorizontal>0)
        {
            anim.SetBool("IsRunning", true);
        }
        if (moveHorizontal==0) 
        {
            anim.SetBool("IsRunning", false);
        }
        if (moveHorizontal<0) 
        { 
        anim.SetBool("IsRunning", true) ;
        }
        if(facingRight==true && moveHorizontal<0) 
        { 
            CharacterFlip();
        }
        if (facingRight == false && moveHorizontal > 0 )
        {
            CharacterFlip();
        }

    }

    void CharacterFlip() 
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    void CharacterAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && moveHorizontal == 0)
        {
            
            if (characterAttack)
            {
                anim.SetTrigger("IsAttack");
                playercombat.DamageEnemy();
                characterAttack = false;
            }
            
            playercombat.DamageEnemy();
            FindObjectOfType<Audio_Manager>().Play("Sword_Sound1");
        }
    }

    void CharacterRunAttack()
    { 
    if ((Input.GetKeyDown(KeyCode.Mouse0)) && moveHorizontal != 0 )
        {
            
            if (characterAttack)
            {
                anim.SetTrigger("IsAttack");
                playercombat.DamageEnemy();
                characterAttack = false;
            }
            FindObjectOfType<Audio_Manager>().Play("Sword_Sound1"); 
        }
    }

    void CharacterJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            anim.SetBool("IsJump", true);
            rb2d.velocity = Vector2.up * JumpForce;
            CanDoubleJump = true;
        }

         else if (CanDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            JumpForce = JumpForce / 1.5f;
            rb2d.velocity = Vector2.up * JumpForce;

            CanDoubleJump = false;
            JumpForce = JumpForce * 1.5f;

        }
        
    }

    public void CharacterAttackSpacing()
    {
        if (characterAttack==false)
        {
            characterTimer -= Time.deltaTime;

        }
        if (characterTimer<0)
        {
            characterTimer = 0f;


        }
        if (characterTimer == 0f)
        {
            characterAttack = true;
            characterTimer = 0.7f;
        }
    }





    void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("IsJump", false);

        if (collision.gameObject.tag=="Grounded")
        {
            IsGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        anim.SetBool("IsJump", false) ;
        if (collision.gameObject.tag=="Grounded")
        {
            IsGrounded = true;
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("IsJump", true);
        if (collision.gameObject.tag=="Grounded")
        {
            IsGrounded = false;
        }

    }

}
