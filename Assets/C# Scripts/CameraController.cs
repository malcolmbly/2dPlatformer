using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform player;
    private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D playerCollider;

    private void Awake()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        else
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //Note*: if the player is standing on the ground the collider will NOT equal null
        return raycastHit.collider != null;
    }

}
