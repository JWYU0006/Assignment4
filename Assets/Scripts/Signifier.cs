using UnityEngine;
using UnityEngine.UI;

public class Signifier : MonoBehaviour
{
    public CatNeeds catNeeds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);
        if (catNeeds.hungry <= 30)
        {
            this.GetComponent<Image>().color = Color.red;
        }
    }
}
