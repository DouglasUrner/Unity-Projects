using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float rate = 5.0f;
    public float threshold = 0.1f;

    // UI Elements
    public TMP_Text pitchText;
    public TMP_Text infoText;
    public TMP_Text rollText;

    float thresholdRad; // Radians are used internally.

    // XXX - don't know why we need to do this...
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        // XXX - hack to make the sphere respond to gravity until
        // I figure out why it doesn't move from the start when
        // the plane tilts.
        //sphere.SetActive(false);

        string m_DeviceType;

        switch (SystemInfo.deviceType)
        {
            case DeviceType.Console:
                m_DeviceType = "Console";
                infoText.text = m_DeviceType;
                break;
            case DeviceType.Desktop:
                m_DeviceType = "Desktop";
                infoText.text = m_DeviceType;
                break;
            case DeviceType.Handheld:
                m_DeviceType = "Handheld";
                infoText.text = m_DeviceType;
                break;
            case DeviceType.Unknown:
                m_DeviceType = "Unknown";
                infoText.text = m_DeviceType;
                break;
            default:
                m_DeviceType = "Default";
                infoText.text = m_DeviceType;
                break;
        }

        // Debug.Log("SystemInfo.deviceType: deviceType." + m_DeviceType);
    }

    // Update is called once per frame
    void Update()
    {
        float pitch = GetPitch();
        float roll = GetRoll();

        // XXX - the rest of the hack.
        // It appears that there needs to be a bit of a delay before
        // making the sphere active again.
        // thresholdRad = threshold / 180 * Mathf.PI;
        // if (sphere.activeSelf == false && (
        //         Mathf.Abs(transform.rotation.x) > thresholdRad ||
        //         Mathf.Abs(transform.rotation.z) > thresholdRad))
        // {
        //     sphere.SetActive(true);
        // }

        transform.Rotate(Vector3.left, pitch * Time.deltaTime * rate);
        transform.Rotate(Vector3.back, roll * Time.deltaTime * rate);

        // Update UI
        pitchText.text = "Pitch: " +
            UnwrapAngle(transform.localEulerAngles.x).ToString("F1") + "°";
        rollText.text = "Roll: " +
            UnwrapAngle(transform.localEulerAngles.z).ToString("F1") + "°";
    }

    float GetPitch()
    {
        float rv;

        switch (SystemInfo.deviceType)
        {
            case DeviceType.Console:
                rv = 0.0f;
                break;
            case DeviceType.Desktop:
                rv = Input.GetAxis("Vertical");
                break;
            case DeviceType.Handheld:
                rv = 0.0f;
                break;
            case DeviceType.Unknown:
                // XXX - what should we do?;
                rv = 0.0f;
                break;
            default:
                // XXX - what should we do?;
                rv = 0.0f;
                break;
        }

        return rv;
    }

    float GetRoll()
    {
        float rv;

        switch (SystemInfo.deviceType)
        {
            case DeviceType.Console:
                rv = 0.0f;
                break;
            case DeviceType.Desktop:
                rv = Input.GetAxis("Horizontal");
                break;
            case DeviceType.Handheld:
                rv = 0.0f;
                break;
            case DeviceType.Unknown:
                // XXX - what should we do?;
                rv = 0.0f;
                break;
            default:
                // XXX - what should we do?;
                rv = 0.0f;
                break;
        }

        return rv;
    }

    private static float UnwrapAngle(float angle)
    {
        angle = angle % 360;

        if (angle >= 0 && angle <= 180)
        {
                return angle;
        }
        else
        { 
            return -(360 - angle);
        }
    }
}
