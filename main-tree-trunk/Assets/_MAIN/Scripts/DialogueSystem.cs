using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] public DialogueContainer dialogueContainer = new DialogueContainer();

    public static DialogueSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("instance is == this in DS at awake");
            DontDestroyOnLoad(gameObject);
            Debug.Log("gameobject not destroyed yet");
        } //Ensure persistence across scenes
        else
        {
            DestroyImmediate(gameObject);
            Debug.Log("game object is destroyed immediately");
        }
    }

    void Start()
    {
        Debug.Log("Dialogue system initialised");
    }

    void Update()
    {

        // Update logic here
    }
}
