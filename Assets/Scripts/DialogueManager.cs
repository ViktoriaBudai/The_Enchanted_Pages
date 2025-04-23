using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField, Header("Ink JSON")]
    private TextAsset inkJson;
    public Story story;

    [SerializeField]
    private TextMeshProUGUI DialogueText;

    [SerializeField]
    private GameObject ChoicePanel;

    [SerializeField]
    private List<Button> ChoiceButtons;

    [SerializeField, Tooltip("The speed at which characters appear (seconds per character)")]
    private float textSpeed = 0.05f;

    private Coroutine typingCoroutine;

    void Start()
    {
        // Create Ink story
        story = new Story(inkJson.text);

        ChoicePanel.SetActive(false);
    }

    public void ContinueStory()
    {
        if (story.canContinue)
        {
            // Hide choice buttons
            ChoicePanel.SetActive(false);

            // Get the next line of dialogue
            string nextLine = story.Continue();

            // Stop any ongoing typing coroutine
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            // Start the text writing coroutine
            typingCoroutine = StartCoroutine(TypeText(nextLine));
        }
        else if (story.currentChoices.Count > 0)
        {
            // Display choices if available
            DisplayChoices();
        }
    }

    private IEnumerator TypeText(string text)
    {
        DialogueText.text = ""; // Clear the text before typing
        foreach (char c in text)
        {
            DialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void DisplayChoices()
    {
        // Show the choice panel
        ChoicePanel.SetActive(true);

        // Iterate through available choices and update buttons
        for (int i = 0; i < ChoiceButtons.Count; i++)
        {
            if (i < story.currentChoices.Count)
            {
                ChoiceButtons[i].gameObject.SetActive(true);
                ChoiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = story.currentChoices[i].text;
                int choiceIndex = i; // Local variable to avoid closure issue
                ChoiceButtons[i].onClick.RemoveAllListeners();
                ChoiceButtons[i].onClick.AddListener(() => OnChoiceSelected(choiceIndex));
            }
            else
            {
                ChoiceButtons[i].gameObject.SetActive(false); // Hide extra buttons
            }
        }
    }

    private void OnChoiceSelected(int choiceIndex)
    {
        // Choose the selected choice in the story
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    void Update()
    {
        // Detect a tap or mouse click to continue if no choices are available
        if (Input.GetMouseButtonDown(0) && ChoicePanel.activeSelf == false)
        {
            ContinueStory();
        }
    }

    // Method to access the story from another script
    public Story GetStory()
    {
        return story;
    }
}