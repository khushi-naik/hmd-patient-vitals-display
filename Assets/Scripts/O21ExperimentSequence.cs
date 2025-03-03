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
    public static float o21Block1Start = 96;

    //patient 1 block 1
    public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false), //remove later
        //new O2Block1(new float[]{90f,90f,90f,90f,88f,87f,85f,84f,82f,80f,80f,80f,80f,80f,80f,82f,82f,84f,84f,84f},false), //o2-vl subblock2 of block1 start //remove later
        new O2Block1(new float[]{98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f,98f},false), //remove later
        new O2Block1(new float[]{96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f,96f},false), //subblock1 of block 1 start
        new O2Block1(new float[]{96f,96f,96f,95.3f,95f,94.9f,94.5f,94.1f,93f,92f,91f,90.7f,90f,90f,90f,90f,90f,90f,90f,90f},false),     //o2-l
        new O2Block1(new float[]{90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},true),     //probe1 
        new O2Block1(new float[]{91f,92f,93f,94f,95f,96f,97f,97f,97f,97f,97f,97f,97f,96f,96f,96f,96f,96f,96f,96f},false),
        new O2Block1(new float[]{96f,96f,96f,95.7f,95.2f,94.8f,94f,93.7f,93f,92f,91f,90.5f,90f,90f,90f,90f,90f,90f,90f,90f},false), //o2-l subblock1 of block 1 end
        new O2Block1(new float[]{90f,90f,90f,90f,88f,87f,85f,84f,82f,80f,79f,78f,76f,73f,73f,73f,73f,84f,84f,84f},false), //o2-vl subblock2 of block1 start
        new O2Block1(new float[]{84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f,84f},true),     //probe2
        new O2Block1(new float[]{86f,86f,89f,89f,89f,90f,91f,93f,93f,93f,94f,95f,96f,97f,97f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{97f,97f,97f,97f,97f,96f,95f,94f,93.9f,93.6f,93f,92.8f,92.4f,92f,91.9f,90f,90f,90f,90f,90f},false),     //o2-l
        new O2Block1(new float[]{90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},false),//, //subblock2 of block1 end
        new O2Block1(new float[]{90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},false), //subblock3 of block1 start
        new O2Block1(new float[]{90f,90f,90f,88f,87f,86f,85f,83f,81f,78f,76f,75f,74f,74f,74f,85f,85f,88f,89f,89f},false),     //o2-vl
        new O2Block1(new float[]{89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f,89f},true),     //probe3
        new O2Block1(new float[]{89f,89f,89f,89f,89f,89f,92f,92f,92f,93f,94f,95f,96f,96f,96f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},false), //subblock3 of block1 end
        new O2Block1(new float[]{97f,96f,96f,95.8f,95f,94.5f,94f,93.6f,93f,92.2f,92f,91f,90f,90f,90f,94f,95f,96f,97f,97f},false), //o2-l subblock4 of block1 start
        new O2Block1(new float[]{97f,97f,97f,97f,97f,97f,97f,97f,97f,96f,96f,96f,95f,94.4f,94f,93f,92.9f,92f,91.7f,91f,90.5f,90f},false),     //o2-l
        /*new O2Block1(new float[]{90f,90f,90f,90f,87f,86f,85f,83f,82f,79f,82f,82f,82f,82f,82f,85f,87f,88f,89f,89f},false),     //o2-vl
        new O2Block1(new float[]{90f,94f,95f,96f,96f,95f,94f,93f,92f,91f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},false),     //o2-l
        new O2Block1(new float[]{90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},true), //probe4 subblock4 of block1 end
        new O2Block1(new float[]{90f,90f,90f,90f,88f,86f,84f,83f,82f,81f,81f,81f,81f,81f,81f,85f,86f,87f,89f},false), //o2-vl subblock5 of block1 start
        new O2Block1(new float[]{90f,92f,93f,94f,95f,96f,96f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f,97f},false),
        new O2Block1(new float[]{97f,97f,97f,97f,97f,95f,94f,93f,92f,91f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},false),     //o2-l
        new O2Block1(new float[]{90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f},true),     //probe5
        new O2Block1(new float[]{90f,90f,90f,90f,90f,88f,87f,86f,85f,84f,83f,83f,83f,83f,83f,83f,83f,83f,83f,83f},false), //o2-vl subblock5 of block1 end
        new O2Block1(new float[]{85f,86f,87f,88f,90f,92f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f},false), //subblock6 of block1 start
        new O2Block1(new float[]{93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f},false),
        new O2Block1(new float[]{93f,93f,93f,89f,88f,86f,85f,84f,82f,80f,79f,78f,76f,76f,76f,76f,82f,82f,82f,82f},false),     //o2-vl
        new O2Block1(new float[]{82f,85f,86f,88f,89f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f},false),
        new O2Block1(new float[]{93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f,93f},true) //probe6 subblock6 of block1 end*/
    };

    //patient 1 block 2
    /*public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        new O2Block1(new float[]{93,93,93,93,93,93,93,89,88,87,86,85,84,84,84,84,87,89,90,90}), //o2-vl subblock1 of block 2 start
        new O2Block1(new float[]{91,92,93,95,96,96,96,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,97,96,95,94,93,92,91,90,90,90,90,90,90,90,90}),     //o2-l 
        new O2Block1(new float[]{91,92,93,94,95,96,97,97,97,97,97,97,97,96,96,96,96,96,96,96}),
        new O2Block1(new float[]{96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96}), //probe1 subblock1 of block 2 end
        new O2Block1(new float[]{96,96,96,96,96,96,96,95,94,93,92,91,90,90,90,90,90,90,90,90}), //o2-l subblock2 of block2 start
        new O2Block1(new float[]{90,90,90,90,90,88,87,85,84,82,80,80,80,80,80,82,84,87,88,89}),     //o2-vl
        new O2Block1(new float[]{89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89}),     //probe2
        new O2Block1(new float[]{89,89,89,87,85,84,83,82,81,81,81,81,82,83,84,86,87,88,89}),     //o2-vl
        new O2Block1(new float[]{89,89,89,89,88,86,85,84,83,82,82,82,82,82,82,82,82,82,82,82}), //o2-vl subblock2 of block2 end
        new O2Block1(new float[]{82,82,87,89,91,92,94,95,96,97,97,97,97,97,97,97,97,97,97,97}), //subblock3 of block2 start    
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),     //probe3
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,95,94,93,92,91,90,90,90,90,91,94,95,97,97,97}), //o2-l subblock3 of block2 end
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}), //probe4 subblock4 of block2 start
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90,90}),     //o2-l
        new O2Block1(new float[]{90,90,90,90,91,92,93,94,95,97,97,97,97,97,97,97,97,97,97,97}), //subblock4 of block2 end
        new O2Block1(new float[]{97,97,97,96,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90,90}), //o2-l subblock5 of block2 start
        new O2Block1(new float[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90}),      //probe5 
        new O2Block1(new float[]{90,90,90,90,90,88,86,84,83,82,81,81,81,81,81,81,85,86,87,89}),      //o2-vl
        new O2Block1(new float[]{89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89}),
        new O2Block1(new float[]{90,92,93,94,95,96,96,97,97,97,97,97,97,97,97,97,97,97,97,97}), //subblock5 of block2 end
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}), //subblock6 of block2 start
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90}),     //o2-l
        new O2Block1(new float[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90}),     //probe6
        new O2Block1(new float[]{90,90,90,90,90,92,93,95,96,96,97,97,97,97,97,97,97,97,97,97}), //subblock6 of block2 end
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}), //subblock7 of block2 start
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),     //o2-vl
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new float[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}) //subblock7 of block2 end
    };*/
}
