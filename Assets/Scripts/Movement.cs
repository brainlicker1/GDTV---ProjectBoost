using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float thrustRate = 1f;
    [SerializeField] float leftTorque = 1f;
    [SerializeField] float rightTorque = 1f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThrustInput();
        RotateInput();
    }
     void ThrustInput(){


        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(0,thrustRate,0);
            Debug.Log("grats you have opposable thumbs");
        }
        

     }
     void RotateInput(){

        if(Input.GetKey(KeyCode.A)){
            //rotate left
            rb.AddRelativeTorque(-leftTorque,0,0);
        }
        else if(Input.GetKey(KeyCode.D)){

            //rotate right
            rb.AddRelativeTorque(rightTorque,0,0);
        }
     }
}
