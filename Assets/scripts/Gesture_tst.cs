using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Gesture_tst : MonoBehaviour {

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
	void Check_trumpet(){
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
			}
		}			
		if (gestureBool) {
			gesture_Msg = "Trumpet";
		}
    }
	void CheckPiano(){
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

		bool[] piano_boollist = new bool[1];
		bool currCheck;
		//1st Check: Hands within a range of Elbow for y & x 
		if ((vc_R_Hand_to_R_Elbow.y < 2.0 && vc_R_Hand_to_R_Elbow.y > -2.0) && (vc_L_Hand_to_L_Elbow.y < 2.0 && vc_L_Hand_to_L_Elbow.y > -2.0)
			&& vc_R_Hand_to_R_Elbow.x < 2.0 && vc_L_Hand_to_L_Elbow.x > -2.0)
		{
			currCheck=true;
		}
		else {
			currCheck=false;
			}
		piano_boollist [0] = currCheck;

		bool gestureBool=true;
		for (int i=0; i < piano_boollist.Length; i++) {
			if(piano_boollist[i]==false){
				gestureBool=false;
			}
		}
		if (gestureBool) {
			gesture_Msg = "Piano";
		}
	}
	void CheckGuitar(){
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
		//___________________________________________________

		bool[] guitar_boollist = new bool[4];
		bool currCheck;
		//1st Check: Both Elbow Below Shoulder (a short distance below)
		if (vc_L_Elbow_to_L_Shoulder.y <0.4 && vc_R_Elbow_to_R_Shoulder.y <0.4){
			currCheck=true;
		}
		else {
			currCheck=false;
		}
		guitar_boollist [0] = currCheck;

		//2nd Check: Left hand -> left elbow (x direction)
		if (vc_L_Hand_to_L_Elbow.x>-3.5&&vc_L_Hand_to_L_Elbow.x<0)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		guitar_boollist[1]=currCheck;

		//3rd Check: Left hand above left elbow (x direction)
		if (vc_L_Hand_to_L_Elbow.y>0&&vc_L_Hand_to_L_Elbow.y<2.3)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		guitar_boollist[2]=currCheck;

		//4th Check: Right hand to the right of right elbow (x direction)
		if (vc_R_Hand_to_R_Elbow.x<0.8&&vc_R_Hand_to_R_Elbow.y>-2)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		guitar_boollist[3]=currCheck;


		bool gestureBool=true;
		for (int i=0; i < guitar_boollist.Length; i++) {
			if(guitar_boollist[i]==false){
				gestureBool=false;
			}
		}
		if (gestureBool) {
			gesture_Msg = "Guitar";
		}
	}
	void CheckViolin(){
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
		//___________________________________________________


		bool[] violin_boollist = new bool[5];
		bool currCheck;
		//1st Check: Left Elbow Below Shoulder (a short distance below)
		if (vc_L_Elbow_to_L_Shoulder.y <0.4 && vc_R_Elbow_to_R_Shoulder.y >0.4)
		{
			currCheck=true;
		}
		else {
			currCheck=false;
		}
		violin_boollist [0] = currCheck;

		//2nd Check: Right Elbow Above Shoulder (a short distance below)
		if (vc_R_Elbow_to_R_Shoulder.y >0.4)
		{
			currCheck=true;
		}
		else {
			currCheck=false;
		}
		violin_boollist [1] = currCheck;

		//3rd Check: Left hand -> left elbow (x direction)
		if (vc_L_Hand_to_L_Elbow.x>-3.5&&vc_L_Hand_to_L_Elbow.x<0)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		violin_boollist[2]=currCheck;

		//4th Check: Left hand -> left elbow (x direction)
		if (vc_L_Hand_to_L_Elbow.y>2.35)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		violin_boollist[3]=currCheck;

		//5th Check: Right hand <- right elbow (x direction)
		if (vc_R_Hand_to_R_Elbow.x<0.8&&vc_R_Hand_to_R_Elbow.y>-2)
		{
			currCheck=true;
		}
		else{
			currCheck=false;
		}
		violin_boollist[4]=currCheck;
		bool gestureBool=true;
		for (int i=0; i < violin_boollist.Length; i++) {
			if(violin_boollist[i]==false){
				gestureBool=false;
			}
		}
		if (gestureBool) {
			gesture_Msg = "Violin";
		}
	}
	// Update is called once per frame
	void Update () {
		gesture_Msg = "Error";
		Check_trumpet ();
		CheckPiano ();
		CheckGuitar ();
		CheckViolin ();
	}
}
