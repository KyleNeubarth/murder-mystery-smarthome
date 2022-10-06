using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySceneName : MonoBehaviour
{
    private void Start()
    {
        TMP_Text myText = GetComponent<TMP_Text>();
        myText.text = SceneManager.GetActiveScene().name;
    }
}
