using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float x = -0.5f;
    [SerializeField] float y = 0.5f;
    [SerializeField] float z = -0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    void Update()
    {
        rotate(x, y, z);
    }
    void rotate(float x,float y,float z)
    {
        x = x * Time.deltaTime;
        y = y * Time.deltaTime;
        z = z * Time.deltaTime;
        transform.Rotate(x, y, z);
    }
}
