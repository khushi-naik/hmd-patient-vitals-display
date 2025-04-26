using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Block2
{
    public float[] vitalValue;
    public O2Block2(float[] vitalValues)
    {
        this.vitalValue = vitalValues;
    }
}
public static class O22ExperimentSequence
{
    //patient 2 block 1 = 23+1
    public static readonly O2Block2[] O2ExperimentBlock2 =
    {
        //new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //dummy block
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), 
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), 
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //probe1
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //probe2
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), 
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f,98f,98f}),  //p2 before p1
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //probe3
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), 
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //probe4
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f})
        /*new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), 
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),                    //probe5
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f})*/
    };

    //patient 2 block 2 = 23+1
    /*public static readonly O2Block2[] O2ExperimentBlock2 =
    {
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), //dummy block
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), 
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), //probe1
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), //probe2
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), //probe3
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,95f,93f,90f,88f,86f,84f,83f,82f,80f,79f}), //patient 2 alarm after patient 1 alarm
        new O2Block2(new float[]{85f,90f,95f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), 
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), 
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), //probe4
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}),
        new O2Block2(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f}), //probe5
    };*/
}
