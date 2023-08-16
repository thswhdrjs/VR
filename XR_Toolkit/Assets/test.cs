using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class test : MonoBehaviour
{
    private SteamVR_TrackedObject device;
    string deviceType;

    // Start is called before the first frame update
    void Awake()
    {
        device = GetComponent<SteamVR_TrackedObject>();
        device.index = SteamVR_TrackedObject.EIndex.Device1;
    }

    // Update is called once per frame
    void Update()
    {
        deviceType = GetDeviceType(device);

        if (gameObject.name.ToLower().Contains("right"))
        {
            if (deviceType.ToLower().Contains("right_foot"))
            {
                device.index--;
                Destroy(GetComponent<test>());
            }
        }
        else if (gameObject.name.ToLower().Contains("left"))
        {
            if (deviceType.ToLower().Contains("left_foot"))
            {
                device.index--;
                Destroy(GetComponent<test>());
            }
        }

        if (device.index == SteamVR_TrackedObject.EIndex.End)
            device.index = SteamVR_TrackedObject.EIndex.Device1;
        else
            device.index++;
    }

    string GetDeviceType(SteamVR_TrackedObject device)
    {
        var error = ETrackedPropertyError.TrackedProp_Success;
        var result = new System.Text.StringBuilder((int)64);
        var capacity = OpenVR.System.GetStringTrackedDeviceProperty((uint)device.index, ETrackedDeviceProperty.Prop_ControllerType_String, null, 0, ref error);

        if (capacity > 1)
        {
            result = new System.Text.StringBuilder((int)capacity);
            OpenVR.System.GetStringTrackedDeviceProperty((uint)device.index, ETrackedDeviceProperty.Prop_ControllerType_String, result, capacity, ref error);
        }

        return result.ToString();
    }
}
