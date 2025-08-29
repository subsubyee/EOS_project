using UnityEngine;

public class Canv : MonoBehaviour
{
    private Cam Cam;

    private void Awake()
    {
        Cam = GameObject.FindWithTag("MainCamera").GetComponent<Cam>();
    }

    private void OnRectTransformDimensionsChange()
    {
        if(Cam != null)
        {
            Cam.UpdateCam();
        }
    }
}
