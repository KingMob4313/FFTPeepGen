using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTCharacterGenerator
{
    public class FFTCharacter
    {
        public string strSex = "3005xx78 00m0";
        public string strBrave = "3005xx8B 00mn";
        public string strFaith = "3005xx8C 00mn";
        public string strHPMid = "3005xx8E 00n0";
        public string strHPHigh = "3005xx8F 000m";
        public string strMPMid = "3005xx91 00n0";
        public string strMPHigh = "3005xx92 000m";
        public string strSpdMid = "3005xx94 00n0";
        public string strSpdHigh = "3005xx95 000m";
        public string strPAMid = "3005xx97 00n0";
        public string strPAHigh = "3005xx98 000m";
        public string strMAMid = "3005xx9A 00n0";
        public string strMAHigh = "3005xx9B 000m";

        public virtual void SetCharacterStats<FFTCharacter>()
        {
        }

        public void ResetStrings()
        {
            strSex = "3005xx78 00m0";
            strBrave = "3005xx8B 00mn";
            strFaith = "3005xx8C 00mn";
            strHPMid = "3005xx8E 00n0";
            strHPHigh = "3005xx8F 000m";
            strMPMid = "3005xx91 00n0";
            strMPHigh = "3005xx92 000m";
            strSpdMid = "3005xx94 00n0";
            strSpdHigh = "3005xx95 000m";
            strPAMid = "3005xx97 00n0";
            strPAHigh = "3005xx98 000m";
            strMAMid = "3005xx9A 00n0";
            strMAHigh = "3005xx9B 000m";
        }
    }
}