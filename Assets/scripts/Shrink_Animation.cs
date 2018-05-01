using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink_Animation : MonoBehaviour {
	public AnimationCurve ac;
	Vector3[] s;
	float playSpeed = 2;
	float timeOffset = 0;
	bool flag = false;
	int instrument_amount = 4;
	string diff;

	// Use this for initialization
	void Start () {
		diff = Session_ID.get_difficulty();
		s = new Vector3[instrument_amount];
		int tcnt = transform.childCount;
		for (int i=0;i<tcnt;i++){
			s [i] = transform.GetChild (i).localScale;
		}
		timeOffset = Random.value;
	}

	void Shrink(int index, float r){
		transform.GetChild(index).transform.localScale = new Vector3 (s[index].x * r, s[index].y * r, s[index].z);
	}

	void Shrink_all(float r){
		for (int i = 0; i < instrument_amount; i++) {
			Shrink (i, r);
		}
	}

	void Play_elemental_Shrink_Signal(){
		string instrument = SongManager.current_instrument;
		float r = ac.Evaluate (Time.time * playSpeed);
		if (instrument == "V"){
			Shrink (0, r);
			//transform.GetChild(0).transform.localScale = new Vector3 (s[0].x * r, s[0].y * r, s[0].z);
		}
		else if (instrument == "O"){
			Shrink (1, r);
			//transform.GetChild(1).transform.localScale = new Vector3 (s[1].x * r, s[1].y * r, s[1].z);
		}
		else if (instrument == "P"){
			Shrink (2, r);
			//transform.GetChild(2).transform.localScale = new Vector3 (s[2].x * r, s[2].y * r, s[2].z);
		}
		else if (instrument == "G"){
			Shrink (3, r);
			//transform.GetChild(3).transform.localScale = new Vector3 (s[3].x * r, s[3].y * r, s[3].z);
		}
	}
	void Play_All_Shrink_Signal(){
		float r = ac.Evaluate (Time.time * playSpeed);
		string instrument = SongManager.current_instrument;
		if (instrument!="Nothing")
			Shrink_all (r);
	}
	
	// Update is called once per frame
	void Update () {
		if (diff == "easy") {
			Play_elemental_Shrink_Signal ();
		}
		if (diff == "hard") {
			Play_All_Shrink_Signal ();
		}
	}
}
