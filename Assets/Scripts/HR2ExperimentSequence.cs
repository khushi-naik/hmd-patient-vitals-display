using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HrBlock2
{
    public int[] vitalValue;
    public HrBlock2(int[] vitalValues)
    {
        this.vitalValue = vitalValues;
    }
}

public static class HR2ExperimentSequence
{
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static int hr2Block2Start = 89;

    public static readonly HrBlock2[] hrExperimentBlock2 =
    {
        new HrBlock2(new int[]{120,120,120,121,123,124,125,127,129,129,129,129,129,129,129,129,129,129,129,127}),
        new HrBlock2(new int[]{125,124,122,121,119,118,116,115,112,110,110,110,110,110,110,110,110,110,110,110}),
        new HrBlock2(new int[]{110,110,111,113,114,116,118,120,120,120,120,120,120,120,120,120,120,120,120,120}),
        new HrBlock2(new int[]{120,122,123,125,129,130,131,131,131,131,131,131,131,131,131,127,126,124,123,122}),
        new HrBlock2(new int[]{122,122,122,124,125,127,128,130,133,133,133,133,133,130,127,126,125,123,121,120}),
        new HrBlock2(new int[]{120,120,113,117,107,101,95,90,86,84,78,77,74,73,72,68,68,65,65,65}),
        new HrBlock2(new int[]{65,62,59,58,56,56,56,56,56,56,56,56,56,56,54,51,50,48,47,46}),
        new HrBlock2(new int[]{46,45,44,42,41,40,38,35,35,35,35,35,35,35,35,35,35,35,35,35}),
        new HrBlock2(new int[]{35,35,34,33,32,31,30,29,34,39,43,47,50,51,53,55,56,56,56,56}),
        new HrBlock2(new int[]{59,61,66,69,74,76,79,80,83,85,89,91,91,91,91,92,93,95,95,95}),
        new HrBlock2(new int[]{96,98,99,100,104,107,109,112,117,117,117,117,117,117,117,117,117,117,117,117}),
        new HrBlock2(new int[]{117,117,117,117,117,117,117,117,117,117,117,117,117,117,117,117,117,117,117,117}),
        new HrBlock2(new int[]{117,122,124,125,129,131,136,136,136,136,136,136,132,130,125,124,123,122,121,121}),
        new HrBlock2(new int[]{118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118}), //with p2
        new HrBlock2(new int[]{118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118,118}),

    };
}
