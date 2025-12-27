using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

[InitializeOnLoad]
static class ProjectNetworkSetup
{
    static ProjectNetworkSetup() { EditorApplication.delayCall += EnsureNetworkTools; }

    static void EnsureNetworkTools()
    {
        var scenePath = "Assets/Scenes/Main.unity";
        if (!File.Exists(scenePath)) return;

        var scene = EditorSceneManager.OpenScene(scenePath);
        var tools = GameObject.Find("NetworkTools");
        if (tools == null)
        {
            tools = new GameObject("NetworkTools");
            tools.AddComponent<NetworkTransportSelector>();
            tools.AddComponent<NetworkLatencyUI>();
            Debug.Log("ProjectNetworkSetup: Added NetworkTools with TransportSelector and NetworkLatencyUI");
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
        }
    }
}
