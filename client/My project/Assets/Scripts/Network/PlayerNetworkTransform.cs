using UnityEngine;
using Mirror;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerNetworkTransform : NetworkBehaviour
{
    [SyncVar] private Vector3 serverPosition;
    public float speed = 5f;
    public float interpolateSpeed = 10f;

    // Network tuning
    public float sendInterval = 0.05f; // seconds
    public bool simulateLatency = false;
    public int latencyMs = 100;
    public float packetLossPercent = 0f; // 0.0 - 100.0

    private CharacterController cc;
    private Camera cam;
    private float pitch = 0f;
    private float sendTimer = 0f;
    private int seq = 0;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = Camera.main;
        if (isLocalPlayer) Cursor.lockState = CursorLockMode.Locked;
        serverPosition = transform.position;
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.up * mx * 2f);
            pitch -= my * 2f;
            pitch = Mathf.Clamp(pitch, -80f, 80f);
            if (cam) cam.transform.localEulerAngles = new Vector3(pitch, 0, 0);

            Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            cc.SimpleMove(move.normalized * speed);

            // send updates periodically (batching)
            sendTimer += Time.deltaTime;
            if (sendTimer >= sendInterval)
            {
                sendTimer = 0f; seq++;
                if (simulateLatency)
                    StartCoroutine(SimulatedSend(seq, transform.position, sendInterval));
                else
                    CmdSendPosition(seq, transform.position, sendInterval);
            }
        }
        else
        {
            // Smooth remote players towards server position
            transform.position = Vector3.Lerp(transform.position, serverPosition, Time.deltaTime * interpolateSpeed);
        }
    }

    [Command(channel = Channels.Unreliable)]
    void CmdSendPosition(int seq, Vector3 pos, float dt)
    {
        // Server-side clamp/simple validation
        float maxStep = speed * dt * 1.5f;
        Vector3 delta = pos - transform.position;
        if (delta.magnitude > maxStep)
        {
            delta = Vector3.ClampMagnitude(delta, maxStep);
        }
        transform.position += delta;
        serverPosition = transform.position; // SyncVar -> clients
    }

    IEnumerator SimulatedSend(int seq, Vector3 pos, float dt)
    {
        // simulate packet loss
        if (Random.value < packetLossPercent * 0.01f) yield break;
        // simulate latency
        yield return new WaitForSeconds(latencyMs * 0.001f);
        CmdSendPosition(seq, pos, dt);
    }

    // Hook for when server updates position (for non-local clients)
    public override void OnStartClient()
    {
        base.OnStartClient();
        // ensure current position synced
        transform.position = serverPosition;
    }
}
