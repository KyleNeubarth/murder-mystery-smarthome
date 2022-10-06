using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public int display = -1;
    public Camera cam;
    public Canvas canvas;
    public TextMeshProUGUI text;

    public void Awake()
    {
        //if (display != -1) Init(display);
    }
    public void Init(int displayNum)
    {
        display = displayNum;
        cam.targetDisplay = display;
        canvas.targetDisplay = display;
        text.text = "Monitor " + display;
    }
}
