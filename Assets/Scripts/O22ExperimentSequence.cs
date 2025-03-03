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
    //patient 2 block 1
    public static readonly O2Block2[] O2ExperimentBlock2 =
    {
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //remove later
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //remove later
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //subblock 1 of block1
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //subblock 2 of block1
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}), //subblock 3 of block1
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        new O2Block2(new float[]{98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f, 98f}),
        /*new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 4 of block1
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 5 of block1
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 6 of block1
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98})*/
    };

    //patient 2 block 2
    /*public static readonly O2Block2[] O2ExperimentBlock2 =
    {
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 1 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 2 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 3 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,95,94,93,92,91,90,93,96}), //patient 2 alarm after patient 1 alarm
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 4 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 5 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 6 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}), //subblock 7 of block2
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),
        new O2Block2(new float[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98})
    };*/
}
