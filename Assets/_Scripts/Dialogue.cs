using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public List<string> dialogueLines = new List<string>();
    private GameObject dialogueBox;
    private TextMeshProUGUI dialogueText;
    private int currentLine = 0;
    private bool talking = false;
    private static HashSet<string> playedLevels = new HashSet<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueBox = GameObject.FindWithTag("DialogueBox");
        dialogueText = GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>();

        string sceneName = SceneManager.GetActiveScene().name;

        if (!playedLevels.Contains(sceneName))
        {
            StartDialogue();
            playedLevels.Add(sceneName); // mark THIS level as played
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
    
            if(!talking)
            {
                StartDialogue();
            }
            else
            {
                NextLine();
            }
         }
    }

    void StartDialogue()
    {
        talking = true;
        currentLine = 0;
        

        dialogueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
        Time.timeScale = 0f;
    }

    void NextLine()
{
    currentLine++;

    if(currentLine >= dialogueLines.Count)
    {
        dialogueText.text = "";
        EndDialogue();
        return;
    }

    dialogueText.text = dialogueLines[currentLine];
}

    void EndDialogue()
    {
        talking = false;
        dialogueBox.SetActive(false);
        Time.timeScale = 1f;
    }

}
