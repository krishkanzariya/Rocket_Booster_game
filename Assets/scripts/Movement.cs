using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] ParticleSystem jetParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;
    [SerializeField] AudioClip MainEngine;

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float ThrustPower = 10;
    [SerializeField] float RotatePower = 10;
    Rigidbody rb;
    AudioSource audioSource;
    public bool mobileThrust = false;
    public int mobileRotation = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    void FixedUpdate()
    {

        ProcessThrust();
        ProcessRotation();
    }

    public void ProcessThrust()
    {
        if (thrust.IsPressed() == true || mobileThrust)
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }
    }
    public void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * ThrustPower * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(MainEngine, 0.5f);
        }

        jetParticle.Play();

    }

    public void StopThrusting()
    {
        jetParticle.Stop();
        audioSource.Stop();
    }


    public void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        int combinedRotation = mobileRotation;

        if (rotationInput < 0)
            combinedRotation = 1;
        else if (rotationInput > 0)
            combinedRotation = -1;

        if (combinedRotation == 1)
            RotateRight();
        else if (combinedRotation == -1)
            RotateLeft();
        else
            StopRotate();

    }



    public void RotateLeft()
    {

        leftThrustParticle.Stop();
        rightThrustParticle.Play();

        ApplyRotation(-RotatePower);
    }

    public void RotateRight()
    {

        rightThrustParticle.Stop();
        leftThrustParticle.Play();

        ApplyRotation(RotatePower);
    }
    public void StopRotate()
    {
        rightThrustParticle.Stop();
        leftThrustParticle.Stop();
    }
    public void ApplyRotation(float RotateThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotateThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
    public void OnMobileThrustDown() => mobileThrust = true;
public void OnMobileThrustUp() => mobileThrust = false;

public void OnMobileLeftDown() => mobileRotation = 1;
public void OnMobileRightDown() => mobileRotation = -1;
public void OnMobileRotateUp() => mobileRotation = 0;

    
}
