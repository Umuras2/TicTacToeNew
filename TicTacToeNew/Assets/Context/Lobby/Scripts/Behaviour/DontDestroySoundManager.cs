using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySoundManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
