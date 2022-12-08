using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPreserve : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    
}
