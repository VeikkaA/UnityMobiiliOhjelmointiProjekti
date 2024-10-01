using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuManager : MonoBehaviour
{
    public GameObject menuImage;
    public Button openButton;
    public Button closeButton;
    public Button exitButton;
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
}
