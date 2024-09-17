using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ReconnectManager : MonoBehaviourPunCallbacks
{
    public float reconnectInterval = 5f;
    private bool tryingToReconnect = false;


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Desconectado: {cause}");
        if (!tryingToReconnect)
        {
            tryingToReconnect = true;
            InvokeRepeating(nameof(TryReconnect), reconnectInterval, reconnectInterval);
        }
    }

    private void TryReconnect()
    {
        if (PhotonNetwork.IsConnected)
        {
            CancelInvoke(nameof(TryReconnect));
            tryingToReconnect = false;
            Debug.Log("Ya conectado");
            return;
        }

        Debug.Log("Intentando reconectar...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al servidor maestro.");
        if (tryingToReconnect)
        {
            CancelInvoke(nameof(TryReconnect));
            tryingToReconnect = false;
            Debug.Log("Reconexión exitosa.");
        }
    }
}

