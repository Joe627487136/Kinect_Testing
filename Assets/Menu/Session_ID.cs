using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session_ID : MonoBehaviour {
	public static string player_id;
	public static string game_difficulty;


	public static void update_player_id(string name){
		player_id = name;
	}

	public static string get_player_id(){
		return player_id;
	}

	public static void update_game_difficulty(string d){
		game_difficulty = d;
	}

	public static string get_difficulty(){
		return game_difficulty;
	}
}
