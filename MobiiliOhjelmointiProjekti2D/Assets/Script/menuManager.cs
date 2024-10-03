using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class menuManager : MonoBehaviour
{
    public GameObject menuImage;
    public Button openButton;
    public Button closeButton;
    public Button exitButton;

    private bool canNavigate = true;
    // Start is called before the first frame update
    void Start()
    {
        menuImage.SetActive(false);

        openButton.onClick.AddListener(OpenImage);
        closeButton.onClick.AddListener(CloseImage);
        exitButton.onClick.AddListener(CloseApplication);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OpenImage()
    {
        if (!menuImage.activeSelf)
        {
            menuImage.SetActive(true);
        }
        else
        {
            menuImage.SetActive(false);
        }
    }
    void CloseImage()
    {
        menuImage.SetActive(false);
    }
    void CloseApplication()
    {
        Debug.Log("Ohjelma suljettu");

        Application.Quit();
    }

    public void NavigateToSceneTwo()
    {
        if (canNavigate)
        {
            Debug.Log("Navigoidaan uuteen skeneen");
            canNavigate = false;
            SceneManager.LoadScene("toinenSivu", LoadSceneMode.Single);
        }
    }
    public void NavigateToMainScene()
    {
        Debug.Log("Navigoidaan p‰‰skeneen");
        canNavigate = false;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void NavigateToSceneQuiz()
    {
        if (canNavigate)
        {
            Debug.Log("Navigoidaan uuteen skeneen");
            canNavigate = false;
            SceneManager.LoadScene("quizScene", LoadSceneMode.Single);
        }

    }
}


