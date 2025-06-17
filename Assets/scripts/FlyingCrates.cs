using UnityEngine;

public class FlyingCrates : MonoBehaviour
{
    [SerializeField] GameObject Crate1;
    [SerializeField] GameObject Crate2;
    [SerializeField] GameObject Crate3;

    void Awake()
    {
        Crate1.SetActive(false);
        Crate2.SetActive(false);
        Crate3.SetActive(false);
         
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("triggeres");
            Crate1.SetActive(true);
            Crate2.SetActive(true);
            Crate3.SetActive(true);
            // projectile4.SetActive(true);
            // projectile5.SetActive(true);
            
        }
    }
}
