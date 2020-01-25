using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEventCanvas : MonoBehaviour
{
    [SerializeField]
    private Camera COCamera;
    [SerializeField]
    private GameObject COCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        COCamera = GameObject.FindWithTag("CombatOptions").GetComponent<Camera>();
        Canvas theCanvas = COCanvas.GetComponent<Canvas>();
        theCanvas.worldCamera = COCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
