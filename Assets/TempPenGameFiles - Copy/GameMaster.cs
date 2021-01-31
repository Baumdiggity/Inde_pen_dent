using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Animator[] animators;
    public bool GasLeak;
    public bool TempRising;
    public bool megumin;
    public ParticleSystem steam;
    public ParticleSystem boom;
    // Start is called before the first frame update
    void Start()
    {
        steam.Stop();
        boom.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GasLeak)
            steam.Play();
        if (megumin)
            boom.Play();

        if(TempRising)
		{
            foreach(Animator ani in animators)
			{
                ani.SetTrigger("Open");
			}
		}

    }
}
