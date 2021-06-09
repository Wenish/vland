using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;

public class GameManager : MonoBehaviour
{
    // public Client client = new Client("ws://localhost:3000");
    private static GameManager _instance;

    public static GameManager Instance 
    { 
        get { return _instance; } 
    }

    private void Awake() 
    { 
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Manager Start");
    }

    private static string GetArg(string name)
        {
            var args = System.Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == name && args.Length > i + 1)
                {
                    return args[i + 1];
                }
            }
            return null;
        }
}
