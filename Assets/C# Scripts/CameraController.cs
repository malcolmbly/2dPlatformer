using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer, wallLayer;
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D playerCollider;
    private bool jumpNotFinished = false;
    

    private void Awake()
    {
    }

    private void Update()
    {

        /*if (Input.GetKey(KeyCode.Space))
            jumpNotFinished = true;

        if (IsGrounded())
            jumpNotFinished = false;*/

        /*if (Input.GetKey(KeyCode.W))
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        else
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);*/


        //option #2
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        //If your not on the ground
        /*if (!IsGrounded())
        {
            //actively jumping
            if (OnWall())
            {
                transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);


            } //Not actively jumping
            else if (jumpNotFinished)
            {
                transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            } 
            else if (Input.GetKey(KeyCode.Space))
            {
                
                transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            }
        
        } else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }*/



    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        Vector2 direction = new Vector2(player.localScale.x, 0);
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, direction, 0.1f, wallLayer);

        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }

}
