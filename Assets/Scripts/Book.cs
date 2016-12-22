using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {

	public string name;
	public string callNum;
	public string bookshelf;
	public string side;

	public Book(string name, string callNum, string bookshelf, string side){
		this.name = name;
		this.bookshelf = bookshelf;
		this.callNum = callNum;
		this.side = side;
	}


}
