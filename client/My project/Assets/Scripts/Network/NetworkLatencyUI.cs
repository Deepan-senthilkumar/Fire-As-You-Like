using UnityEngine;

// Simple runtime UI to tweak latency simulation and batching on local player (affects PlayerNetworkTransform)
public class NetworkLatencyUI : MonoBehaviour
{
    public PlayerNetworkTransform localPlayer;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 130, 260, 200), "Network Sim", GUI.skin.window);
        if (localPlayer == null)
        {
            GUILayout.Label("Local player not assigned (drag Player prefab or instance to this component)");
        }
        else
        {
            GUILayout.Label($"Simulate latency: {localPlayer.simulateLatency}");
            localPlayer.simulateLatency = GUILayout.Toggle(localPlayer.simulateLatency, "Enable latency simulation");
            GUILayout.Label($"Latency (ms): {localPlayer.latencyMs}");
            localPlayer.latencyMs = (int)GUILayout.HorizontalSlider(localPlayer.latencyMs, 0, 1000);
            GUILayout.Label($"Packet loss (%): {localPlayer.packetLossPercent:F1}");
            localPlayer.packetLossPercent = GUILayout.HorizontalSlider(localPlayer.packetLossPercent, 0f, 50f);

            GUILayout.Space(8);
            GUILayout.Label($"Send interval (ms): {(int)(localPlayer.sendInterval*1000)}");
            localPlayer.sendInterval = GUILayout.HorizontalSlider(localPlayer.sendInterval, 0.02f, 0.2f);
        }
        GUILayout.EndArea();
    }
}
