using UnityEngine;
using UnityEngine.UI;

public class mailCollect : MonoBehaviour
{ private BoxCollider2D boxCollider;
    public mailManage mailMan;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.CompareTag("mail"))
        {
            mailMan.mail += 1;
            Destroy(other.gameObject);

        }
    } 
}

