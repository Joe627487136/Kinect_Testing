﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Violin_Box : MonoBehaviour {
	public static bool start_checking;

	void Start(){
		start_checking = false;
	}

	void Update(){
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag=="rfh" && start_checking==true){
			print ("Enter Violin Box");
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "rfh" && start_checking == true) {
			print ("Exit Violin Box, Violin Registered");
			GameManager.user_input_sequence = GameManager.user_input_sequence + "V";
		}
	}
}
