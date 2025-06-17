using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay = 0.3f;
    [SerializeField] AudioClip CrashSFX;
    [SerializeField] AudioClip SuccessSFX;
    [SerializeField] ParticleSystem SuccessParticle;
    [SerializeField] ParticleSystem CrashParticle;
    AudioSource audioSource;

    bool isContolable = true;
    bool iscollidable = true;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    void OnCollisionEnter(Collision other)
    {
        if (!isContolable || !iscollidable) return;
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("ohh its friend we collide into no worries");
                break;
            case "Fuel":
                Debug.Log("fullll energy!!!!!");
                break;
            case "Finish":
                StartNewLevelSequence();
                break;
            default:
                StartCrashSequence();
                break;

        }
    }

    private void StartNewLevelSequence()
    {
        isContolable = false;
        audioSource.PlayOneShot(SuccessSFX, 0.4f);
        SuccessParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("loadNextScene", LoadDelay);

    }

    private void StartCrashSequence()
    {


        isContolable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(CrashSFX, 0.2f);
        CrashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LoadDelay);
    }

    void loadNextScene()
    {
        isContolable = true;
        audioSource.Stop();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextscene = currentScene + 1;
        if (nextscene == SceneManager.sceneCountInBuildSettings)
        {
            nextscene = 0;
        }
        SceneManager.LoadScene(nextscene);

    }

    void ReloadLevel()
    {
        isContolable = true;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    
}
