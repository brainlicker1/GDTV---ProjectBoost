using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
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

            Debug.Log("grats you have opposable thumbs");
        }
        

     }
     void RotateInput(){

        if(Input.GetKey(KeyCode.A)){
            //rotate left
        }
        else if(Input.GetKey(KeyCode.D)){

            //rotate right
        }
     }
}
