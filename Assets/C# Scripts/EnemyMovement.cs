using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attacted to the player object via drag and drop.
/// </summary>
public class EnemyMovement : MonoBehaviour
{
   
    //This is the declaration for the rigid body on the player
    private Rigidbody2D body;
    [SerializeField] private int enemySize = GameParams.GetEnemySize();
    private bool left = false;
    private int timeStuck = 0;
    [SerializeField] private float speed = GameParams.GetEnemySpeed(); 

    /// <summary>
    /// Every time you start the game the script will be loaded on the player and the
    /// Awake method will be executed.
    /// </summary>
    private void Awake()
    {
        //Gets component of the player of type Rigidbody2D and stores inside of the body variable.
        body = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(enemySize, enemySize, enemySize);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame of the game
    private void Update()
    {
        timeStuck++;
        if (timeStuck > 10000)
        {
            timeStuck = 0;
            left = !left;
        }

        if (left)
        {
            body.velocity = new Vector2(body.velocity.x - speed, body.velocity.y);
        } else
        {
            body.velocity = new Vector2(body.velocity.x + speed, body.velocity.y);
        }

        body.rotation = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player if "colliding" with the ground
        if (collision.gameObject.tag == "Wall")
        {
            left = !left;
            FlipPlayer(left);
        } 
    }

    private void FlipPlayer(bool left)
    {
        if (!left)
        {
            transform.localScale = new Vector3(enemySize, enemySize, enemySize);

        } //else the player is moving left
        else 
        {
            transform.localScale = new Vector3(-enemySize, enemySize, enemySize);
        }
    }
}
