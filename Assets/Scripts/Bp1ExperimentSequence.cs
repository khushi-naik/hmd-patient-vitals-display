using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BpBlock1
{
    public int[] vitalValue;
    public BpBlock1(int[] vitalValues)
    {
        this.vitalValue = vitalValues;
    }
}

public class Bp1ExperimentSequence
{
    // Start is called before the first frame update
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static int bp1Block1Start = 110;


    //patient 1 block1 = 23+1
    public static readonly BpBlock1[] BpExperimentBlock1 =
    {
        //new BpBlock1(new int[]{110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110}),   //dummy block
        new BpBlock1(new int[]{110,108,105,104,97,95,94,93,92,90,89,87,86,85,85,85,90,101,115,120}),                    //bp-l
        new BpBlock1(new int[]{124,130,137,140,142,143,145,146,149,150,153,154,155,155,155,140,133,121,111,108}),   //hr-h,bp-h
        new BpBlock1(new int[]{108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108}),
        new BpBlock1(new int[]{108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108}),
        new BpBlock1(new int[]{118,120,120,120,120,120,120,120,120,120,120,120,120,120,120,120,120,120,120,120}),   //probe1
        new BpBlock1(new int[]{120,129,137,140,142,143,145,146,149,150,153,154,155,155,155,140,133,121,111,108}),   //bp-h
        new BpBlock1(new int[]{108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108}),
        new BpBlock1(new int[]{108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108,108}),   //probe2
        new BpBlock1(new int[]{105,104,103,100,98,96,95,94,92,91,89,88,86,86,86,86,90,99,99,99}),                   //bp-l,o2-l
        new BpBlock1(new int[]{99,105,107,111,114,119,122,126,127,130,133,135,137,137,137,137,137,137,137,137,137,137,137}),    //P2 alarm before P1
        new BpBlock1(new int[]{137,137,137,137,137,141,143,146,147,149,150,151,152,153,154,154,150,145,140,139}),   //bp-h
        new BpBlock1(new int[]{135,135,135,135,135,135,141,142,143,144,145,146,147,148,149,150,150,150,150,145}),   //hr-h,bp-h,o2-l
        new BpBlock1(new int[]{141,140,138,134,134,134,134,134,134,134,134,134,134,134,134,134,134,134,134,134}),   //probe3
        new BpBlock1(new int[]{135,136,137,141,143,146,147,149,150,151,152,153,154,154,150,145,140,139,138,138}),   //hr-l,bp-h  
        new BpBlock1(new int[]{136,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133}),
        new BpBlock1(new int[]{133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133}),   //probe4
        new BpBlock1(new int[]{133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133,133}),
        new BpBlock1(new int[]{135,136,137,140,145,146,148,149,151,152,153,154,155,155,155,150,146,142,140,140})   //bp-h,o2-l //p2 during p1
        /*new BpBlock1(new int[]{140,140,140,140,143,144,145,146,147,148,149,150,152,154,154,145,137,130,122,114}),   //hr-l,bp-h,o2-l
        new BpBlock1(new int[]{110,108,105,104,99,96,94,92,90,89,87,85,83,81,81,81,81,81,81,81}),                   //bp-l
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //probe5
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81})*/
    };

