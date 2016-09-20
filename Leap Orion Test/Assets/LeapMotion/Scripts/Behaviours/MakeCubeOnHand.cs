using UnityEngine;
using System.Collections;
using Leap;

public class MakeCubeOnHand : MonoBehaviour {

    GameObject CreatedObj;

    // Use this for initialization
    void Start() {
    }
	
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
            CreatedObj = GameObject.CreatePrimitive( PrimitiveType.Cube );
        }

        // Update is called once per frame
        void Update () {
        
        }

	
	}

