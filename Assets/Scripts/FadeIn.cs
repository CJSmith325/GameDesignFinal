using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroyObject", 1);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
