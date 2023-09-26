using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Tester : MonoBehaviour
{
    // Start is called before the first frame update
    public float vertIn = 0;
    public float horIn = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        vertIn = Input.GetAxisRaw("Horizontal");
        horIn = Input.GetAxisRaw("Vertical") * -1;

        for (int i = 0;i < 20; i++) {
            if(Input.GetKeyDown("joystick 1 button "+i)){
                print("joystick 1 button "+i);
            }
        }
    }
}
