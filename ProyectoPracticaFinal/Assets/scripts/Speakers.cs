using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : ObjetoControlable
{
    public List<AudioSource> altavoces;

    override
       public void apagar()
    {
        if (altavoces[0].isPlaying)
        {
            foreach (AudioSource altavoz in altavoces)
            {
                altavoz.Stop();
            }
        }
    }

    override
    public void encender()
    {
        if (!altavoces[0].isPlaying)
        {
            foreach (AudioSource altavoz in altavoces)
            {
                altavoz.Play();
            }
        }
    }
}
