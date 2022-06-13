using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public List<GameObject> CirclesInteractuable;

    public GameObject startTrigger;
    private CircleTrigger startCircle;
    private CircleTrigger blueCircle;
    private CircleTrigger redCircle;
    private CircleTrigger purpleCircle;

    public bool gameStarting = true;
    // Start is called before the first frame update
    void GenetareThreeCircles()
    {
        int redIndex = Random.Range(0, 4);
        redCircle = CirclesInteractuable[redIndex].GetComponent<CircleTrigger>();
        redCircle.SetTarget("red");

        int blueIndex = Random.Range(4, 8);
        blueCircle = CirclesInteractuable[blueIndex].GetComponent<CircleTrigger>();
        blueCircle.SetTarget("blue");

        int purpleIndex = Random.Range(8, 12);
        purpleCircle = CirclesInteractuable[purpleIndex].GetComponent<CircleTrigger>();
        purpleCircle.SetTarget("purple");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startCircle == null){
            startCircle = startTrigger.GetComponent<CircleTrigger>();
            startCircle.SetTarget("purple");
        }

        if(!startCircle.isActivated()){
            if(gameStarting){
                GenetareThreeCircles();
                gameStarting = false;
            }
            if (!redCircle.isActivated() && !blueCircle.isActivated() && !purpleCircle.isActivated()){
                GenetareThreeCircles();
            }
        }
    }     
}
