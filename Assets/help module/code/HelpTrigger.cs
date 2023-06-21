using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HelpTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Help Settings")]
   // [Tooltip("Arbitary text message")]
    public string sittuation = "test";

    [Header("Show storyline help first")]
    public bool storyLine = true;

    [Header("Show storyline once in app liftime")]
    public bool triggerOnce = true;

    [Header("Show contextual hints")]
    public bool contextualHints = true;

    [Header("Timeout period for help trigger")]
    [Tooltip("in seconds")]
    public float WaitPeriod = 2;

    private enum HelpState
    
    {
Passive,
Active,
Waiting
    }
  
    private HelpState currentState = HelpState.Passive;

    private IEnumerator HelpTimer;


    void Start()
    {

        HelpTimer = HelpTimeout(WaitPeriod);
       

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentState);


    }


    void EnterPassiveState()
    {

    }

    void EnterActiveState()
    {

    }

    public void ResetWait()
    {

    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        currentState = HelpState.Waiting;
        HelpTimer = HelpTimeout(WaitPeriod);
        StartCoroutine(HelpTimer);

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger leave");
        triggerPassive();
    }

    void triggerActive()
    {
        Debug.Log("active trigger");
        StopCoroutine(HelpTimer);
        currentState = HelpState.Active;

    }

    void triggerPassive()
    {
        Debug.Log("passive trigger");
        StopCoroutine(HelpTimer);
        Debug.Log(HelpTimer);
        currentState = HelpState.Passive;

    }

    public void HelpProceed()
    {
        triggerPassive();
    }


    public IEnumerator HelpTimeout(float waitTime)
    {
        Debug.Log("starting timer with: "+waitTime);
            yield return new WaitForSeconds(waitTime);
        Debug.Log("ding!!!!!!!!!");
            triggerActive();
    }

}
