using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public PlayerController player1, player2, player3, player4;

    bool gameStart, runGame;

    // Use this for initialization
    void Start()
    {
        GameOverScreen.SetActive(false);
        gameStart = false;
        runGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Start Game.
        /*
        if (gameStart == false)
        {
            if (player2 == null && player3 == null && player4 == null)
            {
                if (player1.playerReady)
                {
                    player1.StartLevel();
                    gameStart = true;
                }
            }
            else if (player3 == null && player4 == null)
            {
                if (player1.playerReady && player2.playerReady)
                {
                    player1.StartLevel();
                    player2.StartLevel();
                    gameStart = true;
                }
            }
            else if (player4 == null)
            {
                if (player1.playerReady && player2.playerReady && player3.playerReady)
                {
                    player1.StartLevel();
                    player2.StartLevel();
                    player3.StartLevel();
                    gameStart = true;
                }
            }
            else
            {
                if (player1.playerReady && player2.playerReady && player3.playerReady && player4.playerReady)
                {
                    player1.StartLevel();
                    player2.StartLevel();
                    player3.StartLevel();
                    player4.StartLevel();
                    gameStart = true;
                }
            }
        }
        else
        {
            if (player2 == null && player3 == null && player4 == null)
            {
                if (player1.playerReady)
                {
                    player1.StartLevel();
                    gameStart = true;
                }
            }
            else if (player3 == null && player4 == null)
            {
                if (player1.playerReady && player2.playerReady)
                {
                    player1.StartLevel();
                    player2.StartLevel();
                    gameStart = true;
                }
            }
            else if (player4 == null)
            {
                if (player1.playerReady && player2.playerReady && player3.playerReady)
                {
                    player1.StartLevel();
                    player2.StartLevel();
                    player3.StartLevel();
                    gameStart = true;
                }
            }
            else
            {
                if (player1.playerReady && player2.playerReady && player3.playerReady && player4.playerReady)
                {
                    player1.StartLevel();
                    player2.StartLevel();
                    player3.StartLevel();
                    player4.StartLevel();
                    gameStart = true;
                }
            }
        }
        */

        //End Game.
        if (player2 == null && player3 == null && player4 == null)
        {
            if (player1.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
        else if (player3 == null && player4 == null)
        {
            if (player1.IsPlayerDead() && player2.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
        else if (player4 == null)
        {
            if (player1.IsPlayerDead() && player2.IsPlayerDead() && player3.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
        else
        {
            if (player1.IsPlayerDead() && player2.IsPlayerDead() && player3.IsPlayerDead() && player4.IsPlayerDead())
            {
                GameOverScreen.SetActive(true);
            }
        }
    }

    public void StartGame()
    {
        
    }
}
