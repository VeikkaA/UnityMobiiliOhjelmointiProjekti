using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundImageChanger : MonoBehaviour
{
    public Image scrollViewBackground;
    public Toggle[] imageToggles;
    public Sprite[] backgroundImages;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < imageToggles.Length; i++)
        {
            int index = i;
            imageToggles[i].onValueChanged.AddListener(delegate {ChangeBackgroundImage(index); });
        }

        /*foreach (Toggle imageToggle in imageToggles)
        {
            imageToggle.onValueChanged.AddListener(delegate )
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeBackgroundImage(int index)
    {
        if (imageToggles[index].isOn)
        {
            scrollViewBackground.sprite = backgroundImages[index];
        }
    }
}
