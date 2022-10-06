using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtriumController : MonoBehaviour
{
    public float depth = 0;
    public void ParseMessage(string message, string topic)
    {
        Debug.Log($"message: {message}; topic: {topic}");

        switch (topic)
        {
            case "depth":
                depth = float.Parse(message);
                break;
            default:
                break;
        }
    }
}
