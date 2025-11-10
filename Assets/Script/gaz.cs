using System.Collections;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class gaz : MonoBehaviour, Interactable
{
    public npcInter gazData;
    public npcInter gazDatacom;
    public GameObject dialoguePanel;
    public TMP_Text talkText,nameText;
    public Image profileImage;
    public GameObject mailPanel;
    public mailManage mailMan;


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
        if (mailMan.mail == 0)
        {
            nameText.SetText(gazData.npcName);
            profileImage.sprite = gazData.profile;

            dialoguePanel.SetActive(true);
            StartCoroutine(TypeLine());

        }
        else if (mailMan.mail >= 5)
        {
            nameText.SetText(gazDatacom.npcName);
            profileImage.sprite = gazDatacom.profile;
            dialoguePanel.SetActive(true);
            StartCoroutine(TypeLine());
        }
    }

    void NextLine() {

        if (istyping)
        {
            if (mailMan.mail == 0) { 
            StopAllCoroutines();
            talkText.SetText(gazData.dialogueLines[dialogueIndex]);
            istyping = false; }
            else if (mailMan.mail >= 5)
            {
                StopAllCoroutines();
                talkText.SetText(gazDatacom.dialogueLines[dialogueIndex]);
                istyping = false;
            }
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
        if (mailMan.mail == 0)
        {
            talkText.SetText("");
            foreach (char letter in gazData.dialogueLines[dialogueIndex])
            {
                talkText.text += letter;
                yield return new WaitForSeconds(gazData.dialogSpeed);
            }
            istyping = false;
            if (gazData.autoProgress.Length > dialogueIndex && gazData.autoProgress[dialogueIndex])
            {
                yield return new WaitForSeconds(gazData.autoProgressDelay);
                NextLine();

            }
        }
        else if (mailMan.mail >= 5)
        {
            talkText.SetText("");
            foreach (char letter in gazDatacom.dialogueLines[dialogueIndex])
            {
                talkText.text += letter;
                yield return new WaitForSeconds(gazDatacom.dialogSpeed);
            }
            istyping = false;
            if (gazDatacom.autoProgress.Length > dialogueIndex && gazDatacom.autoProgress[dialogueIndex])
            {
                yield return new WaitForSeconds(gazDatacom.autoProgressDelay);
                NextLine();
            }
        }
        else
        {
             
        }
    }
    public void EndDialouge()
    {
            StopAllCoroutines();
        if (mailMan.mail == 0)
        {
            isActiveDialogue = false;
            talkText.SetText("");
            dialoguePanel.SetActive(false);
            mailPanel.SetActive(true);
            return;
        }
        else if ( mailMan.mail >= 5)
        {
            isActiveDialogue = false;
            talkText.SetText("");
            dialoguePanel.SetActive(false);
            mailPanel.SetActive(false);
        }
        
    }

}
