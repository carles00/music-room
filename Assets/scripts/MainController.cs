using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public List<GameObject> CirclesInteractuable;

    public GameObject startTrigger;
    public GameObject Progress;
    private CircleTrigger startCircle;
    private CircleTrigger blueCircle;
    private CircleTrigger redCircle;
    private CircleTrigger purpleCircle;
    private ProgressBar progressBar;
    private AudioSource finalSong;
    private Queue soundQueue;
    private int currentIndex;

    private bool gameFinished;
    private bool ended;
    public bool gameStarting = true;

    // Start is called before the first frame update

    void GenetareThreeCircles()
    {
        
        redCircle = CirclesInteractuable[currentIndex].GetComponent<CircleTrigger>();
        redCircle.SetTarget("red");

    
        blueCircle = CirclesInteractuable[currentIndex+1].GetComponent<CircleTrigger>();
        blueCircle.SetTarget("blue");


        purpleCircle = CirclesInteractuable[currentIndex+2].GetComponent<CircleTrigger>();
        purpleCircle.SetTarget("purple");
    }

    void Start()
    {
        gameFinished = false;
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(finalSong == null){
            finalSong = GetComponent<AudioSource>();

        }

        if(progressBar == null){
            progressBar = Progress.GetComponent<ProgressBar>();
            progressBar.current = 0;
            Progress.SetActive(false);
        }

        if(startCircle == null){
            startCircle = startTrigger.GetComponent<CircleTrigger>();
            startCircle.SetTarget("purple");
        }

        if(gameFinished){
            if(!ended){
                Progress.SetActive(false);
                finalSong.Play(0);
                ended = true;
            }
        }else{
            if(gameStarting){
                if(!startCircle.isActivated()){
                    Progress.SetActive(true);
                    GenetareThreeCircles();
                    gameStarting = false;
                }
            }else{
                if(allCirclesCollected()){
                    progressBar.addProgress(25);
                    
                    if(progressBar.getProgress() >= 100){
                        gameFinished = true;
                    }else{
                        currentIndex +=3;
                        GenetareThreeCircles();
                    }
                }
            }
        } 
        
        
    }     

    private bool allCirclesCollected(){
        return(!redCircle.isActivated() && !blueCircle.isActivated() && !purpleCircle.isActivated());
    }


}
