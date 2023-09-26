using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody player;
    
    public float moveVert = 0;
    public float moveHor = 0;

    public string buttonA = "joystick 1 button 0";
    public string buttonB = "joystick 1 button 11";

    public float speed = 5f;

    private float currentSpeedForward = 0;

    void Update()
    {
        //Prototype controller has messed up orientation, will be fixed in final version
        moveVert = Input.GetAxisRaw("Horizontal");
        moveHor = Input.GetAxisRaw("Vertical");
        
        Vector2 inputVector = new Vector2(moveHor * 2f, moveVert * 2f);

        int isMoving = (Mathf.Abs(moveVert) > 0 || Mathf.Abs(moveHor) > 0) ? 1: 0;
        
        if (isMoving == 1)
        {
            //player.constraints = ~RigidbodyConstraints.FreezeRotationY;
            float inputAngle = Vector2.SignedAngle(Vector2.left, inputVector);
            transform.eulerAngles = new Vector3(0f, inputAngle, 0f);
            
            currentSpeedForward = (moveVert * moveHor) * speed * Time.deltaTime;

            player.AddRelativeForce(new Vector3((isMoving*speed)*Time.deltaTime, 0f, 0f), ForceMode.Impulse);
        }
        else
        {
            player.angularVelocity = Vector3.zero;
            //player.constraints = RigidbodyConstraints.FreezeRotationY;
        }



        //for (int i = 0;i < 20; i++) {
        //    if(Input.GetKeyDown("joystick 1 button "+i)){
        //        print("joystick 1 button "+i);
        //    }
        //}
    }
}
