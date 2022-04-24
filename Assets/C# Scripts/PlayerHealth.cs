using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    [SerializeField] private Transform playerPosition;

    private void Awake()
    {
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
       
        
    }
}
