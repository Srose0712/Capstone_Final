using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SqliteTest : MonoBehaviour
{
	public List<Text> PlayerNames = new List<Text>();
	public List<Text> Highscores = new List<Text>();
	// Use this for initialization
	void Start()
	{

		// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "mydatabase";
		Debug.Log(Application.persistentDataPath);
		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Create table
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS Asteroid_High_Scores (PlayerID INTEGER PRIMARY KEY, PlayerName TEXT, Score INTEGER, Date DATE )";

        dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

		

		

		/*while (reader.Read())
		{
			Debug.Log("PlayerID: " + reader[0].ToString());
			Debug.Log("PlayerName: " + reader[1].ToString());
			Debug.Log("Score: " + reader[2].ToString());
			Debug.Log("Date: " + reader[3].ToString());
		}*/

		// Close connection
		dbcon.Close();

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Insert(string playerName, int scoreNum)
    {
		string currentDate = System.DateTime.Now.ToString("dd.MM.yyy");
		//Connection
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "mydatabase";
		Debug.Log(Application.persistentDataPath);

		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Insert values in table
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = "INSERT INTO Asteroid_High_Scores (PlayerName, Score, Date) VALUES ('" + playerName + "', '" + scoreNum + "', '"+ currentDate +"')";
		cmnd.ExecuteNonQuery();

		// Close connection
		dbcon.Close();
	}

	public void Display()
    {


		//Connection
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "mydatabase";
		//string connection = "C:\\Users\\sambr\\OneDrive\\Desktop\\Asteroid_Blaster\\Asteroids_Data";
		Debug.Log(Application.persistentDataPath);

		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

		// Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query = "SELECT * FROM Asteroid_High_Scores ORDER BY Score DESC LIMIT 5";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		List<System.Tuple<string, int>> scores = new List<System.Tuple<string,int>>();

		int i = 0;
		while (reader.Read() && i <= 5)
		{
			
			PlayerNames[i].text = reader["PlayerName"].ToString();
			Highscores[i].text = reader["Score"].ToString();
			i++;
		}


		// Close connection
		dbcon.Close();
		
	}

}
