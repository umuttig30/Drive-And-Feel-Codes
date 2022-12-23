using UnityEngine;
using UnityEngine.UI;

public class NmBar : MonoBehaviour
{

    public Slider NmSlider;
    public float Nmfill;
    public float currentvelocity;
    public Speedometer speedometer;
    public RPM rpm;
    float currentVelocity = 0;
    public bool disableNormalkWBarFill = false;
    public Text NmLabel;


    void Update()
    {
        NmBarr();
        if (NmLabel != null)
        {
            int power = System.Convert.ToInt32(Nmfill * 701);
            if (power < 0)
            {
                power = System.Convert.ToInt32(0);
            }
            NmLabel.text = power.ToString();
        }
    }

    private void NmBarr()
    {

        float currentScore = Mathf.SmoothDamp(NmSlider.value, Nmfill, ref currentVelocity, 100 * Time.deltaTime);

        NmSlider.value = currentScore;
        if (Nmfill < 0)
        {
            Nmfill = 0;
        }
        if (Nmfill > 1)
        {
            Nmfill = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Nmfill -= 0.80f;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            Nmfill -= 0.0175f;
        }

        if (rpm.Gear == 2 && Input.GetKey(KeyCode.W) && rpm.Speed <= 50)
        {
            Nmfill += 0.0175f;
        }

        if (rpm.Gear == 3 && Input.GetKey(KeyCode.W) && rpm.Speed <= 55)
        {
            Nmfill += 0.015f;
        }

        if (rpm.Gear == 4 && Input.GetKey(KeyCode.W) && rpm.Speed <= 60)
        {
            Nmfill += 0.0125f;
        }
        if (rpm.Gear == 5 && Input.GetKey(KeyCode.W) && rpm.Speed <= 65)
        {
            Nmfill += 0.0125f;
        }
        if (rpm.Gear == 6 && Input.GetKey(KeyCode.W) && rpm.Speed <= 70)
        {
            Nmfill += 0.0125f;
        }
        if (rpm.Gear == 7 && Input.GetKey(KeyCode.W) && rpm.Speed <= 75)
        {
            Nmfill += 0.0125f;
        }


        if (rpm.Gear == 1 && Input.GetKey(KeyCode.W))
        {
            Nmfill += 0.0175f;
        }
        if (rpm.Gear == 2 && Input.GetKey(KeyCode.W) && rpm.Speed >= 50)
        {
            if (Nmfill > 0.79f)
                Nmfill = 0.79f;
            Nmfill += 0.0075f;
        }
        if (rpm.Gear == 3 && Input.GetKey(KeyCode.W) && rpm.Speed >= 55)
        {
            if (Nmfill > 0.79f)
                Nmfill = 0.79f;
            Nmfill += 0.0075f;
        }
        if (rpm.Gear == 4 && Input.GetKey(KeyCode.W) && rpm.Speed >= 60)
        {
            if (Nmfill > 0.79f)
                Nmfill = 0.79f;
            Nmfill += 0.0075f;
        }
        if (rpm.Gear == 5 && Input.GetKey(KeyCode.W) && rpm.Speed >= 65)
        {
            if (Nmfill > 0.79f)
                Nmfill = 0.79f;
            Nmfill += 0.0075f;
        }
        if (rpm.Gear == 6 && Input.GetKey(KeyCode.W) && rpm.Speed >= 70)
        {
            if (Nmfill > 0.79f)
                Nmfill = 0.79f;
            Nmfill += 0.0075f;
        }
        if (rpm.Gear == 7 && Input.GetKey(KeyCode.W) && rpm.Speed >= 75)
        {
            if (Nmfill > 0.79f)
                Nmfill = 0.79f;
            Nmfill += 0.0075f;
        }

        if (rpm.Speed >= 97)
        {
            NmLabel.GetComponent<Text>().color = Color.red;
        }
        else
        {
            NmLabel.GetComponent<Text>().color = Color.white;
        }
    }
}
