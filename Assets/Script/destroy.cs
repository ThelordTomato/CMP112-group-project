using UnityEngine;

public class destroy : MonoBehaviour
{

    private bool die; 

    // Update is called once per frame
    void Update()
    {
        die = GameObject.Find("Npc1").GetComponent<gaz>().destroy;

        if (die == false)
        {
            Destroy(gameObject);
        }

    }
}
