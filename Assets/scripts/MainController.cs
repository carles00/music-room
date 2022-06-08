using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{ 
    public List<GameObject> notes;
    public List<GameObject> CirclesInteractuable;
    private CircleTrigger blueCircle;
    private CircleTrigger redCircle;
    private CircleTrigger purpleCircle;
    // Start is called before the first frame update
    void GenetareThreeCircles()
    {
        int redIndex = Random.Range(0, 4);
        Debug.Log("red indx: "+ redIndex);
        redCircle = CirclesInteractuable[redIndex].GetComponent<CircleTrigger>();
        redCircle.SetTarget("red");

        int blueIndex = Random.Range(4, 8);
        Debug.Log("blue indx: "+ blueIndex);
        blueCircle = CirclesInteractuable[blueIndex].GetComponent<CircleTrigger>();
        blueCircle.SetTarget("blue");
        
        int purpleIndex = Random.Range(8, 12);
        Debug.Log("purple indx: "+ purpleIndex);
        purpleCircle = CirclesInteractuable[purpleIndex].GetComponent<CircleTrigger>();
        purpleCircle.SetTarget("purple");
    }

    void Start()
    {
        GenetareThreeCircles();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!redCircle.isActivated() && !blueCircle.isActivated() && !purpleCircle.isActivated())
        {
            GenetareThreeCircles();
        }
    }
}
