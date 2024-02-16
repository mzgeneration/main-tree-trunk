using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TextArchitect : MonoBehaviour
{
    private TextMeshProUGUI tmpro;
    public TextArchitect(TextMeshProUGUI tmpro)
    {
        this.tmpro = tmpro;
        Debug.Log("Intiailise this tmpro");
    }


    void Start()
    {
        Debug.Log("TextArchitect initialization completed.");
    }

    public string currentText => tmpro.text;

    public string targetText { get; private set; } = "";
    public string preText { get; private set; } = "";
    //private int preTextLength = 0;

    public string fullTargetText => preText + targetText;

    public enum BuildMethod { instant, typewriter, fade };
    public BuildMethod buildMethod = BuildMethod.instant;
    //public BuildMethod buildMethod = BuildMethod.typewriter;
    // public BuildMethod buildMethod = BuildMethod.fade;

    public Color textColor { get { return tmpro.color; } set { tmpro.color = value; } }

    public float speed
    {
        get { return baseSpeed * speedMultiplier; }
        set { speedMultiplier = value; }
    }
    private const float baseSpeed = 1f;
    private float speedMultiplier = 1f;
    private int characterMultipler = 1;
    public bool hurryUp = false;
    public int charactersPerCycle
    {
        get
        {
            return speed <= 2f ? characterMultipler : speed <= 2.5f ? characterMultipler * 2 : characterMultipler * 3;
        }
    }




    public Coroutine Build(string text)
    {
        preText = "";
        targetText = text;
        Debug.Log("if coroutine build tell me");
        /*Stop();
        if (tmpro == null)
        {
            Debug.LogError("tmpro is null. Make sure it's properly assigned.");
            return null;
        }
        Debug.LogError("tmpro build start coroutine building.");*/
        buildProcess = tmpro.StartCoroutine(Building());

        return buildProcess;
    }

    /// /Append text to what is already in the text architect

    public Coroutine Append(string text)
    {
        preText = tmpro.text;
        targetText = text;

        //Stop();

        buildProcess = tmpro.StartCoroutine(Building());
        return buildProcess;
    }

    private Coroutine buildProcess = null;
    public Coroutine BuildProcessStatus => buildProcess;
    public bool isBuilding => buildProcess != null;

    /// <summary>
    /// establishing stop function
    /// </summary>
   /* public void Stop()
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
    } */
    private IEnumerator Building()
    {
        Debug.Log("Building coroutine started.");
        Prepare();
        Debug.Log("prepare in Building coroutine started.");
        switch (buildMethod)
        {
            case BuildMethod.instant:
                Debug.Log("Instant build selected.");
                yield return Build_Instant();
                break;
                /* case BuildMethod.typewriter:
                     Debug.Log("Typewriter build selected.");
                     yield return Build_Typewriter();
                     break;
                 case BuildMethod.fade:
                     Debug.Log("Fade build selected.");
                     yield return Build_Fade();
                     break;*/
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
                Debug.Log("instant prepared.");
                break;
                /*case BuildMethod.typewriter:
                    Prepare_Typewriter();
                    Debug.Log("typewriter prepared.");
                    break;
                case BuildMethod.fade:
                    Prepare_Fade();
                    Debug.Log("fade prepared.");
                    break;*/
        }
    }

    private void Prepare_Instant()
    {
        tmpro.color = tmpro.color;
        tmpro.text = fullTargetText;
        tmpro.ForceMeshUpdate(true);
        tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
    }

    /* private void Prepare_Typewriter()
     {
         tmpro.color = tmpro.color;
         tmpro.maxVisibleCharacters = 0;
         tmpro.text = preText;
         if (preText != "")
         {
             tmpro.ForceMeshUpdate(true);
             tmpro.maxVisibleCharacters = tmpro.textInfo.characterCount;
         }
         tmpro.text += targetText;
         tmpro.ForceMeshUpdate(false);
         // TODO: Implement Typewriter preparation logic
     }

     private void Prepare_Fade()
     {
         // TODO: Implement Fade preparation logic
     }*/
    private IEnumerator Build_Instant()
    {
        // Instantly display the entire text
        tmpro.text = fullTargetText;
        Debug.Log("instant build process started.");
        yield break; // Coroutine ends immediately
    }
    /* private IEnumerator Build_Typewriter()
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
     }*/

    void Update()
    {

    }
}
