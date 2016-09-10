using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTCharacterGenerator
{
    public class Bach : FFTCharacter
    {
        public override void SetCharacterStats<FFTCharacter>()
        {
            ChangeStats();
        }

        public void ChangeStats()
        {
            strBrave = strBrave.Replace("mn", "3C");
            strFaith = strFaith.Replace("mn", "50");
            strHPMid = strHPMid.Replace("n", "E");
            strHPHigh = strHPHigh.Replace("m", "4");
            strMPMid = strMPMid.Replace("n", "8");
            strMPHigh = strMPHigh.Replace("m", "7");
            strSpdMid = strSpdMid.Replace("n", "8");
            strSpdHigh = strSpdHigh.Replace("m", "1");
            strPAMid = strPAMid.Replace("n", "E");
            strPAHigh = strPAHigh.Replace("m", "0");
            strMAMid = strMAMid.Replace("n", "E");
            strMAHigh = strMAHigh.Replace("m", "1");
        }
    }
}