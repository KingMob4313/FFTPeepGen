namespace FFTCharacterGenerator
{
    public class FFTCharacter
    {
        //Is it 300 or 800?
        private static string codePrefix = "300";
        
        //https://www.almarsguides.com/retro/walkthroughs/PS1/Games/FinalFantasyTactics/Gameshark/
        public string strName = "Nullo";
        public string strSex = codePrefix + "5qq78 00x0";
        public string strBrave = codePrefix + "5qq8B 00xy";
        public string strFaith = codePrefix + "5qq8C 00xy";
        public string strHPLow = codePrefix + "5qq8E z000";
        public string strHPHigh = codePrefix + "5qq8F 00xy";
        public string strMPLow = codePrefix + "5qq91 z000";
        public string strMPHigh = codePrefix + "5qq92 00xy";
        public string strSpdLow = codePrefix + "5qq94 00yz";
        public string strSpdHigh = codePrefix + "5qq95 000x";
        public string strPALow = codePrefix + "5qq97 00yz";
        public string strPAHigh = codePrefix + "5qq98 000x";
        public string strMALow = codePrefix + "5qq9A 00yz";
        public string strMAHigh = codePrefix + "5qq9B 000x";

        public virtual void SetCharacterStats<FFTCharacter>()
        {
        }

        public void ResetStrings()
        {
            strName = "Nullo";
            strSex = codePrefix + "5qq78 00x0";
            strBrave = codePrefix + "5qq8B 00xy";
            strFaith = codePrefix + "5qq8C 00xy";
            strHPLow = codePrefix + "5qq8E z000";
            strHPHigh = codePrefix + "5qq8F 00xy";
            strMPLow = codePrefix + "5qq91 z000";
            strMPHigh = codePrefix + "5qq92 00xy";
            strSpdLow = codePrefix + "5qq94 00yz";
            strSpdHigh = codePrefix + "5qq95 000x";
            strPALow = codePrefix + "5qq97 00yz";
            strPAHigh = codePrefix + "5qq98 000x";
            strMALow = codePrefix + "5qq9A 00yz";
            strMAHigh = codePrefix + "5qq9B 000x";
        }
    }

}