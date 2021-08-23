using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class TextBehavior : MonoBehaviour {

    [SerializeField]
    private GameObject text;
	public bool gameBegan = false;
	public ButtonHandler buttonAction;
	public GameObject startButton;
	public GameObject restartButton;
	public GameObject submitButton;
	public Text scoreText;
	public PlayerController death;
	public GameObject background;
	public GameObject PlayerName;
	public Text Name;
	public SqliteTest dbFunctions;
	public GameObject panel;
	public GameObject exitButton;
	

	public int scoreNum = 0;

	// Use this for initialization
	void Start () {


		dbFunctions.Display();
		Text displayText = this.gameObject.GetComponent<Text>();
		displayText.text = "Asteroid Blaster";
		
		startButton.SetActive(false);
		restartButton.SetActive(false);
        scoreText = text.GetComponent<Text>();


	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "Score: " + scoreNum.ToString();
		
		if(buttonAction.submitName == true)
        {
			NameSubmit();
			StartGame();
			
        }


		if (buttonAction.startGame == true)
		{

			PlayerStatus();

		}

		if (death.playerDeath == true )
		{
			DeathText();
			death.playerDeath = false;
			
		}

		if (buttonAction.exit == true)
        {
			Application.Quit();
        }
		
	}

	public void StartGame()
    {
		Text displayText = this.gameObject.GetComponent<Text>();
		displayText.text = "Press Start To Begin!";
		startButton.SetActive(true);
	}
	void PlayerStatus()
	{
		Text displayText = this.gameObject.GetComponent<Text>();
		displayText.text = " ";
		startButton.SetActive(false);
	}

	public void DeathText()
	{
		Text displayText = this.gameObject.GetComponent<Text>();
		displayText.text = "You have died!";
		restartButton.SetActive(true);
		dbFunctions.Insert(Name.text.ToString(), scoreNum);
		
	}

	public void NameSubmit()
    {
		Text displayText = this.gameObject.GetComponent<Text>();
		displayText.text = " ";
		panel.SetActive(false);
		exitButton.SetActive(false);
		submitButton.SetActive(false);
		background.SetActive(false);
		PlayerName.SetActive(false);
	}
}