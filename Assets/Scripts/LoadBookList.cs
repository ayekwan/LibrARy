using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadBookList : MonoBehaviour {
	
	public LoadDatabase bookData;
	public Transform bookParent;
	public GameObject button;
	//public string bookname;

	void Start(){
		ShowBookList ();
	}

	void Awake(){

		bookData = (LoadDatabase)GameObject.Find ("LoadDatabase").GetComponent (typeof(LoadDatabase));
	}

	void ShowBookList(){
		for (int i = 0; i < bookData.getBookList().Length; i++) {

			GameObject book_btn = Instantiate(button);
			book_btn.name = bookData.getBookList()[i];
			book_btn.GetComponentInChildren<Text>().text = bookData.getBookList()[i];
			book_btn.transform.SetParent(bookParent);
			Button b = book_btn.GetComponent<Button>();
			//GetBookName script = book.AddComponent<GetBookName>();
			b.onClick.AddListener(() => {
				GetBookName.setBookName(book_btn);
			});
		}

	}

	/*void onSceneGUI(){


		float yOffset = 0f;
		foreach (string book in BookList.bookList) {
			if(GUI.Button(new Rect (100,100+yOffset, 150,30), book)){
				Debug.Log("pressed " + book);
			}
			yOffset += 35;
		}
	}*/
}
