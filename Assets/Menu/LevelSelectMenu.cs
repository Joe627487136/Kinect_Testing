
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour {
	public Button hardButton;//, level03Button,level04Button;
	public string player_id;
	int levelReached;
	public int player_score;

	void Start() {
		player_id = Session_ID.get_player_id ();
		player_score = PlayerPrefs.GetInt (player_id);
		string ot = "Current score: " + player_score.ToString();
		print (ot);
		if (player_score < 100) {
			hardButton.interactable = false;
		}
		if (player_score >= 100) {
			hardButton.interactable = true;
		}
	}

	public void update_difficulty(string diff){
		Session_ID.update_game_difficulty (diff);
	}

}



