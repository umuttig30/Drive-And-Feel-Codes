using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    //SPEEDOMETER

    [SerializeField] public RectTransform needle;
    [SerializeField] public float minimumAngle = default;
    [SerializeField] public float maximumAngle = default;
    [SerializeField] public float minimumSpeed = default;
    [SerializeField] public float maximumSpeed = default;
    [SerializeField] public float animationspeed;
    public float speed;
    public bool StopSpeed;
    public RPM rpm;
    public Text SpeedLable;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, min: minimumSpeed, max: maximumSpeed);
    }

    private void OnDrawGizmos()
    {
        var minRotation = Quaternion.AngleAxis(minimumAngle, Vector3.forward);
        var maxRotation = Quaternion.AngleAxis(maximumAngle, Vector3.forward);
        var minVector = minRotation * Vector3.up * 150f;
        var maxVector = maxRotation * Vector3.up * 150f;

        Gizmos.DrawRay(from: transform.position, direction: minVector);
        Gizmos.DrawRay(from: transform.position, direction: maxVector);
    }

    private void Update()
    {
        Setspeedneedle();
    }

    private void Setspeedneedle()
    {
        var angle = Mathf.Lerp(a: minimumAngle, b: maximumAngle, t: Mathf.InverseLerp(a: minimumSpeed, b: maximumSpeed, value: Speed));
        var value = Mathf.Lerp(a: ClampDegrees(needle.eulerAngles.z), b: angle, t: Time.deltaTime * animationspeed);
        needle.transform.rotation = Quaternion.Euler(x: 0, y: 0, z: value);

        int speedd = System.Convert.ToInt32(Speed * 2.375);
        if (SpeedLable != null)
        {
            SpeedLable.text = speedd.ToString();
        }
        if (rpm.Gear == 1 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.11f;
        }
        if (rpm.Gear == 2 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.07f;
        }
        if (rpm.Gear == 3 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.045f;
        }
        if (rpm.Gear == 4 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.03f;
        }
        if (rpm.Gear == 5 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.0225f;
        }
        if (rpm.Gear == 6 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.015f;
        }
        if (rpm.Gear == 7 && Input.GetKey(KeyCode.W) && StopSpeed == false)
        {
            Speed += 0.015f;
        }
        else if (rpm.Gear == 1 && Input.GetKey(KeyCode.W) == false && StopSpeed == false)
        {
            Speed -= 0.025f;
        }
        else if (rpm.Gear > 1 && rpm.Gear < 5 && Input.GetKey(KeyCode.W) == false && StopSpeed == false)
        {
            Speed -= 0.0125f;
        }
        else if (rpm.Gear > 4 && rpm.Gear < 8 && Input.GetKey(KeyCode.W) == false && StopSpeed == false)
        {
            Speed -= 0.01f;
        }

        if (rpm.Gear == 2 && Input.GetKey(KeyCode.W) && StopSpeed == false && Speed >= 0 && Speed <= 20)
        {
            Speed += 0.05f;
        }
        if (rpm.Gear == 3 && Input.GetKey(KeyCode.W) && StopSpeed == false && Speed <= 30)
        {
            Speed += 0.05f;
        }
        if (rpm.Gear == 4 && Input.GetKey(KeyCode.W) && StopSpeed == false && Speed <= 35)
        {
            Speed += 0.05f;
        }
        if (rpm.Gear == 5 && Input.GetKey(KeyCode.W) && StopSpeed == false && Speed <= 40)
        {
            Speed += 0.025f;
        }
        if (rpm.Gear == 6 && Input.GetKey(KeyCode.W) && StopSpeed == false && Speed <= 45)
        {
            Speed += 0.025f;
        }

    }

    /* private void Speedneedlestops()         
     {
         if (Speed >= 30 && rpm.Gear == 1)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 30;

             }
             if (Input.GetKey(KeyCode.W) == false)
             {
                 Speed -= 0.00025f;
             }

         }
         if (Speed >= 43 && rpm.Gear == 2)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 43;

             }
         }
         if (Speed >= 62 && rpm.Gear == 3)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 62;
             }
         }
         if (Speed >= 90 && rpm.Gear == 4)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 90;

             }

         }
         if (Speed >= 120 && rpm.Gear == 5)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 120;

             }

         }
         if (Speed >= 140 && rpm.Gear == 6)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 140;

             }

         }
         if (Speed >= 160 && rpm.Gear == 7)
         {
             if (Input.GetKey(KeyCode.W))
             {
                 Speed = 160;

             }
         }
     }*/


    private float ClampDegrees(float degrees)
    {
        var clamped = degrees;
        if (clamped > minimumAngle)
        {
            clamped -= 360;
        }
        if (clamped < maximumAngle)
        {
            clamped += 360;
        }
        return clamped;
    }

}


