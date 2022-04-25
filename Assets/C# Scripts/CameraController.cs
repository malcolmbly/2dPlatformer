using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
/// <author>Collin Williams and Quang Le</author>
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
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    /// <summary>
    /// Check if the player character is making contact with the terrain. 
    /// </summary>
    /// <returns>
    /// If the player is touching the terrain.
    /// </returns>
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }

    /// <summary>
    /// Check if the player character is making contact with the wall.
    /// </summary>
    /// <returns>
    /// If the player is touching the wall.
    /// </returns>
    private bool OnWall()
    {
        Vector2 direction = new Vector2(player.localScale.x, 0);
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, direction, 0.1f, wallLayer);

        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }

}
