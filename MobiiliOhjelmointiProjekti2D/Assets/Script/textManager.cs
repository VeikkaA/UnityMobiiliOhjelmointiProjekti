using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> textHolders = new List<TextMeshProUGUI>();

    [SerializeField] List<string> textList = new List<string>();

    private int currentTextIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(textList.Count > 0)
        {
            UpdateTexts();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTexts()
    {
        if(textList.Count == textHolders.Count)
        {
            for(int i = 0; i < textHolders.Count; i++)
            {
                textHolders[i].text = textList[i];
            }
        }
        else
        {
            Debug.LogError("Teksti holderi ja teksti lista ovat erisuuruisia.");
        }
    }
    public void AddText(string newText)
    {
        textList.Add(newText);
        //currentTextIndex = textList.Count - 1;
        UpdateTexts();
    }
    public void AddTextHolder(TextMeshProUGUI newHolder)
    {
        textHolders.Add(newHolder);
        UpdateTexts();
    }

    public void NextText() 
    {
    if (currentTextIndex < textList.Count - 1) 
        {
            currentTextIndex++;
            UpdateTexts();
        }
    }
    public void PreviosText()
    {
        if(currentTextIndex > 0)
        {
            currentTextIndex--;
            UpdateTexts();
        }
    }
}
