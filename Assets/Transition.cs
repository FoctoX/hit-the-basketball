using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Transition : MonoBehaviour
{
    public SoundScript soundScript;
    public float transitionDuration;
    float transitionLapse;
    Vector3 startPosition;
    Vector3 endPosition;

    public LogicManager logicManager;

    [SerializeField]
    private AnimationCurve curve;

    private void Awake()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>();
        soundScript = GameObject.FindGameObjectWithTag("VolumeTag").GetComponent<SoundScript>();
        startPosition = transform.localPosition;
        endPosition = new Vector3(transform.localPosition.x + 4400, transform.localPosition.y, transform.localPosition.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationFunction()
    {
        StartCoroutine(Animation(startPosition, endPosition));
    }

    public IEnumerator Animation(Vector3 start, Vector3 end)
    {
        logicManager.pressAble = false;
        soundScript.transitionSound.Play();
        transitionLapse = 0f;
        float percentage = 0f;

        while (percentage < 1f)
        {
            transitionLapse += Time.deltaTime;
            percentage = transitionLapse / transitionDuration;

            transform.localPosition = Vector3.Lerp(start, end, curve.Evaluate(percentage));
            yield return null;
        }

        transform.localPosition = end;
        logicManager.pressAble = true;
    }
}
