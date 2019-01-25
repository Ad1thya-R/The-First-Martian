using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public static class State
{
    public static bool musicIsPlaying = true;
    public static int noOfAstronauts = 1;
    public static int costToHire = 700000;
    public static int money = 5000000;

    public static bool playerDidWin;
    public static int investmentCost;
    public static int returnCost;

    public static bool instructionsArePlaying;

    public static bool disableSkip;

    public static bool showHowMuchMoneyPlayerMade = false;


    public static string line1 = "markwatney$ Establishing connection to Earth...";
    public static string line2 = "\nmarkwatney$ Signal strength: 100%";
    public static string line3 = "\nmarkwatney$ Hi! I’m Matt.";
    public static string line4 = "\nmarkwatney$ I am the first human to have set foot on Mars.";
    public static string line5 = "\nmarkwatney$ I run a company back on Earth called The First Martian Inc.";
    public static string line6 = "\nmarkwatney$ Space seems very profitable and we intend to make a fortune out of it.";
    public static string line7 = "\nmarkwatney$ Assist me in landing my rocket securely and keep my crew safe from the dangerous Martian environment.";
    public static string line8 = "\nmarkwatney$ However, completing this task successfully will not be easy.";
    public static string line9 = "\nmarkwatney$ Obstacles such as Martian rocks and fuel shortages stand in your way in the path to success.";
    public static string line10 = "\nmarkwatney$ If you decide to hire many astronauts, you will produce larger profits.";
    public static string line11 = "\nmarkwatney$ Press W or Spacebar for upward thrust. And A and D for tilting it left and right respectively.";
    public static string line12 = "\nmarkwatney$ Good luck on your mission, fellow Martian!";
    public static string line13 = "\n \nPress Enter to continue...";
    
    public static string[] instructions =
    {
       line1,
       line1 + line2,
       line1 + line2 + line3,
       line1 + line2 + line3 + line4,
       line1 + line2 + line3 + line4 + line5,
       line1 + line2 + line3 + line4 + line5 + line6,
       line1 + line2 + line3 + line4 + line5 + line6 + line7,
       line1 + line2 + line3 + line4 + line5 + line6 + line7 + line8,
       line1 + line2 + line3 + line4 + line5 + line6 + line7 + line8 + line9,
       line1 + line2 + line3 + line4 + line5 + line6 + line7 + line8 + line9 + line10,
       line1 + line2 + line3 + line4 + line5 + line6 + line7 + line8 + line9 + line10 + line11,
       line1 + line2 + line3 + line4 + line5 + line6 + line7 + line8 + line9 + line10 + line11 + line12,
       line1 + line2 + line3 + line4 + line5 + line6 + line7 + line8 + line9 + line10 + line11 + line12 + line13
    };

}
