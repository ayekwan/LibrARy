using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using SQLite4Unity3d;
public class A7DatabaseHandler : MonoBehaviour {
	
	public Book[] bookList = new Book[]{};
	
	string conn;
	
	// Use this for initialization
	void Start () {
		
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			conn = "URI=file:" + Application.dataPath + "/Raw/Database.s3db";
		} else {
			
			conn = "URI=file:" + Application.dataPath + "/StreamingAssets/Database.s3db"; //Path to database.
		}
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		
		string sqlQuery = "SELECT * FROM BookLists WHERE Bookshelf = 'A7'";
		dbcmd.CommandText = sqlQuery;
		
		IDataReader reader = dbcmd.ExecuteReader();
		int i = 0;
		while (reader.Read())
		{
			//bookID = reader.GetInt32(0);
			bookList[i] = new Book(reader.GetString(1),reader.GetString(2),reader.GetString(3), reader.GetString(4));
			//callNum = reader.GetString(2);
			//bookShelf[i] = reader.GetString(3);	
			print( "  book name ="+bookList[i].name + " callNum = " + bookList[i].callNum + " side = " + bookList[i].side);
			i++;
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
	
	
	
}

