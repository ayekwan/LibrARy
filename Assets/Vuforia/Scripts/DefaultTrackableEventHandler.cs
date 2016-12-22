/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using UnityEngine.EventSystems;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class DefaultTrackableEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES
		private Animator anim;
		private TrackableBehaviour mTrackableBehaviour;
		private bool mShowGUIButton = false;
		private Rect mButtonRect = new Rect(Screen.width - 150,Screen.height - 150,100,100);
		public Renderer rend;
		public int id;
		//public float speed = 2;
		public bool animateA1Right = false;
		public bool animateA1Up = false;
		public bool animateA2Right = false;
		public bool animateA2Up = false;
		public bool animateA2Left = false;
		public bool animateA3Left = false;
		public bool animateA3Right = false;
		public bool animateA3Up = false;
		public bool animateA4Left = false;
		public bool animateA4Up = false;
		public bool animateA5Right = false;
		public bool animateA5Down = false;
		public bool animateA6Left = false;
		public bool animateA6Right = false;
		public bool animateA6Down = false;
		public bool animateA7Left = false;
		public bool animateA7Right = false;
		public bool animateA7Down = false;
		public bool animateA8Left = false;
		public bool animateA8Down = false;
		//private bool dirRight = true;
		private A1DatabaseHandler A1database;
		private A2DatabaseHandler A2database;
		private A3DatabaseHandler A3database;
		private A4DatabaseHandler A4database;
		private A5DatabaseHandler A5database;
		private A6DatabaseHandler A6database;
		private A7DatabaseHandler A7database;
		private A8DatabaseHandler A8database;
		private LoadDatabase database;
		bool inventoryActive  = false;
		bool bookFound  = false;
		bool bookFoundLeft = false;
		bool bookFoundRight = false;
		bool A4RightRed = false;
		GameObject A1Right,A1Left,A1Up,A1Down;
		GameObject A2Right,A2Left,A2Up,A2Down;
		GameObject A3Right,A3Left,A3Up,A3Down;
		GameObject A4Right,A4Left,A4Up,A4Down;
		GameObject A5Right,A5Left,A5Up,A5Down;
		GameObject A6Right,A6Left,A6Up,A6Down;
		GameObject A7Right,A7Left,A7Up,A7Down;
		GameObject A8Right,A8Left,A8Up,A8Down;
		private Rect mButtonRect1 = new Rect((Screen.width/2)+100, Screen.height/2,60,60);
		private Rect mButtonRect2 = new Rect((Screen.width/2)-100, Screen.height/2,150,50);
		private Rect temp = new Rect((Screen.width/2)-50, Screen.height/2,150,60);
		
		private Vector3 pos1 = new Vector3(-15,0,0);
		private Vector3 pos2 = new Vector3(15,0,0);
		private Vector3 pos3 = new Vector3(0,0,-20);
		private Vector3 pos4 = new Vector3(0,0,20);

		//string book;
		#endregion // PRIVATE_MEMBER_VARIABLES
		
		#region UNTIY_MONOBEHAVIOUR_METHODS
		
		void Start()
		{
			
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			anim = GetComponent<Animator> ();
		}
		
		
		
		#endregion // UNTIY_MONOBEHAVIOUR_METHODS
		
		
		
		#region PUBLIC_METHODS
		
		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED ||
			    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
				
				mShowGUIButton = true;
				
			}
			else
			{
				OnTrackingLost();
				
			}
			
		}

		GetBookName getBook;
		string bookName;

		void OnGUI(){
			getBook = (GetBookName)GameObject.Find ("GetBookName").GetComponent (typeof(GetBookName));
			bookName = getBook.getBookName();
			//print ("book name: " + bookName);

			#region LOAD_DATA
			A1database = (A1DatabaseHandler)GameObject.Find ("A1_8").GetComponent (typeof(A1DatabaseHandler));
			A2database = (A2DatabaseHandler)GameObject.Find ("A2_8").GetComponent (typeof(A2DatabaseHandler));
			A3database = (A3DatabaseHandler)GameObject.Find ("A3_8").GetComponent (typeof(A3DatabaseHandler));
			A4database = (A4DatabaseHandler)GameObject.Find ("A4_8").GetComponent (typeof(A4DatabaseHandler));
			A5database = (A5DatabaseHandler)GameObject.Find ("A5_8").GetComponent (typeof(A5DatabaseHandler));
			A6database = (A6DatabaseHandler)GameObject.Find ("A6_8").GetComponent (typeof(A6DatabaseHandler));
			A7database = (A7DatabaseHandler)GameObject.Find ("A7_8").GetComponent (typeof(A7DatabaseHandler));
			A8database = (A8DatabaseHandler)GameObject.Find ("A8_8").GetComponent (typeof(A8DatabaseHandler));
			#endregion LOAD_DATA

			//print ("length = " + A1database.bookList[0].name);

			#region A1
			if (mTrackableBehaviour.TrackableName == "A1_8" && mShowGUIButton) {
				A1Left = GameObject.Find ("A1Left");
				A1Right = GameObject.Find ("A1Right");
				A1Up = GameObject.Find ("A1Up");
				A1Down = GameObject.Find ("A1Down");
				// Check if the book is in the Shelf A1

				for(int i = 0; i < A1database.bookList.Length; i++){
					
					//print (A1database.bookList[i].name);
					if(A1database.bookList[i].name.Equals(bookName)){
						//print(A1database.bookList[i].side);
						if(A1database.bookList[i].side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						//print ("you got it");
						anim.Play("WAIT04",-1);
					}

				}

				/*foreach (Book book in A1database.bookList) {
					if (bookName.Equals(book.name)) {
						if(book.side.Equals("Left")){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}
				}*/
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Right.GetComponent<Renderer> ().material.color = Color.green;
						//A1Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
						animateA1Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Right.GetComponent<Renderer> ().material.color = Color.red;
						animateA1Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Right.GetComponent<Renderer> ().material.color = Color.red;
						animateA1Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Up.GetComponent<Renderer> ().material.color = Color.green;
						animateA1Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA1Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA1Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A1Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA1Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				
			}
			#endregion A1

			#region A2
			if (mTrackableBehaviour.TrackableName == "A2_8" && mShowGUIButton) {
				A2Left = GameObject.Find ("A2Left");
				A2Right = GameObject.Find ("A2Right");
				A2Up = GameObject.Find ("A2Up");
				A2Down = GameObject.Find ("A2Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A2Left.GetComponent<Renderer> ().material.color = Color.green;
						animateA2Left = true;
						anim.Play("RUN00_R",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A2Right.GetComponent<Renderer> ().material.color = Color.green;
						animateA2Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A2Right.GetComponent<Renderer> ().material.color = Color.red;
						animateA2Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A2Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA2Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A2Up.GetComponent<Renderer> ().material.color = Color.green;
						animateA2Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A2Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA2Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A2Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA2Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				
			}
			#endregion A2

			#region A3
			if (mTrackableBehaviour.TrackableName == "A3_8" && mShowGUIButton) {
				A3Left = GameObject.Find ("A3Left");
				A3Right = GameObject.Find ("A3Right");
				A3Up = GameObject.Find ("A3Up");
				A3Down = GameObject.Find ("A3Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A3Left.GetComponent<Renderer> ().material.color = Color.red;
						animateA3Left = true;
						anim.Play("RUN00_R",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Left.GetComponent<Renderer> ().material.color = Color.green;
						animateA3Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Right.GetComponent<Renderer> ().material.color = Color.green;
						animateA3Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA3Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA3Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Up.GetComponent<Renderer> ().material.color = Color.green;
						animateA3Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA3Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
			}
			#endregion A3

			#region A4
			if (mTrackableBehaviour.TrackableName == "A4_8" && mShowGUIButton) {
				A4Left = GameObject.Find ("A4Left");
				A4Right = GameObject.Find ("A4Right");
				A4Up = GameObject.Find ("A4Up");
				A4Down = GameObject.Find ("A4Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A4Left.GetComponent<Renderer> ().material.color = Color.red;
						animateA4Left = true;
						anim.Play("RUN00_R",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A4Left.GetComponent<Renderer> ().material.color = Color.red;
						animateA4Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A4Left.GetComponent<Renderer> ().material.color = Color.green;
						animateA4Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A4Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA4Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A4Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA4Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A4Up.GetComponent<Renderer> ().material.color = Color.red;
						animateA4Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A3Up.GetComponent<Renderer> ().material.color = Color.green;
						animateA4Up = true;
						anim.Play("WALK00_B",-1);
					}	
				}
			}
			#endregion A4

			#region A5
			if (mTrackableBehaviour.TrackableName == "A5_8" && mShowGUIButton) {
				A5Left = GameObject.Find ("A5Left");
				A5Right = GameObject.Find ("A5Right");
				A5Up = GameObject.Find ("A5Up");
				A5Down = GameObject.Find ("A5Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A5Down.GetComponent<Renderer> ().material.color = Color.green;
						animateA5Down = true;
						anim.Play("RUN00_F",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A5Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA5Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A5Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA5Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A5Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA5Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A5Right.GetComponent<Renderer> ().material.color = Color.green;
						animateA5Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A5Right.GetComponent<Renderer> ().material.color = Color.red;
						animateA5Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A5Right.GetComponent<Renderer> ().material.color = Color.red;
						animateA5Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
			}
			#endregion A5

			#region A6
			if (mTrackableBehaviour.TrackableName == "A6_8" && mShowGUIButton) {
				A6Left = GameObject.Find ("A6Left");
				A6Right = GameObject.Find ("A6Right");
				A6Up = GameObject.Find ("A6Up");
				A6Down = GameObject.Find ("A6Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A6Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA6Down = true;
						anim.Play("RUN00_F",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A6Down.GetComponent<Renderer> ().material.color = Color.green;
						animateA6Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A6Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA6Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A6Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA6Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A6Left.GetComponent<Renderer> ().material.color = Color.green;
						animateA6Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A6Right.GetComponent<Renderer> ().material.color = Color.green;
						animateA6Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A6Right.GetComponent<Renderer> ().material.color = Color.red;
						animateA6Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
			}
			#endregion A6

			#region A7
			if (mTrackableBehaviour.TrackableName == "A7_8" && mShowGUIButton) {
				A7Left = GameObject.Find ("A7Left");
				A7Right = GameObject.Find ("A7Right");
				A7Up = GameObject.Find ("A7Up");
				A7Down = GameObject.Find ("A7Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A7Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA7Down = true;
						anim.Play("RUN00_F",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A7Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA7Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A7Down.GetComponent<Renderer> ().material.color = Color.green;
						animateA7Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A7Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA7Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A7Left.GetComponent<Renderer> ().material.color = Color.red;
						animateA7Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A7Left.GetComponent<Renderer> ().material.color = Color.green;
						animateA7Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A7Right.GetComponent<Renderer> ().material.color = Color.green;
						animateA7Right = true;
						anim.Play("RUN00_L",-1);
					}	
				}
			}
			#endregion A7

			#region A8
			if (mTrackableBehaviour.TrackableName == "A8_8" && mShowGUIButton) {
				A8Left = GameObject.Find ("A8Left");
				A8Right = GameObject.Find ("A8Right");
				A8Up = GameObject.Find ("A8Up");
				A8Down = GameObject.Find ("A8Down");
				foreach (Book book in A1database.bookList) {
					if (bookName.Equals (book.name)) {
						A8Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA8Down = true;
						anim.Play("RUN00_F",-1);
					}
				}
				foreach (Book book in A2database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A8Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA8Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A3database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A8Down.GetComponent<Renderer> ().material.color = Color.red;
						animateA8Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A4database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A8Down.GetComponent<Renderer> ().material.color = Color.green;
						animateA8Down = true;
						anim.Play("RUN00_F",-1);
					}	
				}
				foreach (Book book in A5database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A8Left.GetComponent<Renderer> ().material.color = Color.red;
						animateA8Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A6database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A8Left.GetComponent<Renderer> ().material.color = Color.red;
						animateA8Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A7database.bookList) {
					
					if (bookName.Equals (book.name)) {
						A8Left.GetComponent<Renderer> ().material.color = Color.green;
						animateA8Left = true;
						anim.Play("RUN00_R",-1);
					}	
				}
				foreach (Book book in A8database.bookList) {
					
					if (bookName.Equals (book.name)) {
						
						if(book.side == "Left"){
							bookFoundLeft = true;
						}else{
							bookFoundRight = true;
						}
						anim.Play("WAIT04",-1);
					}	
				}
			}
			#endregion A8

			if (animateA1Right == true) {
				
				A1Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA1Up == true) {
				
				A1Up.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos3, pos4, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA2Left == true) {
				
				A2Left.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos2, pos1, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA2Right == true) {
				
				A2Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA2Up == true) {
				
				A2Up.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos3, pos4, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA3Left == true) {
				
				A3Left.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos2, pos1, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA3Right == true) {
				
				A3Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA3Up == true) {
				
				A3Up.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos3, pos4, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA4Left == true) {
				
				A4Left.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos2, pos1, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA4Up == true) {
				
				A4Up.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos3, pos4, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA5Right == true) {
				
				A5Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA5Down == true) {
				
				A5Down.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos4, pos3, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA6Left == true) {
				
				A6Left.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos2, pos1, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA6Right == true) {
				
				A6Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA6Down == true) {
				
				A6Down.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos4, pos3, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA7Left == true) {
				
				A7Left.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos2, pos1, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA7Right == true) {
				
				A7Right.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA7Down == true) {
				
				A7Down.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos4, pos3, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA8Left == true) {
				
				A8Left.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos2, pos1, Mathf.PingPong (Time.time * 2, 1.0f));
			}
			if (animateA8Down == true) {
				
				A8Down.GetComponent<Renderer> ().transform.position = Vector3.Lerp (pos4, pos3, Mathf.PingPong (Time.time * 2, 1.0f));
			}

			GUIStyle myfont = new GUIStyle ();
			myfont.fontSize = 32;
	
			if (bookFound) {
				
				GUI.Box (mButtonRect2, "The book is here!");
			}
						if (bookFoundLeft) {
							
							GUI.Box (mButtonRect2, "The book is on the left!", myfont);
						}
						if (bookFoundRight) {
							
							GUI.Box (mButtonRect2, "The book is on the Right!", myfont);
						}

		}




		#endregion // PUBLIC_METHODS
		
		#region PRIVATE_METHODS
		
		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			
			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}
			
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			
		}
		
		
		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}
			
			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
			
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			mShowGUIButton = false;
			bookFound = false;
							bookFoundLeft = false;
							bookFoundRight = false;
		}
		
		#endregion // PRIVATE_METHODS
	}
}