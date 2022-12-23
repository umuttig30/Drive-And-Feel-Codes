using UnityEngine;
using UnityEngine.UI;
public class RPM : MonoBehaviour
{

    //REVOLUTIONS PER MINUTE

    public RectTransform RPMneedle;
    public float engineRPM;
    public float maxRPM, minRPM;
    private float desiredposition;
    private float startPosition = 32f, endPosition = -211f;
    public bool isRPMbreakerOn = false;

    [SerializeField] private float minimumAngle = default;
    [SerializeField] private float maximumAngle = default;
    [SerializeField] private float minimumSpeed = default;
    [SerializeField] private float maximumSpeed = default;
    [SerializeField] private float animationspeed;
    public float speed;
    public int Gear = 0;

    public bool isGasOffWhilegear = false;
    public bool limitRPMspeed = false;
    public bool isGearN = false;
    public Speedometer speedometer;
    public GameObject rpmneedle, speedstoptrigger;
    Collider2D rpmneedleCollider, speedstoptriggerCollider;
    public Text geartext;


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

    private void Start()
    {
        limitRPMspeed = false;
        Gear = 0;
    }

    private void Update()
    {
        controls();
        NeedleSpeeds();

        int geartextt = Gear;
        if (geartext != null)
        {
            if (geartextt == 0)
                geartext.text = "N";
            else
                geartext.text = geartextt.ToString();
        }
        if (Gear > 7)
            Gear = 7;
        if (Gear < 0)
            Gear = 0;
    }
    /* IEnumerator TurnTo()
     {
         var angle = Mathf.Lerp(a: minimumAngle, b: maximumAngle, t: Mathf.InverseLerp(a: minimumSpeed, b: maximumSpeed, value: Speed));
         var value = Mathf.Lerp(a: ClampDegrees(RPMneedle.eulerAngles.z), b: angle, t: Time.deltaTime * animationspeed);
         Vector3 desired = new Vector3(0, 0, value + 100f);
         Vector3 original_angle = transform.rotation.eulerAngles;
         for (float i = 0f; i < 1f + 1f / 30; i+= 1f / 30)
         {
            RPMneedle.transform.rotation = Quaternion.Euler(Vector3.Lerp(original_angle, desired, i));
             yield return new WaitForSeconds(1f/30);
         }
     }*/

    public void controls()
    {
        var angle = Mathf.Lerp(a: minimumAngle, b: maximumAngle, t: Mathf.InverseLerp(a: minimumSpeed, b: maximumSpeed, value: Speed));
        var value = Mathf.Lerp(a: ClampDegrees(RPMneedle.eulerAngles.z), b: angle, t: Time.deltaTime * animationspeed);

        if (Input.GetKey(KeyCode.W) && limitRPMspeed == false)
        {
            Speed += 0.75f;
        }
        if (Input.GetKey(KeyCode.W) == false && isGasOffWhilegear == false)
        {
            Speed -= 0.75f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) == false)
        {
            Gear++;
            Speed -= 40f;
            animationspeed = 14f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) == true)
        {
            Gear++;
            Speed -= 45;
            animationspeed = 14f;
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Gear--;
            Speed += 40f;
            animationspeed = 22.5f;
        }
    }

    public void NeedleSpeeds()
    {
        var angle = Mathf.Lerp(a: minimumAngle, b: maximumAngle, t: Mathf.InverseLerp(a: minimumSpeed, b: maximumSpeed, value: Speed));
        var value = Mathf.Lerp(a: ClampDegrees(RPMneedle.eulerAngles.z), b: angle, t: Time.deltaTime * animationspeed);
        RPMneedle.transform.rotation = Quaternion.Euler(x: 0, y: 0, z: value);

        if (Gear == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Speed += 0.6f;
            }
            else if (Input.GetKey(KeyCode.W) == false)
            {
                Speed -= 0.4f;
            }
            speedometer.Speed -= 0.009f;
        }

        if (Gear == 1 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.5f;
            limitRPMspeed = true;
        }

        if (Gear == 2 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.25f;
            limitRPMspeed = true;
        }


        if (Gear == 3 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.125f;
            limitRPMspeed = true;
        }

        if (Gear == 4 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.05f;
            limitRPMspeed = true;
        }

        if (Gear == 5 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.0375f;
            limitRPMspeed = true;
        }

        if (Gear == 6 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.025f;
            limitRPMspeed = true;
        }

        if (Gear == 7 && Input.GetKey(KeyCode.W))
        {
            Speed += 0.0225f;
            limitRPMspeed = true;
        }



        if (Gear == 1 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.0875f;
            isGasOffWhilegear = true;
        }
        if (Gear == 2 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.0625f;
            isGasOffWhilegear = true;
            limitRPMspeed = false;
        }
        if (Gear == 3 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.05f;
            isGasOffWhilegear = true;
            limitRPMspeed = false;
        }
        if (Gear == 4 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.0425f;
            isGasOffWhilegear = true;
            limitRPMspeed = false;
        }
        if (Gear == 5 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.0375f;
            isGasOffWhilegear = true;
            limitRPMspeed = false;
        }
        if (Gear == 6 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.03f;
            isGasOffWhilegear = true;
            limitRPMspeed = false;
        }
        if (Gear == 7 && Input.GetKey(KeyCode.W) == false)
        {
            Speed -= 0.025f;
            isGasOffWhilegear = true;
            limitRPMspeed = false;
        }


        if (speedometer.Speed < 45 && Input.GetKey(KeyCode.W) && Gear == 6)
        {
            Speed -= 0.025f;
        }
    }

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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collide")
        {
            speedometer.StopSpeed = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "RpmCollide")
        {
            if (Gear == 1)
                Speed -= 13f;
            else
                Speed -= 7f;
            animationspeed = 23;
            isRPMbreakerOn = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        isRPMbreakerOn = false;
        speedometer.StopSpeed = false;
    }
}
