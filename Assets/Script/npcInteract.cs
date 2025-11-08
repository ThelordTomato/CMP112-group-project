using UnityEngine;


[CreateAssetMenu(fileName = "New npcInteract", menuName = "npcInteract")]
public class npcInteract : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string npcName;
    public Sprite profile;
    public string[] dialogueLines;
    public float dialogSpeed = 0.06f;
    public bool[] autoProgress;
    public float autoProgressDelay= 1.5f;
}
