using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class healthManager : MonoBehaviour
{
    public GameObject[] healthImages;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;

    private int currentHealth;
    private SpriteRenderer playerSpriteRenderer;

    [SerializeField] Button exitButton;
    [SerializeField] Button newGamebutton;
    [SerializeField] Button openPauseMenu;
    [SerializeField] Button continuegameButton;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthImages.Length;

        gameOverMenu.SetActive(false);

        pauseMenu.SetActive(false);

        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        exitButton.onClick.AddListener(CloseApplication);

        newGamebutton.onClick.AddListener(newGame);

        openPauseMenu.onClick.AddListener(OpenPauseMenu);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseApplication()
    {
        Debug.Log("Ohjelma suljettu");
        Application.Quit();
    }

    public bool LoseLife()
    {
        if(currentHealth > 0)
        {
            currentHealth--;
            UpdateLivesCounter();


            if (currentHealth == 0) 
            {
                GameOver();
                return true;
            }
        }
        return false;
    }

    public bool AddLife()
    {
        if (currentHealth < healthImages.Length) 
        {
            currentHealth++;
            UpdateLivesCounter();

            return true;
        }

        return false;
    }

    private void UpdateLivesCounter()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].SetActive(i < currentHealth);
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        HidePlayer();
        gameOverMenu.SetActive(true);
        openPauseMenu.enabled = false;
    }

    private void HidePlayer()
    {
        if(playerSpriteRenderer != null)
        {
            playerSpriteRenderer.enabled = false;
        }
        else
        {
            Debug.LogError("SpriteRenderiä ei ole määritelty");
        }
    }
    private void ShowPlayer()
    {
        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.enabled = true;
        }
    }

    public void newGame()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
        ShowPlayer();
        Time.timeScale = 1f;
        /*Time.timeScale = 1f;
        currentHealth = healthImages.Length;
        UpdateLivesCounter();
        gameOverMenu.SetActive(false);
        ShowPlayer();*/
    }
    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;

        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            ShowPlayer();
        }
        else
        {
            pauseMenu.SetActive(true);
            HidePlayer();
        }
        
        
    }

    public void MenuContinuegame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        ShowPlayer();
    }


}
