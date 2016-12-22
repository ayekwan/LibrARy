using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Animator anim;
	private Rect mButtonRect = new Rect(Screen.width - 150,Screen.height - 150,100,100);
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GUI.Button (mButtonRect, "Search")) {
			print ("button press");
		}
	}
}
