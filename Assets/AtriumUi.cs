using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AtriumUi : MonoBehaviour
{
    public TMP_Text DepthText;
    public AtriumController atriumController;

    private void Update()
    {
        DepthText.text = atriumController.depth.ToString();
    }
}
