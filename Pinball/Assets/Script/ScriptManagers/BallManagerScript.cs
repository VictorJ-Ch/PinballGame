using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BallManagerScript : MonoBehaviour
{
    public GameObject ball;
    public int lives = 3;
    public Transform spawnPosition;
    public TextMeshPro display;
    public bool gameOver = false;
    public GameObject gameOverCanvas;

    void Update()
    {
        //Check for gameOver
        if (lives < 0)
        {
            if (display)
            {
                display.text = "Last Ball";
                gameOver = true;
                //Game Over Canvas
                if (gameOverCanvas)
                {
                    gameOverCanvas.SetActive(true);
                }
            }
        }
        //Ball has drained and game is not over
        if (!GameObject.FindGameObjectWithTag("Ball") && !gameOver)
        { 
            lives--;
            Instantiate(ball, spawnPosition.position, ball.transform.rotation);
            //Update balls remainig
            if (display)
            {
                display.text = "BALLS: " + lives.ToString();
            }
        }
        //Reset the game with return ket if game is over
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
