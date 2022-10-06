using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public TMP_InputField IpAddressField;
    public TMP_InputField PortField;
    public Button ConnectButton;
    public Button DisconnectButton;

    public TMP_InputField MessageField;
    public TMP_InputField PubTopicField;
    public Button PublishButton;

    public TMP_InputField SubTopicField;
    public Button SubscribeButton;
    public Button UnsubscribeButton;

    public TMP_InputField ConsoleField;


    public NetworkController networkController;


    private void Awake()
    {
        networkController.OnLogChanged += RefreshConsole;
    }

    private void Start()
    {
        IpAddressField.text = networkController.brokerAddress;
        PortField.text = networkController.brokerPort.ToString();
    }

    public void RefreshConsole()
    {
        ConsoleField.text = networkController.debugLog;
    }

    public void Publish()
    {
        networkController.Publish(MessageField.text,PubTopicField.text);
    }
    public void Subscribe()
    {
        networkController.Subscribe(SubTopicField.text);
    }
    public void Unubscribe()
    {
        networkController.Unsubscribe(SubTopicField.text);
    }
}

//     Write tha code
//     so you can go to bed
//       |\      _,,,---,,_
// ZZZzz /,`.-'`'    -.  ;-;;,_
//      |,4-  ) )-,_. ,\ (  `'-'
//     '---''(_/--'  `-'\_) 