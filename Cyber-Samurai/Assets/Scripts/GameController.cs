using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Text healthText;
    
    public GameObject player;

    public GameObject pauseOBJ;
    public GameObject gameOverOBJ;
    
    
    
    public Vector3 respawnPoint;

    private bool isPaused;

    public int totalScore;

    public static GameController instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalScore = PlayerPrefs.GetInt("score");
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }

    public void RestartGame()
    {
        
    }
    public void GameOver()
    {
        gameOverOBJ.SetActive(true);
        Time.timeScale = 0f;
    }
}
   

