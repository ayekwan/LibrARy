using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GetBookName : MonoBehaviour {

	private static string bookName; 
	private static GetBookName _instance;

	void Awake(){
		//if we don't have an [_instance] set yet
		//if(!_instance)
			//_instance = this ;
		//otherwise, if we do, kill this thing
		//else
			//Destroy(this.gameObject) ;

		DontDestroyOnLoad (this.gameObject);
	}

	public static void setBookName(GameObject book){	
		bookName = book.name;
		print (bookName + " is clicked");
	}

	public string getBookName(){
		return bookName;
	}
	
}
