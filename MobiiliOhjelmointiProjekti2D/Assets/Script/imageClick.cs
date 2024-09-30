using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageClick : MonoBehaviour
{
    public GameObject backgroundPanel;
    public Image placeholderImage;
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        backgroundPanel.SetActive(false);
        closeButton.onClick.AddListener(HideImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void HideImage()
    {
        backgroundPanel.SetActive(false );
    }
    public void ShowImage(Sprite imageToShow) 
    {
        placeholderImage.sprite = imageToShow;
        backgroundPanel.SetActive(true );
    }
}
