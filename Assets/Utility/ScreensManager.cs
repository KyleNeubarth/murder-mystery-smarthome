using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScreensManager : MonoBehaviour
{
    public bool OverrideNumDisplays = false;
    public int CustomNumDisplays = 1;
    public int RealNumDisplays = -1;
    public int NumDisplays = -1;

    void Awake()
    {
        RealNumDisplays = Display.displays.Length;
        Debug.Log("Displays connected: " + RealNumDisplays);
        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        // Check if additional displays are available and activate each.
        for (int i = 1; i < RealNumDisplays; i++)
        {
            Display.displays[i].Activate();
        }

        for (int i=0;i<GetNumDisplays();i++)
        {
            if (transform.Find($"Monitor{i}")) continue;

            GameObject display = GameObject.Instantiate(Resources.Load("Monitor")) as GameObject;
            display.transform.parent = transform;
            display.name = $"Monitor{i}";
            ScreenController controller = display.GetComponent<ScreenController>();
            controller.Init(i);
        }
    }
    public int GetNumDisplays()
    {
        return OverrideNumDisplays ? CustomNumDisplays : RealNumDisplays;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ScreensManager))]
public class TestDisplays_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        ScreensManager script = (ScreensManager)target;

        // draw checkbox for the bool
        script.OverrideNumDisplays = EditorGUILayout.Toggle("Override Num Displays", script.OverrideNumDisplays);
        if (script.OverrideNumDisplays) // if bool is true, show other fields
        {
            script.CustomNumDisplays = EditorGUILayout.IntField("# Displays", script.CustomNumDisplays);
        } else
        {
            GUI.enabled = false;
            script.NumDisplays = EditorGUILayout.IntField("# Displays", script.RealNumDisplays);
            GUI.enabled = true;
        }
    }
}
#endif