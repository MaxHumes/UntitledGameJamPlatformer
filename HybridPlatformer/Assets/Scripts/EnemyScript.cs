using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private Vector3 maxXOffset; //how much the enemy is allowed to move on the platform

    public enum OscillationFunction{Sine, Cosine}

    public Vector3 StartPosition{
        get { return startPosition; }
        set { startPosition = value; }
    }

    void Start () {

        transform.position = startPosition;

        StartCoroutine(Oscillate(OscillationFunction.Cosine, -0.05f));

	}
	
	void Update () {
		
	}

    private IEnumerator Oscillate(OscillationFunction method, float scalar){

        while(true){

            if (method == OscillationFunction.Sine)
                transform.position += new Vector3(Mathf.Sin(Time.time) * scalar, 0);
            else if (method == OscillationFunction.Cosine)
                transform.position += new Vector3(Mathf.Cos(Time.time) * scalar, 0);

            yield return new WaitForEndOfFrame();
        }
    }
}
