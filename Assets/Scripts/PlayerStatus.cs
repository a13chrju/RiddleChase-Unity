using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coinsText, keysText;
    public AudioSource coinSound, dungeonAmbience, IntenseMoment;

    public int coins = 0, keys = 0;

    void Start()
    {

    }
    public void addCoinsUpdateUI()
    {
        coinSound.Play();
        coins++;
        coinsText.text = coins.ToString();
    }

    public void addKeysUpdateUI()
    {
        keys++;
        keysText.text = keys.ToString();
    }

    IEnumerator transformChange(AudioSource audioSource, float volume)
    {
        StartCoroutine(FadeA.StartFade(audioSource, 2f, volume));
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator playIntenseMusic ()
    {
        StartCoroutine(transformChange(dungeonAmbience, 0f));
        yield return new WaitForSeconds(2f);
        IntenseMoment.Play();
        StartCoroutine(transformChange(IntenseMoment, 0.7f));
    } 
}
