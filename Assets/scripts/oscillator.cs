using UnityEngine;

public class oscillator : MonoBehaviour
{
    [SerializeField] Vector3 MovementVector;
    [SerializeField] float speed;
    float MovementFactor;
    Vector3 startPosition; 
    Vector3 endPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + MovementVector;
    }

    // Update is called once per frame
    void Update()
    {
        MovementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPosition, endPosition, MovementFactor);
    }
}
