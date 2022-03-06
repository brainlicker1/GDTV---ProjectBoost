using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float thrustRate = 1f;
    [SerializeField] float leftTorque = 1f;
    [SerializeField] float rightTorque = 1f;
    Rigidbody rb;
    AudioSource clip;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        clip = GetComponent<AudioSource>(); 
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
            rb.AddRelativeForce(Vector3.up * thrustRate * Time.deltaTime);
            mainBooster.Play();
            if(!clip.isPlaying){ 
                clip.PlayOneShot(mainEngine);
                }
                if(!mainBooster.isPlaying) {mainBooster.Stop();}
            else{
            clip.Stop();
            
            }
            
           // Debug.Log("grats you have opposable thumbs");
        }
        

     }
     void RotateInput(){

        if(Input.GetKey(KeyCode.A))
        {
            //rotate left
            leftBooster.Play();
            RotateRocket(leftTorque);
        }
        else if(Input.GetKey(KeyCode.D)){

            //rotate right
            rightBooster.Play();
           RotateRocket(-rightTorque);
        } 
        else {
            leftBooster.Stop();
            rightBooster.Stop();
        }
     }

          void RotateRocket(float rotationThisFrame)
    {       rb.freezeRotation = true;
            rb.transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false;
    }
    void PlaySoundClip(AudioClip audioClip){

       

            clip.PlayOneShot( audioClip);


    }
}
