using System.Collections.Generic;
using UnityEngine;
using Mirror;

// A simple proximity-based visibility manager using Mirror's visibility hooks.
// Attach to objects that should be visible only to nearby players.
public class NetworkProximityChecker : NetworkVisibility
{
    public float interestRange = 50f;

    // Called on server to decide if a connection should see this object
    public override bool OnCheckObserver(NetworkConnectionToClient conn)
    {
        if (conn.identity == null) return false;
        var player = conn.identity.gameObject;
        if (player == null) return false;
        return Vector3.Distance(player.transform.position, transform.position) <= interestRange;
    }

    // Rebuild observers set (called on server)
    public override void OnRebuildObservers(HashSet<NetworkConnectionToClient> newObservers, bool initialize)
    {
        foreach (var kv in NetworkServer.connections)
        {
            var conn = kv.Value;
            if (conn != null && OnCheckObserver(conn)) newObservers.Add(conn);
        }
    }

    // If a connection is no longer an observer
    public override void OnSetHostVisibility(bool visible) { /* nothing special */ }
}
