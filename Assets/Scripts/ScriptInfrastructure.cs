using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInfrastructure : MonoBehaviour
{
    public static ScriptInfrastructure Instance;

    public GameObject player;
    public GameObject bullet;
    public GameObject net;
    public GameObject netBig;

    public PlayerMove playerMove;

    private void Awake()
    {
        Instance = this;
    }


}
