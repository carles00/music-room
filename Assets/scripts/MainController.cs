using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{ 
    public List<GameObject> notes;
    // Start is called before the first frame update
    void Start()
    {
        notes[0].GetComponent<NoteTrigger>().SetTarget("red");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
