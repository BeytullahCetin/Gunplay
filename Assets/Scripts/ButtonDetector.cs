 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using System;
public class ButtonDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
      {
          if (Input.GetKeyDown(kcode))
              Debug.Log("KeyCode down: " + kcode);
 
         
      }
    }
}
