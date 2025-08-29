using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Cam : MonoBehaviour
{
    public List<CanvasScaler> CanvasScaler;

    private const float Aspect = 16f / 9f;
    private Camera Camera;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
        UpdateCam();
    }

    public void UpdateCam()
    {
        if (Camera != null)
        {
            float interval = (float)Screen.width / (float)Screen.height / Aspect;
            if (interval < 1)
            {
                Camera.rect = new Rect(0, (1 - interval) * 0.5f, 1, interval);
                for (int i = 0; i < CanvasScaler.Count; i++)
                {
                    CanvasScaler[i].matchWidthOrHeight = 0;
                }
            }
            else
            {
                Camera.rect = new Rect((1 - 1 / interval) * 0.5f, 0, 1 / interval, 1);
                for (int i = 0; i < CanvasScaler.Count; i++)
                {
                    CanvasScaler[i].matchWidthOrHeight = 1;
                }
            }
        }
    }
}
