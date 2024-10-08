using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scoringSystem : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    public static int theScore;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + theScore;
    }
}
