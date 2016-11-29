using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerCtrl : NetworkBehaviour {

    public const int init_ganet = 1000;
    public const int init_score = 0;
    [SyncVar]    public string team_name;
    [SyncVar]    public int ganet=init_ganet;
    [SyncVar]    public int score=init_score;
    [SyncVar]    public string Answer;
    public GameObject bulletPrefab;

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    [Command]
    void CmdFire()
    {
        //This [Command] code is run on the server!

        //create the bullet object from the bullet prefab locally
        var bullet = (GameObject)Instantiate(bulletPrefab, transform.position - transform.right, Quaternion.identity);
        //make the bullet move away in fornt of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.right * 4;
        //spawn the bullet on the clients
        NetworkServer.Spawn(bullet);

        //make bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);
    }
    void Update()
    {
        if (!isLocalPlayer)
            return;
        var x = Input.GetAxis("Horizontal") * 0.1f;
        var y = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }
    
    
}
