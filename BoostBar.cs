using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider BoostSlider;
    public float Boostfill;
    public float currentvelocity;
    public Speedometer speedometer;
    public RPM rpm;
    float currentVelocity = 0;

    void Update()
    {
        BoosttBar();
    }
    private void BoosttBar()
    {
        float currentScore = Mathf.SmoothDamp(BoostSlider.value, Boostfill, ref currentVelocity, 100 * Time.deltaTime);

        BoostSlider.value = currentScore;
        if (Boostfill < 0)
        {
            Boostfill = 0;
        }
        if (Boostfill > 1)
        {
            Boostfill = 1;
        }

        if (Input.GetKey(KeyCode.W) == false)
        {
            Boostfill -= 0.0175f;
        }

        if (rpm.Gear == 1 && Input.GetKey(KeyCode.W))
        {
            Boostfill += 0.0175f;
        }
        if (rpm.Gear > 1 && rpm.Gear < 5 && rpm.Speed <= 40 && Input.GetKey(KeyCode.W))
        {
            Boostfill += 0.0075f;
        }
        if (rpm.Gear > 4 && rpm.Gear < 8 && rpm.Speed <= 50 && Input.GetKey(KeyCode.W))
        {
            Boostfill += 0.0075f;
        }
        if (rpm.Gear > 1 && rpm.Gear < 5 && rpm.Speed >= 40 && Input.GetKey(KeyCode.W))
        {
            Boostfill += 0.0175f;
        }
        if (rpm.Gear > 4 && rpm.Gear < 8 && rpm.Speed >= 50 && Input.GetKey(KeyCode.W))
        {
            Boostfill += 0.015f;
        }



    }
}
