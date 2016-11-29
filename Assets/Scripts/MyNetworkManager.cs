using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MyNetworkManager: NetworkManager
{
    public InputField get_team;
    public Text msg;
    public void OnClickedHost()
    {
        StartHost();
        Debug.Log(isNetworkActive);
        Debug.Log(networkAddress);
    }
    public void OnClickedClient()
    {
        StartClient();
        Debug.Log(isNetworkActive);
    }
    
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("connected client address:" + conn.address);
    }
    
    public override void OnStartServer()
    {
        Debug.Log("starting OnStartServer()");
        Debug.Log("networkAddress :" + networkAddress);
        base.OnStartServer();
        Debug.Log("end OnStartServer()");
    }


    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
    }
    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
    }
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
    }
    

}
