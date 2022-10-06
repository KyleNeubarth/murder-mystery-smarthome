using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoilerRoomUi : MonoBehaviour
{
    public TMP_Text DepthText;
    public BoilerRoomController boilerRoomController;

    private void Update()
    {
        DepthText.text = boilerRoomController.depth.ToString();
    }
}
