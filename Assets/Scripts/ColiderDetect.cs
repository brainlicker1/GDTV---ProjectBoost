using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColiderDetect : MonoBehaviour
{   [SerializeField] float delay = 5f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
       AudioSource audioSource;
    bool isTransitioning;
    bool collisionDisabled = false;
     void Start() {
          audioSource = GetComponent<AudioSource>();
          
        }

         void Update()
        {
           // RespondToDebugKeys();
        }

     void RespondToDebugKeys()
    {
        
         if(Input.GetKeyDown(KeyCode.L)) {
             LoadNextScene();

         }
         else if(Input.GetKeyDown(KeyCode.C)) {

             collisionDisabled = !collisionDisabled;

         }
    }

    void OnCollisionEnter(Collision other) {
        
        if(isTransitioning || collisionDisabled) { return;}
         
        switch (other.gameObject.tag)
        {   
            case "Start":
             Debug.Log("Eat Shit");
             break;
            case "Finish":
            Debug.Log("Eat more shit");
            LandingComplete();
            break;
            case "Hazard":
            Debug.Log("Get guud bish");
            StartCrashSequence();
            break;
            default: 
            Debug.Log("Eat all the shit");
            StartCrashSequence();
            break;
        }
        
   }
    void StartCrashSequence(){
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crash);
        crashParticle.Play();
        Invoke("LoadScene", delay);
        
    }
   void LoadScene(){
       
       
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex);


   }

   void LandingComplete(){
       isTransitioning = true;
       audioSource.Stop();
       GetComponent<Movement>().enabled = false;
       audioSource.PlayOneShot(success);
       successParticle.Play();
       Invoke("LoadNextScene", delay);

   }
     public void LoadNextScene(){
       
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex = currentSceneIndex +1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        
       SceneManager.LoadScene(nextSceneIndex);

   }
}
