using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvasOnButton : MonoBehaviour
{
    public string ToggleKey = "d";
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(ToggleKey)) ToggleCanvas();
    }
    public void ToggleCanvas() { canvas.enabled = !canvas.enabled; }
}
