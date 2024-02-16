using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TextArchitect : MonoBehaviour
{
    private TMP_Text tmpro;

    public string currentText => tmpro.text;

    public string targetText { get; private set; } = "";
    public string preText { get; private set; } = "";
    //private int preTextLength = 0;

    public string fullTargetText => preText + targetText;

    public enum BuildMethod { instant, typewriter, fade };
    // public BuildMethod buildMethod = BuildMethod.instant;
    public BuildMethod buildMethod = BuildMethod.typewriter;
    // public BuildMethod buildMethod = BuildMethod.fade;

    public Color textColor { get { return tmpro.color; } set { tmpro.color = value; } }

    public float speed
    {
        get { return baseSpeed * speedMultiplier; }
        set { speedMultiplier = value; }
    }
    private const float baseSpeed = 1f;
    private float speedMultiplier = 1f;

    public int charactersPerCycle
    {
        get
        {
            return speed <= 2f ? characterMultipler : speed <= 2.5f ? characterMultipler * 2 : characterMultipler * 3;
        }
    }
    private int characterMultipler = 1;

    private void Awake()
    {
        tmpro = GetComponent<TMP_Text>();
        if (tmpro == null)
        {
            Debug.LogError("TMP_Text component is missing.");
        }
    }

    public bool hurryUp = false;

    public TextArchitect(TMP_Text tmpro)
    {
        this.tmpro = tmpro;
        Debug.Log("Intiailise this tmpro");
    }


    void Start()
    {
        Debug.Log("TextArchitect initialization is about to happen.");



        Debug.Log("TextArchitect initialization completed.");
    }



    public Coroutine Build(string text)
    {
        preText = "";
        targetText = text;

        Stop();
        if (tmpro == null)
        {
            Debug.LogError("tmpro is null. Make sure it's properly assigned.");
            return null;
        }

        buildProcess = tmpro.StartCoroutine(Building());
        return buildProcess;
    }
    /// <summary>
    /// /Append text to what is already in the text architect
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Coroutine Append(string text)
    {
        preText = tmpro.text;
        targetText = text;

        Stop();

        buildProcess = tmpro.StartCoroutine(Building());
        return buildProcess;
    }

    private Coroutine buildProcess = null;
    public Coroutine BuildProcessStatus => buildProcess;
    public bool isBuilding => buildProcess != null;
    public void Stop()
    {
        Debug.Log("Before condition check. isBuilding: " + isBuilding);

        if (!isBuilding)
        {
            Debug.Log("PLS STOPPP");
            return;
        }

        tmpro.StopCoroutine(buildProcess);
        Debug.Log("PLS STOPPP222");
        buildProcess = null;
        Debug.Log("PLS STOPPP3333");
    }
    private IEnumerator Building()
    {
        Debug.Log("Building coroutine started.");
        Prepare();
        switch (buildMethod)
        {
            case BuildMethod.typewriter:
                Debug.Log("Typewriter build selected.");
                yield return Build_Typewriter();
                break;
            case BuildMethod.fade:
                Debug.Log("Fade build selected.");
                yield return Build_Fade();
                break;
        }

        OnComplete();
        Debug.Log("Building coroutine completed.");

    }


    private void OnComplete()
    {
        buildProcess = null;
    }

    private void Prepare()
    {
        switch (buildMethod)
        {
            case BuildMethod.instant:
                Prepare_Instant();
                break;
            case BuildMethod.typewriter:
                Prepare_Typewriter();
                break;
            case BuildMethod.fade:
                Prepare_Fade();
                break;
        }
    }

    private void Prepare_Instant()
    {
        tmpro.color = tmpro.color;
        tmpro.text = fullTargetText;
        tmpro.ForceMeshUpdate();
        tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
    }

    private void Prepare_Typewriter()
    {
        tmpro.color = tmpro.color;
        tmpro.maxVisibleCharacters = 0;
        tmpro.text = preText;
        if (preText != "")
        {
            tmpro.ForceMeshUpdate();
            tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
        }
        tmpro.text += targetText;
        tmpro.ForceMeshUpdate();
        // TODO: Implement Typewriter preparation logic
    }

    private void Prepare_Fade()
    {
        // TODO: Implement Fade preparation logic
    }

    private IEnumerator Build_Typewriter()
    {
        while (tmpro.maxVisibleCharacters < tmpro.textInfo.characterCount)
        {
            tmpro.maxVisibleCharacters += hurryUp ? charactersPerCycle * 5 : charactersPerCycle;
            yield return new WaitForSeconds(0.015f / speed);
        }
        Debug.Log("Typewriter build process started.");
        // TODO: Implement Typewriter build logic
        yield return null;
        Debug.Log("Typewriter build process completed.");
    }

    private IEnumerator Build_Fade()
    {
        Debug.Log("Fade build process started.");
        // TODO: Implement Fade build logic
        yield return null;
        Debug.Log("Fade build process completed.");
    }


}
