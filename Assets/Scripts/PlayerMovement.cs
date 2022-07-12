using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * 7f, rigidbody2D.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,14f);
        }
    }
}
