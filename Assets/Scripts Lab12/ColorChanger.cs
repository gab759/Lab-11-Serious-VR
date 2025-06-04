using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ColorChanger : MonoBehaviour
{
    public Renderer targetRenderer;
    public float changeSpeed = 100f;

    private Material mat;

    void Start()
    {
        mat = targetRenderer.material;
    }

    public void IncreaseRed()
    {
        Color c = mat.color;
        c.r = Mathf.Min(1f, c.r + (changeSpeed / 255f) * Time.deltaTime);
        mat.color = c;
    }

    public void DecreaseRed()
    {
        Color c = mat.color;
        c.r = Mathf.Max(0f, c.r - (changeSpeed / 255f) * Time.deltaTime);
        mat.color = c;
    }
}