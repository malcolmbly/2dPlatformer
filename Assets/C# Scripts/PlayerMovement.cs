using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attacted to the player object via drag and drop.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    //Size of the player in the game
    [SerializeField] private int playerSize;
    private float horizontalInput;
    //is the player hitting the enemy?
    private bool hitEnemy;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    //This is the declaration for the rigid body on the player
    private Rigidbody2D body;

    //Declaration for the animator of the player
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    //"SerializeField" Makes the player speed available on the unity GUI.
    private float speed = GameParams.GetPlayerSpeed();

    //How high the player jumps
    [SerializeField] private float jumpHeight;

    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;


    //Is the player grounded
    //private bool grounded;

    /// <summary>
    /// Every time you start the game the script will be loaded on the player and the
    /// Awake method will be executed.
    /// </summary>
    private void Awake()
    {
        //Gets component of the player of type Rigidbody2D and stores inside of the body variable.
        body = GetComponent<Rigidbody2D>();

        //Gets component of the animator of Animator and intitializes it.
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame of the game
    private void Update()
    {
        specialMove();

        //make sure player doesn't flip over
        hitEnemyAction();

        FlipPlayer();

        animations();

        wallJumpLogic();
    }

    private void hitEnemyAction()
    {
        if (hitEnemy)
        {
            if (body.mass != 100)
                spriteRenderer.color = Color.red;
        }
    }

    private void animations()
    {
        //Set the animator parameter run - Note*: When the arrow keys are NOT pressed the horizontal input = 0
        animator.SetBool("run", Input.GetAxis("Horizontal") != 0);
        //update the animator on whether the player is grounded or not
        animator.SetBool("grounded", isGrounded());
    }

    private void wallJumpLogic()
    {
        //Wall jumping logic
        if (wallJumpCoolDown > 0.2f)
        {
            //This body.velocity will change how fast the player is moving.
            //Note a vector is a collection of numbers.
            //The left and right movement is controlled by the Input.GetAxis("Horizontal")
            //For left and right unity uses the "a" and "d" keys or "left" and "right" arrow keys which move player by 1 so
            //we multiply by the speed.
            //                               X                     Y  
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = new Vector2(0, 0);
            }
            else
            {
                body.gravityScale = 7;
            }

            Jump();
        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }
    }

    /// <summary>
    /// This move makes the mass of the player 100 so it can push enemies around or not be moved 
    /// when the enemy crashes into the player.
    /// </summary>
    private void specialMove()
    {
        if (Input.GetKey(KeyCode.Q))
        {
           if(body.mass == 100)
            {
                body.mass = 1;
                spriteRenderer.color = Color.white;

            } else if (body.mass == 1)
            {
                body.mass = 100;
                spriteRenderer.color = Color.green;
            }
        } 
    }

    /// <summary>
    /// This method determines whether the player is going to jump (if space is pressed).
    /// If the player is on the ground or on the side of a wall object they can jump.
    /// </summary>
    public bool Jump()
    {
        //Jumping - if the space key is pressed
        if (Input.GetKey(KeyCode.Space))
        { 
            if (isGrounded())
            {
                //if jumping changed the bodies velocity on the y-axis.
                //The Player moves up by the jump height and gravity brings it back down.
                body.velocity = new Vector2(body.velocity.x, jumpHeight);

                //triggers the jump animation
                animator.SetTrigger("jump");
                return true;
            } 
            //If the player is on the wall but not on the ground
            else if (onWall() && !isGrounded())
            {
                if (horizontalInput == 0)
                {
                    //Mathf.Sign returns -1 if negative number otherwise 1 if positive number
                    body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                    transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else
                {
                    //Mathf.Sign returns -1 if negative number otherwise 1 if positive number
                    body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                }
                wallJumpCoolDown = 0;
                return true;
            }
            
        }
        return false;
    }

    /// <summary>
    /// Flips the player by using the horizontal input (keys a and d) to change the local scale
    /// by making the x coordinate either positive or negative.
    /// </summary>
    private void FlipPlayer()
    {
        //Get the horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        //if player is moving right - so if x or horizontal input is positive the player is right
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(playerSize, playerSize, playerSize);

        } //else the player is moving left
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-playerSize, playerSize, playerSize);
        }
    }

    /// <summary>
    /// OnCOllisionEnter2D is used for for collision in unity. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO
        //Feature will heal the player but for now it just turns the play white. 
        if (collision.gameObject.tag == "Heal")
        {
            spriteRenderer.color = Color.white;
        }

        //If the player has run into the enemy
        if (collision.gameObject.tag == "Enemy")
        {
            hitEnemy = true;
        } 
        else
        {
            hitEnemy = false;
        }
    }

    /// <summary>
    /// Return true if the player is touching an object with the "ground" tag otherwise returns false. 
    /// </summary>
    /// <returns>bool</returns>
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }

    /// <summary>
    /// Return true if the player is on the wall and false if not. 
    /// </summary>
    /// <returns>bool</returns>
    private bool onWall()
    {
        Vector2 direction = new Vector2(transform.localScale.x, 0);
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, direction, 0.1f, wallLayer);

        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }
}
