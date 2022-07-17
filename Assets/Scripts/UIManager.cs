using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameText;
    public GameObject buttonsHolder;
    [HideInInspector]
    public bool menuEnabled;
    // Start is called before the first frame update
    void Start()
    {
        menuEnabled = true;
        buttonsHolder.SetActive(true);
        gameText.text = "SNAKE GAME";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + SnakeController.scoreCount;
    }

    public void StartGame()
    {
        buttonsHolder.SetActive(false);
        gameText.gameObject.SetActive(false);
        menuEnabled = false;
        AudioManager.Instance.PlayOnDeath();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOverScreen()
    {
        gameText.text = "GAME OVER";
        gameText.gameObject.SetActive(true);
        buttonsHolder.gameObject.SetActive(true);
    }
    
}
