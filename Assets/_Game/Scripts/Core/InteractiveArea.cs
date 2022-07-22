using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{

    [SerializeField] MeshRenderer mr;

    [SerializeField] int val;

    private void Start()
    {
        InitiateArea();
    }

    void InitiateArea()
    {
        mr.material = EnvironmentManager.I.GetAreaMaterial(val);

        // TODO : if area has a animation etc. activate here
    }

    public void AreaEvent()
    {
        if (val == 0)
        {
            // Effect of the Area here...

        }

        if (val == 1)
        {
            // Effect of the Area here...

        }

    }
}
