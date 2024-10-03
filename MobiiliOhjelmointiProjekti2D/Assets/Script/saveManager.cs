using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveManager : MonoBehaviour
{
    private string answerFilePath;
    // Start is called before the first frame update
    private void Start()
    {
        answerFilePath = Application.persistentDataPath + "/answers.json";
    }

    // Update is called once per frame
    public void SaveAnswer(string question, string userAnswer, bool isCorrect)
    {
        List<AnswerData> answerList = new List<AnswerData>();

        if (File.Exists(answerFilePath))
        {
            string json = File.ReadAllText(answerFilePath);
            answerList = JsonUtility.FromJson<AnswerListWrapper>(json).answer;
        }
        answerList.Add(new AnswerData
        {
            question = question,
            userAnswer = userAnswer,
            isCorrect = isCorrect
        });

        AnswerListWrapper wrapper = new AnswerListWrapper { answer = answerList };
        string UpdateJson = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(answerFilePath, UpdateJson);
    }
}
[System.Serializable]

public class AnswerData
{
    public string question;
    public string userAnswer;
    public bool isCorrect;
}

[System.Serializable]

public class AnswerListWrapper
{
    public List<AnswerData> answer;
}