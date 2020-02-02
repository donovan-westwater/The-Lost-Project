using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public Glitch_Flip[] flips;

    public void Flip()
    {
        foreach (GlitchObject glitch in flips)
        {
            glitch.ApplyChange();
        }
    }
}
