using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    void Start() {
        // assign starthost and joingame their onclicks
        // This is done programmically so we are able to assign a new networkmanager as onclick
       	
	}

	public void Play1(){
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}
	public void Play2(){
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 2);
        
	}
	public void Quit(){
		Debug.Log ("Quit");
		Application.Quit();
	}
}
