using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Timeline;

public class BuildTools : EditorWindow
{
    [MenuItem("Builds/Controller")]
    public static void BuildController()
    {
        // Get filename.
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Demo", "", "");
        string[] levels = new string[] { "Assets/Scenes/ControllerScreen.unity" };
 
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = levels;
        buildPlayerOptions.locationPathName = path + "/ControllerScreen.exe";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
 
        // Build player.
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
 
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log(path);
            UnityEngine.Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }
 
        if (summary.result == BuildResult.Failed)
        {
            UnityEngine.Debug.Log("Build failed");
        }
    }
    [MenuItem("Builds/BoilerRoom")]
    public static void BuildBoilerRoom()
    {
        // Get filename.
        string path = "C:/Users/Kyle/Projects/Unity/murder-mystery-smarthome/Builds/BoilerRoom";
        Debug.Log(path);
        string[] levels = new string[] { "Assets/Scenes/BoilerRoomScreen.unity" };

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = levels;
        buildPlayerOptions.locationPathName = path + "/BoilerRoomScreen.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        // Build player.
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log(path);
            UnityEngine.Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            UnityEngine.Debug.Log("Build failed");
        }
    }
    [MenuItem("Builds/Atrium")]
    public static void BuildAtrium()
    {
        // Get filename.
        //"G:/My Drive/GameDev/MurderMystery2/UnityBuilds/Atrium"
        string path = "C:/Users/Kyle/Projects/Unity/murder-mystery-smarthome/Builds/Atrium";
        string[] levels = new string[] { "Assets/Scenes/AtriumScreen.unity" };

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = levels;
        buildPlayerOptions.locationPathName = path + "/AtriumScreen.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        // Build player.
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log(path);
            UnityEngine.Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            UnityEngine.Debug.Log("Build failed");
        }
    }
}
