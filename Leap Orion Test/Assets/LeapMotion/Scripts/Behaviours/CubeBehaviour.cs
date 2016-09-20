using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;


//手の座標をとって箱をつくって作った箱の座標に手の座標を代入する奴

public class CubeBehaviour : MonoBehaviour{
    LeapProvider provider;

    private GameObject Controller;
    private GameObject CubePosition;

   

    // Use this for initialization
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        CubePosition = GameObject.Find("Cube");
    }

    private class MakeCube {
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Cube")
                GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


      Frame frame = provider.CurrentFrame;
      List<Hand> hands = frame.Hands;
      for (int h = 0; h < hands.Count; h++)
      {
        Hand hand = hands[h];
          Vector handCenter = hand.PalmPosition;
            Vector3 HandPos = handCenter.ToVector3(); // Convert LeapScale to UnityScale
            Debug.Log(HandPos);

        if (hand.IsLeft)
        {
            transform.position = hand.PalmPosition.ToVector3() +
                                 hand.PalmNormal.ToVector3() *
                                (transform.localScale.y * .5f + .02f);
                transform.rotation = hand.Basis.rotation.ToQuaternion();
            }

        }
      
       
  }
}