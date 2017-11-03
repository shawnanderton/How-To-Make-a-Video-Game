using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    private bool gameStarted = false;
    [SerializeField]
    private Text gameStateText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BirdMovement birdMovement;
    [SerializeField]
    private FollowCamera followCamera;
    private float restartDelay = 3f;
    private float restartTimer;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();

        playerMovement.enabled = false;
        birdMovement.enabled = false;
        followCamera.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(!gameStarted && Input.GetKeyUp(KeyCode.Space))
        {
            StartGame();
        }
        if(!playerHealth.alive)
        {
            EndGame();

            restartTimer = restartTimer + Time.deltaTime;

            if(restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
		
	}


    private void StartGame()
    {
        gameStarted = true;
        gameStateText.color = Color.clear;
        playerMovement.enabled = true;
        birdMovement.enabled = true;
        followCamera.enabled = true;

    }

    private void EndGame()
    {
        gameStarted = false;
        gameStateText.color = Color.white;
        gameStateText.text = "Game Over!";
        player.SetActive(false);
    }
}
