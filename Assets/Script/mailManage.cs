using UnityEngine;
using UnityEngine.UI;

public class mailManage : MonoBehaviour
{
    public int mail;
    public Text mailPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mailPoint.text = ": " + mail.ToString();
    }
}
