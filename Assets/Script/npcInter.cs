using UnityEngine;

[CreateAssetMenu(fileName = "npcInter", menuName = "Scriptable Objects/npcInter")]
public class npcInter : ScriptableObject
{
    public string npcName;
    public Sprite profile;
    public string[] dialogueLines;
    public float dialogSpeed = 0.5f;
    public bool[] autoProgress;
    public float autoProgressDelay = 2f;

    
}
