using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public LayerMask soundAble;
    [SerializeField] private AudioClip skeletonSound, trapSound;
    [SerializeField] private float radius;
    private AudioSource source =>  GetComponent<AudioSource>();
    private bool soundPlayed;
    private const float coolDown = 0.2f;
   

    private void Start()
    {
        StartCoroutine(Updater());
    }

    private IEnumerator Updater()
    {
        while (true) 
        {
            
            Collider[] detectedObjects = Physics.OverlapSphere(transform.position, radius,soundAble);
             soundPlayed = false;
            if (detectedObjects.Length > 0)
            {
                if (detectedObjects[0].GetComponent<SkeletonController>() != null)
                {
                    MakeSound(skeletonSound);
                }
                else if (detectedObjects[0].GetComponent<TrapTrigger>() != null)
                {
                    MakeSound(trapSound);
                }
            }
            if (!soundPlayed)
            {
                source.Stop(); 
            }

            yield return new WaitForSeconds(coolDown);
            
        }
    }

    private void MakeSound(AudioClip sound)
    {
        soundPlayed = true;
        if (source.clip != sound)
            source.clip = sound;

        if (!source.isPlaying)
   
            source.Play();
    }
}
