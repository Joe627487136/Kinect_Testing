using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial_manager : MonoBehaviour {

	// Use this for initialization
	public string[] state_list;
	public string current_state;
	public bool state_start_signal;
	public static bool signal_bar_start_bool; 
	public static bool signal_bar_finish_bool;
	public GameObject Gesture_Holder;
	string current_input_from_gb;


	void Start () {
		state_list = new string[5]{"Guitar", "Violin", "Piano", "Trumpet", "Finish"};
		current_state = state_list[0];
		state_start_signal = true;
		signal_bar_start_bool = false;
		signal_bar_finish_bool = false;
		Gesture_Holder.transform.GetChild (0).gameObject.SetActive (true);
	}

	void Check_Block(int index, string instrument){
		GameObject instruction_panel = GameObject.FindGameObjectWithTag ("instruction_pannel");
		GameObject musicians = GameObject.Find ("Musicians");
		if (current_state == "Finish"){
			musicians.SetActive (false);
			SceneManager.LoadScene (0);
			return;
		}

		if (current_state == state_list [index]) {
			// Set musician
			musicians.transform.GetChild(index).gameObject.SetActive(true);
			// Change Text
			GameObject.FindGameObjectWithTag ("tst_tag2").GetComponent<Text>().text = current_state;
			// Off finished
			signal_bar_finish_bool = false;
			// Light up panel
			instruction_panel.transform.GetChild(index).gameObject.SetActive(true);

			// Activate State1 Gesture Check Box
			Gesture_Holder.transform.GetChild (index).gameObject.SetActive (true);

			// Try to get all instruction lighted
			// Actively changing text panel
			if (instrument == state_list[0]){
				current_input_from_gb = Gesture_Guitar_Tutorial.gesture_Msg;
			}
			if (instrument == state_list[1]){
				current_input_from_gb = Gesture_Violin_Tutorial.gesture_Msg;
			}
			if (instrument == state_list[2]){
				current_input_from_gb = Gesture_Piano_Tutorial.gesture_Msg;
			}
			if (instrument == state_list[3]){
				current_input_from_gb = Gesture_Trumpet_Tutorial.gesture_Msg;
			}

			// Forward Bar
			if (current_input_from_gb.Contains (instrument)) {
				//print ("Enter Guitar");
				signal_bar_start_bool = true;
			} 

			// Backward Bar
			if (!current_input_from_gb.Contains (instrument)) {
				//print ("Enter Guitar");
				signal_bar_start_bool = false;
			} 
			string signal = ProgressBarBehaviour_tutorial.ProgressBarBehaviour_tutorial.progress_bar_signal;

			// If all correct start progress bar
			if (signal == "Bar Completed"){
				print ("Bar completed");
				// Off bar
				signal_bar_start_bool = false;
				signal_bar_finish_bool = true;

				// Off panel
				instruction_panel.transform.GetChild(index).gameObject.SetActive(false);

				// Off check box
				Gesture_Holder.transform.GetChild (index).gameObject.SetActive (false);

				// Reset Signal
				ProgressBarBehaviour_tutorial.ProgressBarBehaviour_tutorial.progress_bar_signal = "No Signal";

				// Off musician
				musicians.transform.GetChild(index).gameObject.SetActive(false);

				// Move to next state
				if (index<3) {
					current_state = state_list [index + 1];
				}

				if (index >= 3) {
					current_state = "Finish";
				}
			}


		}
	}

	void Checking_Gesture(){
		Check_Block (0, "Guitar");
		Check_Block (1, "Violin");
		Check_Block (2, "Piano");
		Check_Block (3, "Trumpet");

	}

	// Update is called once per frame
	void Update () {
		Checking_Gesture ();
	}



}
