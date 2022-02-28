using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColiderDetect : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) {
        
        switch (other.gameObject.tag)
        {   
            case "Start":
             Debug.Log("Eat Shit");
             break;
            case "Finish":
            Debug.Log("Eat more shit");
            LoadNextScene();
            break;
            case "Hazard":
            Debug.Log("Get guud bish");
            LoadScene();
            break;
            default: 
            Debug.Log("Eat all the shit");
            LoadScene();
            break;
        }

   }

   void LoadScene(){

       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex);


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
