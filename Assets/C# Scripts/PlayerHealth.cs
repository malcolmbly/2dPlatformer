using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    [SerializeField] private Transform playerPosition;
    [SerializeField] private bool hitEnemy = false;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public static bool playerDead = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        playerPosition = GetComponent<Transform>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        //player alive
        if (currentHealth > 0)
        {

        } 
        //player dead
        else
        {
            spriteRenderer.color = Color.black;
            playerDead = true;
            playerPosition.position = new Vector3(-999,-999,-999);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

        //if the player falls off the map
        if (playerPosition.position.y < -15)
        {
            TakeDamage(1);
        } 
        else if (hitEnemy)
        {
            if (body.mass != 100)
            {
                TakeDamage(1f);
                hitEnemy = false;
            }
                
                
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

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
}
