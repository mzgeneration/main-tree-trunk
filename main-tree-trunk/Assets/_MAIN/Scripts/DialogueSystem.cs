

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public DialogueContainer dialogueContainer;

    public static DialogueSystem instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);
    }

    void Start()
    {
        dialogueContainer = gameObject.AddComponent<DialogueContainer>();
        // Initialization logic here
    }

    void Update()
    {
        // Update logic here
    }
}
