using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class DoorController : MonoBehaviour {

    public bool isOpen;
    public Vector3 openRotation;
    public Vector3 closedRotation;
    public Transform ObjectToRotate;
    public VRInteractiveItem VR_InteractiveItem;
	// Use this for initialization
	void Start () {
        //Update the current state of the door;
        UpdateDoorState();
	}
	
    void ToggleDoor()
    {
        //This will just use isOpen to toggle the door open or closed
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        // Set isOpen and call to update the actual door in the scene via the UpdateDoorState() function
        isOpen = false;
        UpdateDoorState();
    }

    void CloseDoor()
    {
        // Set isOpen and call to update the actual door in the scene via UpdateDoorState() function
        isOpen = true;
        UpdateDoorState();
    }

    void UpdateDoorState()
    {
        // Here we adjust the rotation of the door so that it is physically open or closed
        if (isOpen)
        {
            ObjectToRotate.localEulerAngles = openRotation;
        }
        else
        {
            ObjectToRotate.localEulerAngles = closedRotation;
        }
    }

    private void OnEnable()
    {
        // Subsribe to events from VR_InteractiveItem
        VR_InteractiveItem.OnClick += OnClick;
    }

    private void OnDisable()
    {
        // Call to unsubscribe from events from VR_InteractiveItem
        VR_InteractiveItem.OnClick -= OnClick;
    }

    void OnClick()
    {
        // Call to toggle the door open or closed
        ToggleDoor();
    }
}
