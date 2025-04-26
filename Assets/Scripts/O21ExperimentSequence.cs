using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class O2Block1
{
    public float[] vitalValue;
    public bool isProbe;
    public O2Block1(float[] vitalValues, bool isProbeValue)
    {
        this.vitalValue = vitalValues;
        this.isProbe = isProbeValue;
    }
}

public static class O21ExperimentSequence
{
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static float o21Block1Start = 98f;

    //patient 1 block 1
    public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        //new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),   //dummy block
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{96f,96f,94f,92f,90f,89f,86f,85f,82f,80f,79f,77f,77f,77f,84f,88f,95f,97f,97f,97f},false),   //o2-l
        new O2Block1(new float[]{97f,97f,97f,97f,97f,94f,92f,90f,89f,86f,85f,82f,80f,79f,77f,77f,77f,77f,77f,77f},false),   //hr-l,o2-l
        new O2Block1(new float[]{84f,88f,95f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},true),    //probe1
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},true),    //probe2
        new O2Block1(new float[]{96f,96f,96f,94f,93f,90f,89f,86f,84f,83f,80f,79f,76f,76f,76f,76f,80f,85f,89f,90f},false),   //bp-l,o2-l
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),   //p2 alarm before p1
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,95f,93f,91f,89f,86f,84f,83f,80f,79f,76f,76f,76f,76f,76f},false),   //hr-h,bp-h,o2-l
        new O2Block1(new float[]{80f,85f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f,91f},true),    //probe3
        new O2Block1(new float[]{96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f},false),
        new O2Block1(new float[]{96f,96f,96f,96f,96f,94f,92f,90f,89f,86f,85f,82f,80f,79f,77f,77f,77f,77f,84f,88f},false),   //o2-l
        new O2Block1(new float[]{95f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},true),    //probe4
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{96f,96f,96f,94f,92f,91f,89f,87f,85f,82f,80f,79f,78f,78f,78f,84f,88f,95f,97f,97f},false)   //bp-h,o2-l
        /*new O2Block1(new float[]{97f,97f,97f,97f,94f,92f,91f,89f,87f,85f,82f,80f,79f,78f,78f,78f,84f,88f,95f,98f},false),   //hr-l,bp-h,o2-l
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,94f,92f,91f,89f,87f,86f,81f,80f,79f,78f,78f,78f,78f,78f,84f},false),   //hr-h,o2-l
        new O2Block1(new float[]{95f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},true),    //probe5
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false)*/
    };

    //patient 1 block 2
    /*public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),   //dummy block
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,94f,92f,91f,89f,87f,86f,81f,80f,79f,78f,78f,78f,78f,84f},false),   //hr-l,bp-h,o2-l
        new O2Block1(new float[]{88f,95f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},true),    //probe1
        new O2Block1(new float[]{98f,98f,98f,98f,94f,92f,91f,89f,87f,86f,81f,80f,79f,78f,78f,78f,84f,88f,95f,98f},false),   //o2-l
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{96f,96f,96f,96f,96f,94f,92f,91f,89f,87f,86f,81f,80f,79f,78f,78f,78f,78f,84f,88f},false),   //hr-l,o2-l
        new O2Block1(new float[]{95f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},true),    //probe2
        new O2Block1(new float[]{97f,97f,97f,95f,93f,91f,89f,87f,85f,82f,80f,79f,78f,78f,78f,84f,88f,95f,97f,97f},false),   //bp-l,o2-l
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false),
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},true),    //probe3
        new O2Block1(new float[]{98f,98f,98f,95f,93f,91f,89f,87f,85f,82f,80f,79f,78f,78f,78f,84f,88f,95f,97f,97f},false),   //hr-h,o2-l
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{95f,93f,91f,89f,87f,85f,82f,80f,79f,78f,78f,78f,78f,78f,84f,88f,95f,97f,97f,97f,97f,97f,97f},false),   //o2-l //patient2 after patient1
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,95f,93f,92f,89f,87f,86f,83f,80f,79f,78f,78f,78f,84f,88f},false),   //hr-h,bp-h,o2-l
        new O2Block1(new float[]{95f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},true),    //probe4
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{97f,97f,97f,94f,93f,90f,89f,86f,84f,83f,80f,79f,76f,76f,76f,76f,80f,85f,89f,90f},false),   //bp-h,o2-l
        new O2Block1(new float[]{92f,94f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f},false),
        new O2Block1(new float[]{96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f},false),
        new O2Block1(new float[]{96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f},true),    //probe5
    };*/


}
