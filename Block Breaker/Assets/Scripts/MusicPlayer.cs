using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

    void Awake()
    {
        Debug.Log("MusicPlayer Awake : " + GetInstanceID());
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        Debug.Log("MusicPlayer Start : " + GetInstanceID());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
