using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColiderDetect : MonoBehaviour
{   [SerializeField] float delay = 5f;
   private void OnCollisionEnter(Collision other) {
        
        
         
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
        GetComponent<Movement>().enabled = false;
        Invoke("LoadScene", delay);
        
    }
   void LoadScene(){

       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex);


   }

   void LandingComplete(){
       GetComponent<Movement>().enabled = false;
       Invoke("LoadNextScene", delay);

   }
   void LoadNextScene(){

       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex = currentSceneIndex +1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        
       SceneManager.LoadScene(nextSceneIndex);

   }
}
