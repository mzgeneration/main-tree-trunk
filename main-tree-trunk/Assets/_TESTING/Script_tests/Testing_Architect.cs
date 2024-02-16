using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Testing_Architect : MonoBehaviour
{
    DialogueSystem ds;
    TextArchitect architectWork;
    int currentLineIndex = 0;

    string[] lines = new string[9]
    {
        "Where is he? He's always late.",
        "Look who finally decided to show up.",
        "Sorry, traffic was a nightmare.",
        "Excuses, excuses. Sit down; you owe me an explanation.",
        "So spill it, Jason. What's the big news?",
        "I got the job. The one I interviewed for.",
        "Seriously? That's fantastic! I knew you'd SLAYYY it.",
        "Thanks, Meg. Couldn't have done it without your pep talks.",
        "Fuck off cringy bij bye"
    };


    void Start()
    {
        if (DialogueSystem.instance != null)
        {
            // The singleton instance is properly set up
            Debug.Log("DialogueSystem instance exists.");
        }
        else
        {
            // The singleton instance is not properly set up
            Debug.LogError("DialogueSystem instance is null. Make sure it's properly assigned.");
        }
        Debug.Log("TestingArchitect initialization is about to happen.");
        ds = DialogueSystem.instance;
        architectWork = new TextArchitect(ds.dialogueContainer.dialogueText);
        architectWork.buildMethod = TextArchitect.BuildMethod.instant;
        Debug.Log("TestingArchitect initialization is happening.");
        architectWork.Build(lines[currentLineIndex]);
        currentLineIndex++;

    }

    void Update()
    {
        if (Input.GetKeyDown("space") && (currentLineIndex < lines.Length))
        {
            Debug.Log("Space key pressed" + "Building next line.");
            architectWork.Build(lines[currentLineIndex]);
            Debug.Log("im printing your next line la calm down");
            currentLineIndex++;
        }
    }
}
