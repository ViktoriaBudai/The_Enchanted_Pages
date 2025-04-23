using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterSprite
{
    public string characterName;
    public Sprite characterImage;
}


public class CustomCharacterController : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private List<CharacterSprite> characterSprites;

    void Start()
    {
        StartCoroutine(InitializeStory());  // Start the coroutine to initialize the story
    }

    private IEnumerator InitializeStory()
    {
        // Wait for one frame to ensure the DialogueManager has initialized
        yield return null;

        // Find the DialogueManager component in the scene
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        // If the DialogueManager is found, get the Story from it
        if (dialogueManager != null)
        {
            // Get the Story from DialogueManager
            var story = dialogueManager.GetStory();  // Get the Story from DialogueManager

            // Check if the story was successfully retrieved
            if (story != null)
            {
                // Bind external functions to the story
                story.BindExternalFunction("show_character", (string characterName) => ShowCharacter(characterName));
                story.BindExternalFunction("hide_character", () => HideCharacter());
            }
            else
            {
                // If story wasn't found, log an error
                Debug.LogError("Story not found in DialogueManager.");
            }
        }
        else
        {

            Debug.LogError("DialogueManager not found.");
        }
    }


    private void ShowCharacter(string characterName)
    {
        // Search through the list to find the character by name
        foreach (var character in characterSprites)
        {
            if (character.characterName == characterName)
            {
                characterImage.sprite = character.characterImage;
                characterImage.gameObject.SetActive(true);
                return;
            }
        }

        Debug.LogError($"No sprite found for character: {characterName}");
    }


    private void HideCharacter()
    {
        characterImage.gameObject.SetActive(false);
    }
}