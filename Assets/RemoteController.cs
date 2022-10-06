using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemoteController : MonoBehaviour
{
    public TMP_Text DepthText;
    public TMP_Text VelocityText;

    public float depth;
    public float velocity;

    public NetworkController networkController;

    private void Update()
    {
        depth += velocity*Time.deltaTime;
        DepthText.text = "Depth: " + (Mathf.Floor(depth*10)/10f).ToString();
        networkController.Publish(depth.ToString(),"depth");
    }
    public void AddToVelocity(float v)
    {
        velocity += v;
        VelocityText.text = "Velocity: "+ (Mathf.Floor(velocity * 10) / 10f).ToString();
    }

}
