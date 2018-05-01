using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_Management : MonoBehaviour {
	public InputField mainInputField;

	public void update_player_session(){
		Session_ID.update_player_id (mainInputField.text);
	}
}
