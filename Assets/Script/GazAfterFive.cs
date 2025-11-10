using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GazAfterFive : MonoBehaviour
{
    public npcInter gazData;
    public GameObject dialoguePanel;
    public TMP_Text talkText, nameText;
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
        if (mailMan.mail >= 5)
        {
            nameText.SetText(gazData.npcName);
            profileImage.sprite = gazData.profile;
            dialoguePanel.SetActive(true);
            StartCoroutine(TypeLine());
        }

    }
    void NextLine()
    {
        if (istyping)
        {
            StopAllCoroutines();
            talkText.SetText(gazData.dialogueLines[dialogueIndex]);
            istyping = false;
        }
        else
        {
            dialogueIndex++;
            if (dialogueIndex < gazData.dialogueLines.Length)
            {
                StartCoroutine(TypeLine());
            }
            else
            {
                isActiveDialogue = false;
                dialoguePanel.SetActive(false);
            }
        }
    }
    System.Collections.IEnumerator TypeLine()
    {
        istyping = true;
        talkText.SetText("");
        foreach (char c in gazData.dialogueLines[dialogueIndex].ToCharArray())
        {
            talkText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
        istyping = false;
    }
    public void EndDialouge()
    {
        StopAllCoroutines();
        isActiveDialogue = false;
        talkText.SetText("");
        dialoguePanel.SetActive(false);
        mailPanel.SetActive(false);
    }
}
