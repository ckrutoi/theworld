using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 15f;
    public float jump = 200f;
    public GameObject ground;
    bool is_ground = false;     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,rb.velocity.y);
        Flip();
        Jump();
     
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0) ;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 360, 0);
        }
    }
    
    void Jump()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ground.transform.position, 0.01f);
        is_ground = colliders.Length > 1;
        if (Input.GetKeyDown(KeyCode.Space) && is_ground)               
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);  
    }
     

    

   
    
        
    
}


