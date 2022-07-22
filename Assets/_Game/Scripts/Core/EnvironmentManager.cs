using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : Singleton<EnvironmentManager>
{
    [SerializeField] Material[] doorMaterials;

    [SerializeField] Material[] areaMaterials;

    public Material GetDoorMaterial(int i)
    {
        return doorMaterials[i];
    }

    public Material GetAreaMaterial(int i)
    {
        return areaMaterials[i];
    }
}
