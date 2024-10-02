using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class calendarManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dayDropdown;
    [SerializeField] private GameObject popUpPanel;
    [SerializeField] private Button submitButton;
    [SerializeField] private TMP_InputField taskInput;
    [SerializeField] private TextMeshProUGUI taskText;
    [SerializeField] private Button[] dayButtons;

    private Dictionary<int, List<string>> taskByDay = new Dictionary<int, List<string>>();
    private int selectedDayIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        popUpPanel.SetActive(false);
        taskText.gameObject.SetActive(false);

        for (int i = 0; i < dayButtons.Length; i++)
        {
            int dayIndex = i;
            dayButtons[dayIndex].onClick.AddListener(() => OnDayButtonPressed(dayIndex));
        }

        dayDropdown.onValueChanged.AddListener(OnDaySelected);

        submitButton.onClick.AddListener(OnSubmitTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDayButtonPressed(int dayIndex)
    {
        selectedDayIndex = dayIndex;
        popUpPanel.SetActive(true);
    }
    void OnDaySelected(int dayIndex)
    {
        if (taskByDay.ContainsKey(dayIndex))
        {
            UpdateTaskTextForDay(dayIndex);
        }
        else
        {
            taskText.text = "Ei teht‰vi‰";
            taskText.gameObject.SetActive(true);
        }
    }
    void OnSubmitTask()
    {
        if (selectedDayIndex == -1)
        {
            Debug.LogWarning("P‰iv‰‰ ei valittu");
            return;
        }
        string task = taskInput.text;

        if (!taskByDay.ContainsKey(selectedDayIndex))
        {
            taskByDay[selectedDayIndex] = new List<string>();
        }
        taskByDay[selectedDayIndex].Add(task);

        UpdateTaskTextForDay(selectedDayIndex);
        popUpPanel.SetActive(false);
        taskInput.text = "";
    }
    void UpdateTaskTextForDay(int dayIndex)
    {
        string allTasks = string.Join("\n", taskByDay[dayIndex]);

        taskText.text = "Teht‰v‰t: \n" + allTasks;
        taskText.gameObject.SetActive(true);
    }
}
