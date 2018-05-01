using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Gesture_Trumpet_Tutorial : MonoBehaviour {

	public GameObject Cube_man;
	GameObject Hip_Center;
	GameObject Spine;
	GameObject Neck;
	GameObject Head;
	GameObject Shoulder_Left;
	GameObject Elbow_Left;
	GameObject Wrist_Left;
	GameObject Hand_Left;
	GameObject Shoulder_Right;
	GameObject Elbow_Right;
	GameObject Wrist_Right;
	GameObject Hand_Right;
	Vector3 vc_R_Hand_to_R_Elbow;
	Vector3 vc_R_Hand_to_L_Elbow;
	Vector3 vc_L_Hand_to_R_Elbow;
	Vector3 vc_L_Hand_to_L_Elbow;
	Vector3 vc_L_Elbow_to_L_Shoulder;
	Vector3 vc_R_Elbow_to_R_Shoulder;
	Vector3 vc_R_Hand_to_L_Hand;
	Vector3 Middle_of_two_Hands;
	Vector3 vc_Md_Hands_to_Head;
    public static string gesture_Msg;

	void init_variables(){
		Hip_Center = Cube_man.transform.Find("00_Hip_Center").gameObject;
		Spine = Cube_man.transform.Find("01_Spine").gameObject;
		Neck = Cube_man.transform.Find("02_Neck").gameObject;
		Head = Cube_man.transform.Find("03_Head").gameObject;
		Shoulder_Left = Cube_man.transform.Find("04_Shoulder_Left").gameObject;
		Elbow_Left = Cube_man.transform.Find("05_Elbow_Left").gameObject;
		Wrist_Left = Cube_man.transform.Find("06_Wrist_Left").gameObject;
		Hand_Left = Cube_man.transform.Find("07_Hand_Left").gameObject;
		Shoulder_Right = Cube_man.transform.Find("08_Shoulder_Right").gameObject;
		Elbow_Right = Cube_man.transform.Find("09_Elbow_Right").gameObject;
		Wrist_Right = Cube_man.transform.Find("10_Wrist_Right").gameObject;
		Hand_Right = Cube_man.transform.Find("11_Hand_Right").gameObject;
	}



	// Use this for initialization
	void Start () {
		// Create joint varibales
		init_variables ();

	}
	//
	void CheckTrumpet(){
		bool[] trumpet_boollist=new bool[5];


		// Relationship Creation
		vc_R_Hand_to_R_Elbow = Hand_Right.transform.position - Elbow_Right.transform.position; //(1.1,-14.6,2.7)
		vc_R_Hand_to_L_Elbow = Hand_Right.transform.position - Elbow_Left.transform.position;
		vc_L_Hand_to_R_Elbow = Hand_Left.transform.position - Elbow_Right.transform.position;
		vc_L_Hand_to_L_Elbow = Hand_Left.transform.position - Elbow_Left.transform.position;
		vc_L_Elbow_to_L_Shoulder = Elbow_Left.transform.position - Shoulder_Left.transform.position;
		vc_R_Elbow_to_R_Shoulder = Elbow_Right.transform.position - Shoulder_Right.transform.position;
		vc_R_Hand_to_L_Hand = Hand_Right.transform.position - Hand_Left.transform.position;
		Middle_of_two_Hands = (Hand_Right.transform.position + Hand_Left.transform.position )/ 2;
		vc_Md_Hands_to_Head = Middle_of_two_Hands - Head.transform.position;

		//_______________Troubleshooting Codes______________
		string check1;
		string check2;
		string check3;
		string check4;
		string check5;
		//___________________________________________________

		//1st Check: Hands Above Elbow 
		bool currCheck;
		if (vc_R_Hand_to_R_Elbow.y > 0 && vc_L_Hand_to_L_Elbow.y>0)
		{		
			currCheck=true;
		}
		else {
			currCheck=false;
		}
		trumpet_boollist[0]=currCheck;

		//2nd Check: Elbow below Shoulder
		if (vc_L_Elbow_to_L_Shoulder.y < 0&&vc_R_Elbow_to_R_Shoulder.y < 0)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		trumpet_boollist[1]=currCheck;

		//3rd Check: Right Hands & Left Hand Close togther
		double distance = Math.Sqrt(Math.Pow(vc_R_Hand_to_L_Hand.x,2) + Math.Pow(vc_R_Hand_to_L_Hand.y,2) + Math.Pow(vc_R_Hand_to_L_Hand.z, 2));
		if (distance < 3)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		trumpet_boollist[2]=currCheck;

		//4th Check: Middle of 2 hands are below head
		if (vc_Md_Hands_to_Head.y < 0)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		trumpet_boollist[3]=currCheck;

		//5th Check: Middle of 2 hands, x directions are not too far from head
		if ((vc_Md_Hands_to_Head.x <1) && (vc_Md_Hands_to_Head.x > -1))
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		trumpet_boollist[4]=currCheck;
		//Loop through trumpet_boollist if all true means its trumpet condition
		bool gestureBool=true;
		for (int i=0; i < trumpet_boollist.Length; i++) {
			if(trumpet_boollist[i]==false){
				gestureBool=false;
			}else {
				gesture_Msg += (i + 1);
			}
		}			
		if (gestureBool) {
			gesture_Msg = "Trumpet";
		}
    }
	/** gesture_Msg outputs
	 * gesutre_Msg: "1235" (when checks 1,2,3,5 is correct)
	 * gesutre_Msg: "Trumpet" (when all chcks is correct)
	 * 	 
	 * Trumpet:
	 * Total Checks: 5
	 * 
	 * Reccomended
	 * 1) Hands Above Elbow
	 * 2) Elbow Below Shoulder
	 * 3) Right Hands & Left Hands close together
	 * 4) Middle of 2 hands are below head
	 * 5) Hands near to your nose
	*/	
	// Update is called once per frame
	void Update () {
		gesture_Msg = "";
		CheckTrumpet ();
	}
}
