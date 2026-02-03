using UnityEngine;

public class CatNeeds : MonoBehaviour
{
    public float hungry;
    public float thirsty;
    public float energy;
    public Transform body;

    private void Update()
    {
        if (energy <= 50)
        {
            body.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
