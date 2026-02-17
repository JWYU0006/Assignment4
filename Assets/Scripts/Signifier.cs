using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Signifier : MonoBehaviour
{
    public Blackboard blackboard;
    public Image backImage;
    public Sprite catFoodImage;
    public Sprite waterImage;
    public Sprite sleepyCatImage;
    public Sprite lickFurImage;

    void Update()
    {
        this.GetComponent<Image>().enabled = true;
        backImage.enabled = true;
        if (blackboard.GetVariableValue<int>("actionIndex") == 1)
        {
            this.GetComponent<Image>().sprite = catFoodImage;
        }
        else if (blackboard.GetVariableValue<int>("actionIndex") == 2)
        {
            this.GetComponent<Image>().sprite = waterImage;
        }
        else if (blackboard.GetVariableValue<int>("actionIndex") == 3)
        {
            this.GetComponent<Image>().sprite = sleepyCatImage;
        }
        else if (blackboard.GetVariableValue<int>("actionIndex") == 4)
        {
            this.GetComponent<Image>().sprite = lickFurImage;
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
            backImage.enabled = false;

        }
    }
}
