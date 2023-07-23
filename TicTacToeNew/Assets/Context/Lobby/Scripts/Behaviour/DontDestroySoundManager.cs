using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySoundManager : MonoBehaviour
{
    public static DontDestroySoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    
    
}
