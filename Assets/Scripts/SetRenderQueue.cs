using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetRenderQueue : MonoBehaviour {
    public int rQueue;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.renderQueue = rQueue;
        

        Transform trans = transform;
        for (int i = 0; i < trans.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Renderer>().material.renderQueue = rQueue;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
