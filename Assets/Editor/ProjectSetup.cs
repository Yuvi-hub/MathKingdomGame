using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
public static class ProjectSetup
{
    private const string ScenePath = "Assets/Scenes/Main.unity";
    static ProjectSetup() => EditorApplication.delayCall += EnsureScene;
    [MenuItem("Assignment/Generate Main Scene")]
    public static void EnsureScene()
    {
        if (File.Exists(ScenePath)) return;
        Directory.CreateDirectory("Assets/Scenes");
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var root = new GameObject("Game Bootstrap");
        root.AddComponent<GameBootstrap>();
        EditorSceneManager.SaveScene(scene, ScenePath);
        EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };
        AssetDatabase.Refresh();
        Debug.Log("Main scene created. Open Assets/Scenes/Main.unity and press Play.");
    }
    [MenuItem("Assignment/Build WebGL")]
    public static void BuildWeb()
    {
        EnsureScene();
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WebGL)
        {
            Debug.LogError("Switch the build target to WebGL first (File > Build Profiles).");
            return;
        }
        Directory.CreateDirectory("WebGLBuild");
        var report = BuildPipeline.BuildPlayer(new[] { ScenePath }, "WebGLBuild",
            BuildTarget.WebGL, BuildOptions.None);
        Debug.Log("WebGL build result: " + report.summary.result);
    }
}
