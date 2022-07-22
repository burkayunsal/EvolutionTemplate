
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] MeshRenderer mr;

    public enum TimeCurrency
    {
        Mounths = 0,
        Years = 1
    }

    public TimeCurrency currencyType;

    [HideInInspector]
    public Gate parentGate;

    public bool isPositiveGate;

    [Range(0,999)][SerializeField] int val;

    [SerializeField] TextMeshPro txt;

    public int GetRealValue() => currencyType == TimeCurrency.Years ? val : val / 12;

    private void Start()
    {
        InitDoor();
    }

    void InitDoor()
    {

        if (isPositiveGate)
        {
            txt.text = val.ToString() + "\n" + currencyType.ToString();
        }
        else
        {
            txt.text = "-" + val.ToString() + "\n" + currencyType.ToString();
        }
        
        mr.material = EnvironmentManager.I.GetDoorMaterial(isPositiveGate ? 1 : 0);
    }

    public void OnDoorUsed()
    {
        //gate
        if (parentGate != null)
        {
            if (!parentGate.HasUsed())
            {
                parentGate.UseDoor();
                AddCurrency();
            }
        }
        //door
        else
        {
            AddCurrency();
        }

        FadeDoor();
    }

    void FadeDoor()
    {
        mr.material = EnvironmentManager.I.GetDoorMaterial(2);
    }

    void AddCurrency()
    {
        PlayerController.I.SetValue(GetRealValue(),isPositiveGate);
    }


}
