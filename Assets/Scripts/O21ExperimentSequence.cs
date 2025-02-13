using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class O2Block1
{
    public int[] vitalValue;
    public bool isProbe;
    public O2Block1(int[] vitalValues, bool isProbeValue)
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
    public static int o21Block1Start = 96;

    //patient 1 block 1
    public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        new O2Block1(new int[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98},false), //remove later
        new O2Block1(new int[]{90,90,90,90,88,87,85,84,82,80,80,80,80,80,80,82,82,84,84,84},false), //o2-vl subblock2 of block1 start //remove later
        new O2Block1(new int[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98},false), //remove later
        new O2Block1(new int[]{96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96},false), //subblock1 of block 1 start
        new O2Block1(new int[]{96,96,96,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90,90,90},false),     //o2-l
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90},true),     //probe1 
        new O2Block1(new int[]{91,92,93,94,95,96,97,97,97,97,97,97,97,96,96,96,96,96,96,96},false),
        new O2Block1(new int[]{96,96,96,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90,90,90},true), //o2-l subblock1 of block 1 end
        new O2Block1(new int[]{90,90,90,90,88,87,85,84,82,80,80,80,80,80,80,82,82,84,84,84},false), //o2-vl subblock2 of block1 start
        new O2Block1(new int[]{84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84,84},true),     //probe2
        new O2Block1(new int[]{86,86,89,89,89,90,91,93,93,93,94,95,96,97,97,97,97,97,97,97},false),
        new O2Block1(new int[]{97,97,97,97,97,96,95,94,93,92,91,90,90,90,90,90,90,90,90,90},false),     //o2-l
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90},false),//, //subblock2 of block1 end
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90},false), //subblock3 of block1 start
        new O2Block1(new int[]{90,90,90,88,87,86,85,83,81,81,81,81,81,81,83,85,85,88,89,89},false),     //o2-vl
        new O2Block1(new int[]{89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89},true),     //probe3
        new O2Block1(new int[]{89,89,89,89,89,89,92,92,92,93,94,95,96,96,96,97,97,97,97,97},false),
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false), //subblock3 of block1 end
        new O2Block1(new int[]{97,96,96,95,94,93,92,91,90,90,90,94,95,96,96,96,97,97,97,97},false), //o2-l subblock4 of block1 start
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,96,95,94,93,92,91,90,90,90,90,90},false),     //o2-l
        new O2Block1(new int[]{90,90,90,90,87,86,85,83,82,79,82,82,82,82,82,85,87,88,89,89},false),     //o2-vl
        new O2Block1(new int[]{90,94,95,96,96,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90},false),     //o2-l
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90},true), //probe4 subblock4 of block1 end
        new O2Block1(new int[]{90,90,90,90,88,86,84,83,82,81,81,81,81,81,81,81,85,86,87,89},false), //o2-vl subblock5 of block1 start
        new O2Block1(new int[]{90,92,93,94,95,96,96,97,97,97,97,97,97,97,97,97,97,97,97,97},false),
        new O2Block1(new int[]{97,97,97,97,97,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90},false),     //o2-l
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90},true),     //probe5
        new O2Block1(new int[]{90,90,90,90,90,88,87,86,85,84,83,83,83,83,83,83,83,83,83,83},false), //o2-vl subblock5 of block1 end
        new O2Block1(new int[]{85,86,87,88,90,92,93,93,93,93,93,93,93,93,93,93,93,93,93,93},false), //subblock6 of block1 start
        new O2Block1(new int[]{93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93},false),
        new O2Block1(new int[]{93,93,93,89,88,86,85,84,82,82,82,82,82,82,82,82,82,82,82,82},false),     //o2-vl
        new O2Block1(new int[]{82,85,86,88,89,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93},false),
        new O2Block1(new int[]{93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93},true) //probe6 subblock6 of block1 end
    };

    //patient 1 block 2
    /*public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        new O2Block1(new int[]{93,93,93,93,93,93,93,89,88,87,86,85,84,84,84,84,87,89,90,90}), //o2-vl subblock1 of block 2 start
        new O2Block1(new int[]{91,92,93,95,96,96,96,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,97,96,95,94,93,92,91,90,90,90,90,90,90,90,90}),     //o2-l 
        new O2Block1(new int[]{91,92,93,94,95,96,97,97,97,97,97,97,97,96,96,96,96,96,96,96}),
        new O2Block1(new int[]{96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96,96}), //probe1 subblock1 of block 2 end
        new O2Block1(new int[]{96,96,96,96,96,96,96,95,94,93,92,91,90,90,90,90,90,90,90,90}), //o2-l subblock2 of block2 start
        new O2Block1(new int[]{90,90,90,90,90,88,87,85,84,82,80,80,80,80,80,82,84,87,88,89}),     //o2-vl
        new O2Block1(new int[]{89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89}),     //probe2
        new O2Block1(new int[]{89,89,89,87,85,84,83,82,81,81,81,81,82,83,84,86,87,88,89}),     //o2-vl
        new O2Block1(new int[]{89,89,89,89,88,86,85,84,83,82,82,82,82,82,82,82,82,82,82,82}), //o2-vl subblock2 of block2 end
        new O2Block1(new int[]{82,82,87,89,91,92,94,95,96,97,97,97,97,97,97,97,97,97,97,97}), //subblock3 of block2 start    
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),     //probe3
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,95,94,93,92,91,90,90,90,90,91,94,95,97,97,97}), //o2-l subblock3 of block2 end
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}), //probe4 subblock4 of block2 start
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90,90}),     //o2-l
        new O2Block1(new int[]{90,90,90,90,91,92,93,94,95,97,97,97,97,97,97,97,97,97,97,97}), //subblock4 of block2 end
        new O2Block1(new int[]{97,97,97,96,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90,90}), //o2-l subblock5 of block2 start
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90}),      //probe5 
        new O2Block1(new int[]{90,90,90,90,90,88,86,84,83,82,81,81,81,81,81,81,85,86,87,89}),      //o2-vl
        new O2Block1(new int[]{89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89}),
        new O2Block1(new int[]{90,92,93,94,95,96,96,97,97,97,97,97,97,97,97,97,97,97,97,97}), //subblock5 of block2 end
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}), //subblock6 of block2 start
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,95,94,93,92,91,90,90,90,90,90,90,90,90,90,90}),     //o2-l
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90}),     //probe6
        new O2Block1(new int[]{90,90,90,90,90,92,93,95,96,96,97,97,97,97,97,97,97,97,97,97}), //subblock6 of block2 end
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}), //subblock7 of block2 start
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),     //o2-vl
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}),
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97}) //subblock7 of block2 end
    };*/
}
