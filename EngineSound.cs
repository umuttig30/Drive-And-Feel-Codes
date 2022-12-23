using UnityEngine;

public class EngineSound : MonoBehaviour
{

    AudioSource audioSource;
    public float minPitch = 0.05f;
    public RPM rpm;
    private float pitchFromCar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }


    void Update()
    {
        pitchFromCar = rpm.Speed / 37;

        if (pitchFromCar < minPitch)
            audioSource.pitch = minPitch;

        else
            audioSource.pitch = pitchFromCar;
    }
}
