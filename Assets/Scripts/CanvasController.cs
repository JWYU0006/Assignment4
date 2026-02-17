using UnityEngine;

public class CanvasController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        this.GetComponent<Transform>().LookAt(Camera.main.transform);
    }
}
