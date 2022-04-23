using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    

    // Start is called before the first frame update
    void Start()
    {
   
    }

    private void Awake()
    {

        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {


    }

}
