using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class quizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButton;
    public TMP_Text feedbackText;
    public TMP_Text lastAnswerText;
    private saveManager saveManager;
    private string correctAnswer;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = FindObjectOfType<saveManager>();

        feedbackText.gameObject.SetActive(false);

        questionText.text = "Mik‰ on NBA:n virallinen pallokoko";
        string[] answers = {"7", "6", "5", "8" };
        correctAnswer = "7";

        for (int i = 0; i < answerButton.Length; i++)
        {
            int index = i;
            TMP_Text buttonText = answerButton[i].GetComponentInChildren<TMP_Text>();
            buttonText.text = answers[i];

            answerButton[i].onClick.RemoveAllListeners();

            answerButton[i].onClick.AddListener(() => SetAnswer(answers[index]));
        }

        string lastAnswer = PlayerPrefs.GetString("LastUserAnswer", "Ei vastattu viel‰");
        lastAnswerText.text = "Viimeksi vastattu: " + lastAnswer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAnswer(string answer)
    {
        PlayerPrefs.SetString("UserAnswer", answer);
        PlayerPrefs.SetString("LastUserAnswer", answer);
        SubmitAnswer();
    }

    public void SubmitAnswer()
    {
        string userAnswer = PlayerPrefs.GetString("UserAnswer");

        bool isCorrect = userAnswer == correctAnswer;

        if (isCorrect)
        {
            feedbackText.text = "Oikein!";
        }
        else
        {
            feedbackText.text = "V‰‰rin";
        }

        feedbackText.gameObject.SetActive(true);

        //saveManager.SaveAnswer(questionText.text, userAnswer, isCorrect);

        PlayerPrefs.DeleteKey("UserAnswer");
    }
}
