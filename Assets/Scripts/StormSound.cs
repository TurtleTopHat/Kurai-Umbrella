using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormSound : MonoBehaviour
{
    public AudioSource storm;

    // Start is called before the first frame update
    void Start()
    {
        storm = GetComponent<AudioSource>();
        storm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        storm.loop = true;
    }
}