    public static readonly BpBlock1[] BpDiastolicExperimentBlock1 =
    {
        //new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),   //dummy block
        new BpBlock1(new int[]{75,75,75,75,74,73,75,75,75,75,75,75,75,75,75,75,75,80,81,81}),                       //bp-l
        new BpBlock1(new int[]{85,85,85,85,85,85,85,85,85,83,82,81,81,81,81,81,81,81,81,81}),                       //hr-h,bp-h
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //probe1
        new BpBlock1(new int[]{83,87,88,89,91,92,93,94,95,96,97,95,95,95,90,87,84,83,82,82}),                       //bp-h //high diast
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //probe2
        new BpBlock1(new int[]{81,81,81,80,76,70,69,68,67,66,65,67,69,80,81,81,81,81,81,81}),                       //bp-l,o2-l //low diast
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),    //P2 alarm before P1
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //bp-h
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //hr-h,bp-h,o2-l
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //probe3
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //hr-l,bp-h  
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //probe4
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,82,85,90,91,92,93,95,96,91,85,83,81,81,81,81,81,81,81})                       //bp-h,o2-l //p2 during p1
        /*new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //hr-l,bp-h,o2-l
        new BpBlock1(new int[]{80,78,75,73,70,69,68,67,66,65,64,63,62,65,69,71,75,81,81,81}),                       //bp-l //low dias
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81}),                       //probe5
        new BpBlock1(new int[]{81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81,81})*/
    };

    //patient 1 block2
    /*public static readonly BpBlock1[] BpExperimentBlock1 =
    {
        new BpBlock1(new int[]{110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110,110}),   //dummy block
        new BpBlock1(new int[]{110,110,110,110,110,110,110,110,110,110,110,115,120,125,130,133,135,136,137,137}),
        new BpBlock1(new int[]{137,137,137,137,137,137,141,143,144,145,147,149,150,152,153,156,156,156,156,156}),   //hr-l,bp-h,o2-l
        new BpBlock1(new int[]{150,146,143,143,143,143,143,143,143,143,143,143,143,143,143,143,143,143,143,143}),   //probe1
        new BpBlock1(new int[]{142,140,137,137,137,137,137,137,137,137,137,137,137,137,137,137,137,137,137,137}),
        new BpBlock1(new int[]{137,137,137,137,142,146,149,151,153,155,157,159,161,161,161,161,152,149,145,144}),   //bp-h
        new BpBlock1(new int[]{140,134,132,128,123,119,116,113,111,109,107,104,104,104,104,104,104,104,104,104}),
        new BpBlock1(new int[]{104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104,104}),   //probe2
        new BpBlock1(new int[]{104,104,104,97,95,93,91,89,88,86,84,82,80,80,80,80,80,85,89,90}),                    //bp-l,o2-l
        new BpBlock1(new int[]{93,95,97,98,101,103,105,108,108,108,108,108,108,108,108,108,108,108,108,108}),
        new BpBlock1(new int[]{105,104,103,100,98,96,95,94,92,91,89,88,86,86,86,86,90,99,99,99}),                   //bp-l
        new BpBlock1(new int[]{99,99,99,99,99,99,99,97,96,95,94,93,92,91,90,88,86,86,86,86}),                       //bp-l
        new BpBlock1(new int[]{90,95,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99,99}),  //check!                     //probe3
        new BpBlock1(new int[]{106,111,116,119,121,126,129,133,136,136,136,136,136,136,136,136,136,136,136,136}),
        new BpBlock1(new int[]{136,136,136,140,143,149,151,153,155,157,160,161,163,163,163,163,163,163,163,163}),   //hr-h,bp-h
        new BpBlock1(new int[]{163,163,163,160,155,152,149,145,141,139,138,134,131,126,126,126,126,126,126,126}),
        new BpBlock1(new int[]{126,126,126,126,126,126,126,126,126,126,126,126,126,126,126,126,126,131,133,136}),
        new BpBlock1(new int[]{136,136,136,136,136,136,140,142,144,149,151,153,155,157,160,162,162,162,162,162}),   //hr-h,bp-h,o2-l
        new BpBlock1(new int[]{162,162,162,162,162,162,162,162,162,162,162,162,162,162,162,162,162,162,162,162}),   //probe4
        new BpBlock1(new int[]{163,163,163,160,155,152,149,145,141,139,138,135,135,135,135,135,135,135,135,135}),
        new BpBlock1(new int[]{135,136,137,141,143,146,147,149,150,151,152,153,154,154,150,145,140,139,136,136}),   //bp-h,o2-l
        new BpBlock1(new int[]{136,136,136,136,136,141,143,146,147,149,150,151,152,153,154,154,150,145,140,136}),   //bp-h
        new BpBlock1(new int[]{136,136,136,136,136,140,143,149,151,153,155,157,160,161,163,163,163,163,160,158}),   //hr-l,bp-h
        new BpBlock1(new int[]{158,158,158,158,158,158,158,158,158,158,158,158,158,158,158,158,158,158,158,158}),   //probe5
    };*/


}
