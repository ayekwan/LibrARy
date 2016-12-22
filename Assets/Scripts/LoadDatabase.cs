using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using SQLite4Unity3d;
using UnityEngine.UI;

public class LoadDatabase : MonoBehaviour {
	
	public string[] bookList;
	public string[] callNumList;
	string conn;
	public InputField user_input;
	private static LoadDatabase _instance;
	public static Dropdown menu;

	public void Awake(){

		DontDestroyOnLoad (this.gameObject);
	}

	/*public void Start(){
		menu.onValueChanged.AddListener (delegate {
			Debug.Log("menu value: " + menu.value);
		});
	}
	*/
	public void Load () {
		
		String input = user_input.text;
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			conn = "URI=file:" + Application.dataPath + "/Raw/Database.s3db";
		} else {
			
			conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Database.s3db"; //Path to database.
		}
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();


		string sqlQuery = "SELECT * FROM BookLists WHERE BookName LIKE " + "'%" + input + "%'" +
			"OR CallNumber LIKE " + "'%" + input + "%'";
		dbcmd.CommandText = sqlQuery;
		
		IDataReader reader = dbcmd.ExecuteReader();
		int i = 0;
		while (reader.Read())
		{
			bookList[i] = reader.GetString(1);
			callNumList[i] = reader.GetString(2);
			i++;
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}

	public string[] getBookList(){
		return bookList;
	}

	public string[] getCallNumList(){
		return callNumList;
	}

}
