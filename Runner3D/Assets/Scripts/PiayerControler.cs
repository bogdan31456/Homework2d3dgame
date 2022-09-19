using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiayerControler : MonoBehaviour
{

    private CharacterController controller;
   
    

    private Vector3 dir;
    [SerializeField] private int speed;
    //[SerializeField] private float jumpForce;[SerializeField] private float gravity;
    [SerializeField] private float jumpForce ;
    [SerializeField] private float gravity ;
    private int LineToMove = 1;
    private float LineDistance= 3;
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(SwipeControler.swipeRight)
        {
            if (LineToMove < 2)
                LineToMove++;
        }

        if(SwipeControler.swipeLeft)
        {
            if (LineToMove > 0)
                LineToMove--;

        }
        if(SwipeControler.swipeUp)
        {
            if (controller.isGrounded)
                Jump();
        }
      
       
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (LineToMove == 0)
            targetPosition += Vector3.left * LineDistance;
        else if (LineToMove == 2)
            targetPosition+=Vector3.right * LineDistance;
        transform.position = targetPosition;
       
    }
  
    private void Jump()
    {
        dir.y = jumpForce;
       
    }
    void FixedUpdate()
    {
        dir.z = speed;
       
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
}
