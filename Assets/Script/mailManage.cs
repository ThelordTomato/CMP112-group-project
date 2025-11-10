using UnityEngine;
using UnityEngine.UI;

public class mailManage : MonoBehaviour
{
    public int mail;
    public Text mailText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mailText.text = ": " + mail.ToString();
    }
}
