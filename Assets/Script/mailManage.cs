using UnityEngine;
using UnityEngine.UI;

public class mailManage : MonoBehaviour
{
    public int mail;
<<<<<<< Updated upstream
    public Text mailPoint;
=======
    public Text mailText;

>>>>>>> Stashed changes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        mailPoint.text = ": " + mail.ToString();
=======
        mailText.text = ":" + mail.ToString();
>>>>>>> Stashed changes
    }
}
