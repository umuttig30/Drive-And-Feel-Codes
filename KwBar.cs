using UnityEngine;
using UnityEngine.UI;

public class KwBar : MonoBehaviour
{

    public Slider kWSlider;
    public float kWfill;
    public float currentvelocity;
    public Speedometer speedometer;
    public RPM rpm;
    float currentVelocity = 0;
    public bool disableNormalkWBarFill = false;
    public Text kWLabel;


    void Update()
    {
        kWBarr();
        if (kWLabel != null)
        {
            int power = System.Convert.ToInt32(kWfill * 591);
            if (power < 0)
            {
                power = System.Convert.ToInt32(0);
            }
            kWLabel.text = power.ToString();
        }

    }


    private void kWBarr()
    {

        float currentScore = Mathf.SmoothDamp(kWSlider.value, kWfill, ref currentVelocity, 100 * Time.deltaTime);

        kWSlider.value = currentScore;
        if (kWfill < 0)
        {
            kWfill = 0;
        }
        if (kWfill > 1)
        {
            kWfill = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            kWfill -= 0.80f;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            kWfill -= 0.0175f;
        }
        if (rpm.Gear == 2 && Input.GetKey(KeyCode.W) && rpm.Speed >= 37)
        {
            kWfill += 0.0175f;
        }
        if (rpm.Gear == 3 && Input.GetKey(KeyCode.W) && rpm.Speed >= 40)
        {
            kWfill += 0.015f;
        }
        if (rpm.Gear == 4 && Input.GetKey(KeyCode.W) && rpm.Speed >= 45)
        {
            kWfill += 0.0125f;
        }
        if (rpm.Gear == 5 && Input.GetKey(KeyCode.W) && rpm.Speed >= 55)
        {
            kWfill += 0.0125f;
        }
        if (rpm.Gear == 6 && Input.GetKey(KeyCode.W) && rpm.Speed >= 60)
        {
            kWfill += 0.0125f;
        }
        if (rpm.Gear == 7 && Input.GetKey(KeyCode.W) && rpm.Speed >= 65)
        {
            kWfill += 0.0125f;
        }

        if (rpm.Gear == 1 && Input.GetKey(KeyCode.W))
        {
            kWfill += 0.0175f;
        }
        if (rpm.Gear == 2 && Input.GetKey(KeyCode.W) && rpm.Speed < 37)
        {
            if (kWfill > 0.75f)
                kWfill = 0.75f;
            kWfill += 0.0075f;
            disableNormalkWBarFill = true;
        }
        if (rpm.Gear == 3 && Input.GetKey(KeyCode.W) && rpm.Speed < 40)
        {
            if (rpm.speed < 25 && kWfill > 0.60f)
            {
                kWfill = 0.60f;
            }
            kWfill += 0.0025f;
            disableNormalkWBarFill = true;
        }
        if (rpm.Gear == 4 && Input.GetKey(KeyCode.W) && rpm.Speed < 45)
        {
            if (rpm.speed < 30 && kWfill > 0.55f)
            {
                kWfill = 0.55f;
            }
            kWfill += 0.002f;
            disableNormalkWBarFill = true;
        }
        if (rpm.Gear == 5 && Input.GetKey(KeyCode.W) && rpm.Speed < 55)
        {
            if (rpm.speed < 40 && kWfill > 0.47f)
            {
                kWfill = 0.47f;
            }
            kWfill += 0.00175f;
            disableNormalkWBarFill = true;
        }
        if (rpm.Gear == 6 && Input.GetKey(KeyCode.W) && rpm.Speed < 60)
        {
            if (rpm.speed < 43 && kWfill > 0.43f)
            {
                kWfill = 0.43f;
            }
            kWfill += 0.00175f;
            disableNormalkWBarFill = true;
        }
        if (rpm.Gear == 7 && Input.GetKey(KeyCode.W) && rpm.Speed < 65)
        {
            if (rpm.speed < 45 && kWfill > 0.40f)
            {
                kWfill = 0.40f;
            }
            kWfill += 0.00175f;
            disableNormalkWBarFill = true;
        }
        else
        {
            disableNormalkWBarFill = false;
        }

        if (rpm.Speed >= 97)
        {
            kWLabel.GetComponent<Text>().color = Color.red;
        }
        else
        {
            kWLabel.GetComponent<Text>().color = Color.white;
        }
    }


}
