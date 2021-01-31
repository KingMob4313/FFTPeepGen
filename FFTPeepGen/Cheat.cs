using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFTCharacterGenerator
{
    public partial class Cheat : Form
    {
        private DataSet dsNames = new DataSet();
        private StringBuilder stbCheatFile = new StringBuilder();
        private DataTable dtCBOValues = new DataTable();
        private Dictionary<int, string> dctCBOPeeps = new Dictionary<int, string>();
        private string strFilePath = string.Empty;

        public Cheat()
        {
            InitializeComponent();
        }

        private DataTable ReadXMLtoDatatable(DataSet dsDataset)
        {
            DataTable dtNames;
            dsNames.ReadXml("Properties/NameList.xml");
            dtNames = dsDataset.Tables[0];
            return dtNames;
        }

        private void Cheat_Load(object sender, EventArgs e)
        {
            DataTable dtNamo;
            dtNamo = ReadXMLtoDatatable(dsNames);
            BindCbos(dtNamo);
        }

        private void BindCbos(DataTable dtSource)
        {
            cboTwo.BindingContext = new BindingContext();
            cboTwo.DataSource = dtSource;
            cboTwo.DisplayMember = "name_Text";

            cboThree.BindingContext = new BindingContext();
            cboThree.DataSource = dtSource;
            cboThree.DisplayMember = "name_Text";
            cboThree.SelectedIndex = 1;

            cboFour.BindingContext = new BindingContext();
            cboFour.DataSource = dtSource;
            cboFour.DisplayMember = "name_Text";
            cboFour.SelectedIndex = 2;

            cboFive.BindingContext = new BindingContext();
            cboFive.DataSource = dtSource;
            cboFive.DisplayMember = "name_Text";
            cboFive.SelectedIndex = 3;

            cboSix.BindingContext = new BindingContext();
            cboSix.DataSource = dtSource;
            cboSix.DisplayMember = "name_Text";
            cboSix.SelectedIndex = 4;

            cboSeven.BindingContext = new BindingContext();
            cboSeven.DataSource = dtSource;
            cboSeven.DisplayMember = "name_Text";
            cboSeven.SelectedIndex = 5;

            cboEight.BindingContext = new BindingContext();
            cboEight.DataSource = dtSource;
            cboEight.DisplayMember = "name_Text";
            cboEight.SelectedIndex = 6;

            cboNine.BindingContext = new BindingContext();
            cboNine.DataSource = dtSource;
            cboNine.DisplayMember = "name_Text";
            cboNine.SelectedIndex = 7;

            cboTen.BindingContext = new BindingContext();
            cboTen.DataSource = dtSource;
            cboTen.DisplayMember = "name_Text";
            cboTen.SelectedIndex = 8;

            cboEleven.BindingContext = new BindingContext();
            cboEleven.DataSource = dtSource;
            cboEleven.DisplayMember = "name_Text";
            cboEleven.SelectedIndex = 9;

            cboTwelve.BindingContext = new BindingContext();
            cboTwelve.DataSource = dtSource;
            cboTwelve.DisplayMember = "name_Text";
            cboTwelve.SelectedIndex = 10;

            cboThirteen.BindingContext = new BindingContext();
            cboThirteen.DataSource = dtSource;
            cboThirteen.DisplayMember = "name_Text";
            cboThirteen.SelectedIndex = 11;

            cboFourteen.BindingContext = new BindingContext();
            cboFourteen.DataSource = dtSource;
            cboFourteen.DisplayMember = "name_Text";
            cboFourteen.SelectedIndex = 12;

            cboFifteen.BindingContext = new BindingContext();
            cboFifteen.DataSource = dtSource;
            cboFifteen.DisplayMember = "name_Text";
            cboFifteen.SelectedIndex = 13;

            cboSixteen.BindingContext = new BindingContext();
            cboSixteen.DataSource = dtSource;
            cboSixteen.DisplayMember = "name_Text";
            cboSixteen.SelectedIndex = 14;
        }

        /// <summary>
        /// This grabs the name values in the CBOs and crams them into the datatable to return back for other methods
        /// </summary>
        /// <returns></returns>
        private bool GetCBOValues()
        {
            bool blnValidCBO = false;
            dctCBOPeeps.Clear();
            if (dctCBOPeeps.Count < 1)
            {
                //foreach (KeyValuePair<int, string> entry in dctCBOPeeps)
                //{

                //}
                dctCBOPeeps.Add(2, cboTwo.Text.ToString());
                dctCBOPeeps.Add(3, cboThree.Text.ToString());
                dctCBOPeeps.Add(4, cboFour.Text.ToString());
                dctCBOPeeps.Add(5, cboFive.Text.ToString());
                dctCBOPeeps.Add(6, cboSix.Text.ToString());
                dctCBOPeeps.Add(7, cboSeven.Text.ToString());
                dctCBOPeeps.Add(8, cboEight.Text.ToString());
                dctCBOPeeps.Add(9, cboNine.Text.ToString());
                dctCBOPeeps.Add(10, cboTen.Text.ToString());
                dctCBOPeeps.Add(11, cboEleven.Text.ToString());
                dctCBOPeeps.Add(12, cboTwelve.Text.ToString());
                dctCBOPeeps.Add(13, cboThirteen.Text.ToString());
                dctCBOPeeps.Add(14, cboFourteen.Text.ToString());
                dctCBOPeeps.Add(15, cboFifteen.Text.ToString());
                dctCBOPeeps.Add(16, cboSixteen.Text.ToString());
            }

            var uniqueValues = dctCBOPeeps.GroupBy(pair => pair.Value)
                         .Select(group => group.First())
                         .ToDictionary(pair => pair.Key, pair => pair.Value);
            if (uniqueValues.Count < 15)
            {
                blnValidCBO = false;
                string strDupeCount = (16 - uniqueValues.Count).ToString();
                MessageBox.Show("Please check entry, " + strDupeCount + " duplicates detected.", "Error - Cheats not generated.");
            }
            else
            {
                blnValidCBO = true;
            }
            return blnValidCBO;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Generating File";
            bool blnValid = GetCBOValues();
            //CheckControls();
            //blnValid = CheckForDupes();
            stbCheatFile.Remove(0, stbCheatFile.Length);
            int intCounter = 0;
            if (blnValid)
            {
                //Generate codes for selected checkboxes
                if (chkJobPtsLock.Checked)
                {
                    stbCheatFile.Append("#Job Points Never Decrease\r\n");
                    stbCheatFile.Append("D004760C 0001\r\n");
                    stbCheatFile.Append("8011FAD4 0000\r\n");
                }
                if (chkMaxCash.Checked)
                {
                    stbCheatFile.Append("#Maximum Gil-Cash\r\n");
                    stbCheatFile.Append("8005483C E0FF\r\n");
                    stbCheatFile.Append("8005483E 05F5\r\n");
                    //8005483C E0FF
                    //8005483E 05F5
                    //800577CE 0FFF
                    //800577CC FFFF
                }
                if (chkMaxJobPts.Checked)
                {
                    stbCheatFile.Append("#Max Job Points with every Action\r\n");
                    stbCheatFile.Append("8017CB20 0100\r\n");
                    stbCheatFile.Append("8017CB22 2443\r\n");
                    stbCheatFile.Append("8017CB3C 0100\r\n");
                    stbCheatFile.Append("8017CB3E 2443\r\n");
                    stbCheatFile.Append("8017EB54 0100\r\n");
                    stbCheatFile.Append("8017EB56 2443\r\n");
                    stbCheatFile.Append("8017EB70 0100\r\n");
                    stbCheatFile.Append("8017EB72 2443\r\n");
                }
                if (chkAutoLvl.Checked)
                {
                    stbCheatFile.Append("#One Action per Character Lvl\r\n");
                    stbCheatFile.Append("801924EC 63FF\r\n");
                    stbCheatFile.Append("801926AC 63FF\r\n");
                    stbCheatFile.Append("8019286C 63FF\r\n");
                    stbCheatFile.Append("80192A2C 63FF\r\n");
                    stbCheatFile.Append("80192BEC 63FF\r\n");
                }
                //if (rdoOnePerLvl.Checked)
                //{
                //    stbCheatFile.Append("#One Action per Character Lvl\r\n");
                //    stbCheatFile.Append("801924EC 63FF\r\n");
                //    stbCheatFile.Append("801926AC 63FF\r\n");
                //    stbCheatFile.Append("8019286C 63FF\r\n");
                //    stbCheatFile.Append("80192A2C 63FF\r\n");
                //    stbCheatFile.Append("80192BEC 63FF\r\n");
                //}
                //if (rdoTwoPerLvl.Checked)
                //{
                //    stbCheatFile.Append("#Two Actions per Character Lvl\r\n");
                //    stbCheatFile.Append("801924EC 0032\r\n");
                //    stbCheatFile.Append("801926AC 0032\r\n");
                //    stbCheatFile.Append("8019286C 0032\r\n");
                //    stbCheatFile.Append("80192A2C 0032\r\n");
                //    stbCheatFile.Append("80192BEC 0032\r\n");
                //}
                //if (rdoThreePerLvl.Checked)
                //{
                //    stbCheatFile.Append("#Three Actions per Character Lvl\r\n");
                //    stbCheatFile.Append("801924EC 0021\r\n");
                //    stbCheatFile.Append("801926AC 0021\r\n");
                //    stbCheatFile.Append("8019286C 0021\r\n");
                //    stbCheatFile.Append("80192A2C 0021\r\n");
                //    stbCheatFile.Append("80192BEC 0021\r\n");
                //}
                //if (rdoFourPerLvl.Checked)
                //{
                //    stbCheatFile.Append("#Four Actions per Character Lvl\r\n");
                //    stbCheatFile.Append("801924EC 0019\r\n");
                //    stbCheatFile.Append("801926AC 0019\r\n");
                //    stbCheatFile.Append("8019286C 0019\r\n");
                //    stbCheatFile.Append("80192A2C 0019\r\n");
                //    stbCheatFile.Append("80192BEC 0019\r\n");
                //}
                //Generate codes for all Peeps
                intCounter = PeepCodes(intCounter);
                if (intCounter < 14)
                {
                    MessageBox.Show("Internal Error. Fred is an idiot.");
                }
                else
                {
                    //Placefilewriter here
                    if (txtPath.Text != string.Empty)
                    {
                        strFilePath = txtPath.Text;
                        using (StreamWriter objFileOut = new StreamWriter(strFilePath + @"\\SCUS_942.21.txt"))
                        {
                            objFileOut.Write(stbCheatFile.ToString());
                            MessageBox.Show("Please Load the game in ESPXE. Then hit the ESC key.\rOptions > Cheat Codes. Hit the 'Enable All' button then 'Ok'.\rThen Run > Continue.", "Cheat File Created.");
                            this.toolStripStatusLabel1.Text = "File Generated.";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a path before generating.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Check Selected People");
            }
        }

        private int PeepCodes(int intCounter)
        {
            for (int i = 2; i <= 16; i++)
            {
                FFTCharacter recruit = new FFTCharacter();
                //bach.ResetStrings();
                string tempName = "CatNoir";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    string strLoc = string.Empty;

                    //good
                    recruit = FillRecruitStats(tempName, "32", "50", "0B0", "178", "198", "180", "238");
                    recruit.strSex = recruit.strSex.Replace("m", "4");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                    //dctCBOPeeps.Remove(i);
                }
                tempName = "Fred";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    string strLoc = string.Empty;

                    //good
                    recruit = FillRecruitStats(tempName, "41", "32", "0D8", "0B0", "1F8", "1B0", "198");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Jamie";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Hendo";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    string strLoc = string.Empty;

                    //Good
                    recruit = FillRecruitStats(tempName, "46", "23", "130", "0B0", "1B0", "1C8", "1C8");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Justin";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    string strLoc = string.Empty;

                    //Good
                    recruit = FillRecruitStats(tempName, "37", "28", "170", "090", "198", "1F8", "1B0");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Sobjack";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Huntress";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //GOOD
                    recruit = FillRecruitStats(tempName, "46", "32", "0B0", "130", "1C8", "198", "1F8");
                    recruit.strSex = recruit.strSex.Replace("m", "4");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Ina";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Kouri";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Shane";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Drew";
                if (dctCBOPeeps[i].Contains(tempName))
                {

                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Chuck";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "55", "46", "090", "0F0", "1E0", "198", "1B0");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Hippie";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "46", "37", "0D0", "0F0", "1C8", "1B0", "1C8");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Eric";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Ambrozy";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Marz";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Irwin";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                if (dctCBOPeeps[i].Contains("Billy"))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                if (dctCBOPeeps[i].Contains("Bersche"))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Brandon";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "32", "32", "150", "0D0", "1B0", "1E0", "198");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                if (dctCBOPeeps[i].Contains("Tom"))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Inertia";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "46", "50", "0B0", "0D0", "1C8", "180", "230");
                    recruit.strSex = recruit.strSex.Replace("m", "4");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Thieme";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //GOOD
                    recruit = FillRecruitStats(tempName, "37", "37", "150", "0F0", "198", "1C8", "1C8");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Constant";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //NO GOOD
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Satan";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //GOOD
                    recruit = FillRecruitStats(tempName, "41", "41", "0D0", "0D0", "1E0", "168", "1C8");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                if (dctCBOPeeps[i].Contains("Jon"))
                {
                    //No Good
                    recruit.strSex = recruit.strSex.Replace("m", "8");
                    recruit = FillRecruitStats(tempName, "00", "00", "000", "000", "000", "000", "000");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Liam";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "55", "19", "130", "050", "218", "1E0", "150");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Fallout";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "46", "19", "0F0", "050", "230", "1C8", "150");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Chappy";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "50", "37", "130", "110", "180", "1C8", "1C8");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
                tempName = "Stench";
                if (dctCBOPeeps[i].Contains(tempName))
                {
                    //Good
                    recruit = FillRecruitStats(tempName, "50", "37", "130", "110", "180", "1C8", "1C8");
                    recruit.strSex = recruit.strSex.Replace("m", "8");

                    intCounter++;
                    Append_CheatFile(i, recruit);
                }
            }
            return intCounter;
        }

        private FFTCharacter FillRecruitStats(string name, string braveStat, string faithStat, string hpStat, string mpStat, string speedStat, string physAttackStat, string magicAttackStat)
        {
            FFTCharacter currentCharacter = new FFTCharacter();
            if (CheckStatStrings(braveStat, faithStat, hpStat, mpStat, speedStat, physAttackStat, magicAttackStat))
            {

                currentCharacter.strName = currentCharacter.strName.Replace("Nullo", name);
                currentCharacter.strBrave = currentCharacter.strBrave.Replace("xy", braveStat);
                currentCharacter.strFaith = currentCharacter.strFaith.Replace("xy", faithStat);

                //This is not consistent, it's just a temporary Hack
                //Need to hack back in Mid and a new LOW stat.

                //HP & MP work XY Z
                currentCharacter.strHPHigh = currentCharacter.strHPHigh.Replace("x", hpStat.Substring(0, 1));
                currentCharacter.strHPHigh = currentCharacter.strHPHigh.Replace("y", hpStat.Substring(1, 1));
                currentCharacter.strHPLow = currentCharacter.strHPLow.Replace("z", hpStat.Substring(2, 1));

                currentCharacter.strMPHigh = currentCharacter.strMPHigh.Replace("x", mpStat.Substring(0, 1));
                currentCharacter.strMPHigh = currentCharacter.strMPHigh.Replace("y", mpStat.Substring(1, 1));
                currentCharacter.strMPLow = currentCharacter.strMPLow.Replace("z", mpStat.Substring(2, 1));

                //Speed & Attacks work X YZ
                currentCharacter.strSpdHigh = currentCharacter.strSpdHigh.Replace("x", speedStat.Substring(0, 1));
                currentCharacter.strSpdLow = currentCharacter.strSpdLow.Replace("y", speedStat.Substring(1, 1));
                currentCharacter.strSpdLow = currentCharacter.strSpdLow.Replace("z", speedStat.Substring(2, 1));

                currentCharacter.strPAHigh = currentCharacter.strPAHigh.Replace("x", physAttackStat.Substring(0, 1));
                currentCharacter.strPALow = currentCharacter.strPALow.Replace("y", physAttackStat.Substring(1, 1));
                currentCharacter.strPALow = currentCharacter.strPALow.Replace("z", physAttackStat.Substring(2, 1));

                currentCharacter.strMAHigh = currentCharacter.strMAHigh.Replace("x", magicAttackStat.Substring(0, 1));
                currentCharacter.strMALow = currentCharacter.strMALow.Replace("y", magicAttackStat.Substring(1, 1));
                currentCharacter.strMALow = currentCharacter.strMALow.Replace("z", magicAttackStat.Substring(2, 1));
            }

            return currentCharacter;
        }

        private bool CheckStatStrings(string braveStat, string faithStat, string hpStat, string mpStat, string speedStat, string physAttackStat, string magicAttackStat)
        {
            if(braveStat.Length < 2)
            {
                return false;
            }
            if (faithStat.Length < 2)
            {
                return false;
            }
            return true;
        }


        private static string SetHexPosition(int i)
        {
            string strLoc = "0";
            if (i == 2)
            {
                strLoc = "80";
            }
            if (i == 3)
            {
                strLoc = "81";
            }
            if (i == 4)
            {
                strLoc = "82";
            }
            if (i == 5)
            {
                strLoc = "83";
            }
            if (i == 6)
            {
                strLoc = "84";
            }
            if (i == 7)
            {
                strLoc = "85";
            }
            if (i == 8)
            {
                strLoc = "86";
            }
            if (i == 9)
            {
                strLoc = "87";
            }
            if (i == 10)
            {
                strLoc = "88";
            }
            if (i == 11)
            {
                strLoc = "89";
            }
            if (i == 12)
            {
                strLoc = "8A";
            }
            if (i == 13)
            {
                strLoc = "8B";
            }
            if (i == 14)
            {
                strLoc = "8C";
            }
            if (i == 15)
            {
                strLoc = "8D";
            }
            if (i == 16)
            {
                strLoc = "8E";
            }
            return strLoc;
        }

        private void Append_CheatFile(int characterIndex, FFTCharacter recruit)
        {
            //stbCheatFile.Append(recruit.strSex + "\r\n
            string strLoc = SetHexPosition(characterIndex);

            stbCheatFile.Append(" \r\n");
            stbCheatFile.Append("# " + recruit.strName + " No:" + characterIndex.ToString("D4") + "\r\n");
            stbCheatFile.Append(recruit.strBrave + "\r\n");
            stbCheatFile.Append(recruit.strFaith + "\r\n");
            stbCheatFile.Append(recruit.strHPLow + "\r\n");
            stbCheatFile.Append(recruit.strHPHigh + "\r\n");
            stbCheatFile.Append(recruit.strMPLow + "\r\n");
            stbCheatFile.Append(recruit.strMPHigh + "\r\n");
            stbCheatFile.Append(recruit.strSpdLow + "\r\n");
            stbCheatFile.Append(recruit.strSpdHigh + "\r\n");
            stbCheatFile.Append(recruit.strPALow + "\r\n");
            stbCheatFile.Append(recruit.strPAHigh + "\r\n");
            stbCheatFile.Append(recruit.strMALow + "\r\n");
            stbCheatFile.Append(recruit.strMAHigh + "\r\n");
            stbCheatFile.Replace("qq", strLoc);
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strFilePath = txtPath.Text = folderBrowserDialog1.SelectedPath;
                if (!txtPath.Text.Contains("\\epsxe\\cheats"))
                {
                    MessageBox.Show("The path may not be correct. Please select the EPSXE cheat folder.");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        //private bool CheckForDupes()
        //{
        //    bool blnDupes = false;
        //    blnDupes =
        //    return !blnDupes;
        //}

        //private bool CheckControls()
        //{
        //    bool blnControlsValid = false;
        //    blnControlsValid = ;
        //    return blnControlsValid;
        //}
    }
}