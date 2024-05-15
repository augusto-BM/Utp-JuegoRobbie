using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptLogicaEntreEscenas : MonoBehaviour
{
    private void Awake()
    {
        var DontDestroyScenes = FindObjectsOfType<scriptLogicaEntreEscenas>();
        if (DontDestroyScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
