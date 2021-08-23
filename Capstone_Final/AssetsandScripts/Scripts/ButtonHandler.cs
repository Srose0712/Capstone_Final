using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{

	public Button startButton;
	public Button resetButton;
	public Button submitButton;
	public Button exitButton;
	public bool startGame = false;
	public bool restartGame = false;
	public bool submitName = false;
	public bool exit = false;

	// Use this for initialization
	void Start()
	{

		Button sButton = startButton.GetComponent<Button>();
		sButton.onClick.AddListener(StartGame);
		Button rButton = resetButton.GetComponent<Button>();
		rButton.onClick.AddListener(Restart);
		Button subButton = submitButton.GetComponent<Button>();
		subButton.onClick.AddListener(Submit);
		Button exButton = exitButton.GetComponent<Button>();
		exButton.onClick.AddListener(Exit);

	}

	// Update is called once per frame
	void Update()
	{

	}

	void StartGame()
	{
		startGame = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene("Asteroids");
	}

	public void Submit()
    {
		submitName = true;
    }

	public void Exit()
    {
		exit = true;
    }
}
