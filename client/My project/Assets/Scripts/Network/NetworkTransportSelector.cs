using UnityEngine;
using Mirror;

[DisallowMultipleComponent]
public class NetworkTransportSelector : MonoBehaviour
{
    public enum TransportType { Telepathy, Kcp, Websocket }
    public TransportType selected = TransportType.Telepathy;

    void Awake()
    {
        ApplyTransport(selected);
    }

    public void ApplyTransport(TransportType t)
    {
        // Ensure a NetworkManager exists
        if (NetworkManager.singleton == null)
        {
            Debug.LogWarning("No NetworkManager found in scene.");
            return;
        }

        // Remove transports not used and add the selected transport component
        var nmGO = NetworkManager.singleton.gameObject;

        // Telepathy
        var tele = nmGO.GetComponent<Mirror.TelepathyTransport>();
        // KCP
        var kcp = nmGO.GetComponent<kcp2k.KcpTransport>();
        // WebSocket (example using WebSocketTransport if available)
        var ws = nmGO.GetComponent<Mirror.Websocket.ClientWebSocketTransport>();

        // Add the selected transport if missing and disable others
        switch (t)
        {
            case TransportType.Telepathy:
                if (!tele) nmGO.AddComponent<Mirror.TelepathyTransport>();
                if (kcp) DestroyImmediate(kcp);
                if (ws) DestroyImmediate(ws);
                break;
            case TransportType.Kcp:
                if (!kcp)
                {
                    // Try to add kcp2k transport if available
                    var kcpType = System.Type.GetType("kcp2k.KcpTransport, Assembly-CSharp");
                    if (kcpType != null) nmGO.AddComponent(kcpType);
                    else Debug.LogWarning("kcp2k transport not found. Add kcp2k package to use KCP.");
                }
                if (tele) DestroyImmediate(tele);
                if (ws) DestroyImmediate(ws);
                break;
            case TransportType.Websocket:
                if (!ws)
                {
                    var wsType = System.Type.GetType("Mirror.Websocket.ClientWebSocketTransport, Mirror");
                    if (wsType != null) nmGO.AddComponent(wsType);
                    else Debug.LogWarning("Websocket transport not found in Mirror distribution.");
                }
                if (tele) DestroyImmediate(tele);
                if (kcp) DestroyImmediate(kcp);
                break;
        }

        Debug.Log($"NetworkTransportSelector: Applied transport {t}");
    }

    // Quick UI for runtime
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 240, 110), "Transport", GUI.skin.window);
        if (GUILayout.Button("Use Telepathy (TCP)")) { selected = TransportType.Telepathy; ApplyTransport(selected); }
        if (GUILayout.Button("Use KCP (UDP)")) { selected = TransportType.Kcp; ApplyTransport(selected); }
        if (GUILayout.Button("Use WebSocket")) { selected = TransportType.Websocket; ApplyTransport(selected); }
        GUILayout.EndArea();
    }
}
