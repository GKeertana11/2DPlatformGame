using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float playerJumpForce;
    float xInput, yInput;
    bool isFacingRight;
    bool isGrounded;
    public LayerMask layerMask;
    public Transform groundCheck;
    Rigidbody2D rb;
    [SerializeField]
    private float checkRadius;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layerMask);
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * playerSpeed, rb.velocity.y);
        if(isFacingRight==false && xInput<0 )
        {
            Flip();
        }
        else if (isFacingRight == true && xInput >0)
        {
            Flip();
        }

        if (Input.GetButtonDown("Fire1") && isGrounded==true)
        {
            rb.velocity = Vector2.up * playerJumpForce;

        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
     transform.Rotate(0, 180, 0);
    }
}
