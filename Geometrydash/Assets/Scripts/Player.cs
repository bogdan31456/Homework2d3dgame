using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float jumpHeight = 15f;

    BoxCollider2D boxleCollider;
    Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        boxleCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }
    // Update is called once per frame
    void Update()
    {
        //Vector2 playerVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.Translate ( playerVector * movementSpeed * Time.deltaTime);
        //Debug.Log(Time.deltaTime);
        if (!boxleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            //   Vector2 jumpVector = new Vector2(0f,jumpHeight);
            //    rbody.velocity += jumpVector;
            rbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

}
