using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class MessageUnityEvent : UnityEvent<string, string> { }

public class NetworkController : M2MqttUnityClient
{
    public string debugLog;
    public List<string> SubscribedTopics;

    public delegate void OnLogChangedDelegate();
    public event OnLogChangedDelegate OnLogChanged;

    public List<string> AutoTopics;

    //message, topic
    private List<(string,string)> receivedMessages = new List<(string,string)>();

    public MessageUnityEvent MessageReceivedEvent;

    protected override void Update()
    {
        base.Update();
        while (receivedMessages.Count > 0)
        {
            PrintToLog("Received: \"" + receivedMessages[0].Item1 + "\" from topic \"" + receivedMessages[0].Item2 + "\"");
            MessageReceivedEvent.Invoke(receivedMessages[0].Item1, receivedMessages[0].Item2);
            receivedMessages.RemoveAt(0);
        }
    }

    public void PrintToLog(string msg)
    {
        Debug.Log(msg);
        debugLog = msg + "\n" + debugLog;

        //remove the oldest elements of the log once it gets too long
        if (debugLog.Split('\n').Length > 30)
        {
            debugLog.Remove(debugLog.LastIndexOf("\n"));
        }
        OnLogChanged();
    }

    public void SetBrokerAddress(string brokerAddress)
    {
        this.brokerAddress = brokerAddress;
    }
    public void SetBrokerPort(string brokerPort)
    {
        int.TryParse(brokerPort, out this.brokerPort);
    }


    public void Subscribe(string topic)
    {
        if (!SubscribedTopics.Contains(topic))
        {
            SubscribedTopics.Add(topic);
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            PrintToLog("Subbed to topic \"" + topic + "\"");
        }
    }
    public void Subscribe(string topic, int qos)
    {
        client.Subscribe(new string[] { topic }, new byte[] { System.Convert.ToByte(qos) });
        PrintToLog("Subbed to topic \"" + topic + "\"");
    }
    public void Unsubscribe(string topic)
    {
        if (SubscribedTopics.Contains(topic))
        {
            client.Unsubscribe(new string[] { topic });
            PrintToLog("Successfully unsubbed from topic \""+topic+"\"");
        } else PrintToLog("Unsubscribe failed: was already subscribed to topic \"" + topic + "\"");

    }
    public void UnsubscribeAll()
    {
        foreach (string topic in SubscribedTopics)
        {
            Unsubscribe(topic);
        }
    }
    public void Publish(string msg, string topic, int qos = 1)
    {
        if (client == null || !client.IsConnected) return; 
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(msg), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        PrintToLog("Publish: \""+msg+"\" to topic \""+topic+"\"");
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        string msg = System.Text.Encoding.UTF8.GetString(message);
        PrintToLog("Received: \"" + msg + "\" from topic \"" + topic + "\"");
        MessageReceivedEvent.Invoke(msg, topic);
    }

    #region LoggingCallbacks
    protected override void OnConnecting()
    {
        base.OnConnecting();
        PrintToLog("Connecting to broker on " + brokerAddress + ":" + brokerPort.ToString() + "...");
    }

    protected override void OnConnected()
    {
        base.OnConnected();
        PrintToLog("OnConnected: Connected to broker on " + brokerAddress);
        foreach (string s in AutoTopics)
        {
            PrintToLog("Auto Subbing to " + s);
            Subscribe(s);
        }
    }
    protected override void OnConnectionFailed(string errorMessage)
    {
        PrintToLog("CONNECTION FAILED! " + errorMessage);
    }

    protected override void OnDisconnected()
    {
        PrintToLog("Disconnected.");
    }

    protected override void OnConnectionLost()
    {
        PrintToLog("CONNECTION LOST!");
    }
    #endregion
}

//     Write tha code
//     so you can go to bed
//       |\      _,,,---,,_
// ZZZzz /,`.-'`'    -.  ;-;;,_
//      |,4-  ) )-,_. ,\ (  `'-'
//     '---''(_/--'  `-'\_) 