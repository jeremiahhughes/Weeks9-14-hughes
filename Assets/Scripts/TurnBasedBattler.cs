using System.Collections;
using UnityEngine;

public class TurnBasedBattler : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform statue;
    public float speed = 10;
    public float z;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       statue.localEulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GrowStatue()
    {
        Debug.Log("Started Statue Rotating");
        statue.localEulerAngles = Vector3.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            statue.transform.localEulerAngles = new Vector3(0, 0, speed * curve.Evaluate(t));
            //curve.Evaluate(t);
            yield return null;
        }
        Debug.Log("Finished Statue Rotating");
    }

    public void StartStatueGrow()
    {
        StartCoroutine(GrowStatue());
    }
}
