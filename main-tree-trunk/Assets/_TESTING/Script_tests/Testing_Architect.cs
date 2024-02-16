using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;


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
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.instant;
            Debug.Log("TestingArchitect initialization is about to happen.");

        }



        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key pressed" + "build method called is ");
                architect.Build(lines[Random.Range(0, lines.Length)]);
                Debug.Log("im not printing your shit");
            }
        }
    }
}