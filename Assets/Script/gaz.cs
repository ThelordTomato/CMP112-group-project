using System.Collections;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class gaz : MonoBehaviour, Interactable
{
    public npcInteract gazData;
    public GameObject dialoguePanel;
    public TMP_Text talkText,nameText;
    public Image profileImage;

    private int dialogueIndex;
    private bool istyping, isActiveDialogue;

    public bool CanInteract()
    {
        return !isActiveDialogue;
    }

    public void Interact()
    {
        if (gazData == null) 
            return;
        if (isActiveDialogue)
        {
            NextLine();
        }
        else
        {
            StartDialouge();
        }
           
    }

    void StartDialouge()
    {
        isActiveDialogue = true;
        dialogueIndex = 0;

        nameText.SetText(gazData.npcName);
        profileImage.sprite = gazData.profile;

        dialoguePanel.SetActive(true);
        StartCoroutine(TypeLine());

    }

    void NextLine() {

        if (istyping)
        {
            StopAllCoroutines();
            talkText.SetText(gazData.dialogueLines[dialogueIndex]);
            istyping= false;
        }
        else if(++dialogueIndex < gazData.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialouge();
        }

    }
    IEnumerator TypeLine()
    {
        istyping = true;
        talkText.SetText ("");
        foreach (char letter in gazData.dialogueLines[dialogueIndex])
        {
            talkText.text += letter;
            yield return new WaitForSeconds(gazData.dialogSpeed);
        }
        istyping = false;
        if (gazData.autoProgress.Length > dialogueIndex && gazData.autoProgress[dialogueIndex]) { 
            yield return new WaitForSeconds(gazData.autoProgressDelay);
            NextLine();

        }

    }
    public void EndDialouge()
    {
            StopAllCoroutines();
        isActiveDialogue = false;
        talkText.SetText("");
        dialoguePanel.SetActive(false);
    }

}
