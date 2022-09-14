using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    private static BGSound priv_instance = null;
    public static BGSound instance
    {
        get { return priv_instance; }
    }
    private void Awake() {
        if (priv_instance != null && priv_instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            priv_instance = null;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
