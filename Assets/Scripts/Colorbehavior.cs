using UnityEngine;
using System.Collections;

public class Colorbehavior : MonoBehaviour {
	private Rect mButtonRect = new Rect(Screen.width - 150,Screen.height - 100,80,80);
	int i = 2;
	//public bool bool_1 = true;
	
	void Start(){}

	void OnGUI(){
		
		GUI.color = Color.yellow;
		GUI.TextField (new Rect (Screen.width - 400, Screen.height - 50, 200, 20), "Please enter the book title", 40);

		if (GUI.Button(mButtonRect, "Search")) {
			
			
			{ 
				/*	GetComponent<Renderer> ().material.color = Color.green;*/
				
			}

			
			
			
		}
	}
}