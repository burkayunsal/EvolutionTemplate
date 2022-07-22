using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
  
    bool isUsed = false;

    public Door leftDoor, rightDoor;

    public bool HasUsed() => isUsed;


    private void Start()
    {
        leftDoor.parentGate = this;
        rightDoor.parentGate = this;
    }

    public void UseDoor()
    {
        isUsed = true;
    }
}
