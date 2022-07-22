using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    List<Door> passedDoors = new List<Door>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            OnDoorTriggered(other.gameObject);
        }

        if (other.CompareTag("Interactive"))
            OnInteractiveAreaTriggered(other.gameObject);

        if (other.CompareTag("FinishLine"))
            EndGameTriggered(other.transform.position);
    }

    void OnDoorTriggered(GameObject gameObject)
    {
        Door door = gameObject.GetComponent<Door>();

        if (passedDoors.Contains(door)) return;
            passedDoors.Add(door);

        if (door != null)
        {
            door.OnDoorUsed();
        }
    }

    void OnInteractiveAreaTriggered(GameObject gameObject)
    {
        InteractiveArea area = gameObject.GetComponent<InteractiveArea>();

        if (area != null)
        {
            area.AreaEvent();
        }
    }

    void EndGameTriggered(Vector3 finishPos)
    {
        PlayerController.I.OnLevelEnded(finishPos);
    }
}
