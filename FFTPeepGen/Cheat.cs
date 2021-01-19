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
            dsNames.ReadXml("NameList.xml");
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
                if (intCounter < 15)
                {
                    MessageBox.Show("Internal Error. Fred is an idiot.");
                }
                {
                    //Placefilewriter here
                    if (txtPath.Text != string.Empty)
                    {
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
            stbCheatFile.Append("#Peeps " + DateTime.Now.Month + "\r\n");
            for (int i = 2; i <= 16; i++)
            {
                FFTCharacter recruit = new FFTCharacter();
                //bach.ResetStrings();
                if (dctCBOPeeps[i].Contains("CatNoir"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "3C");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "50");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "E");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "4");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "8");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "7");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "E");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "0");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "E");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                    //dctCBOPeeps.Remove(i);
                }
                if (dctCBOPeeps[i].Contains("Fred"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "37");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "E");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "1");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "0");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "2");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Jamie"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "32");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "46");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "6");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "4");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Hendo"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "37");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "3C");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "6");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "4");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "6");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Justin"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "28");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "2");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "B");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "A");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "0");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "4");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "C");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "0");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Sobjack"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "50");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "2D");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "2");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "8");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "2");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Huntress"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "4");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "28");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "50");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "2");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "6");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "A");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "5");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "2");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "A");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Ina"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "4");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "2D");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "4B");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "C");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "6");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "4");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "6");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "2");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "A");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Kouri"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "28");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "8");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "A");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "A");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "0");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "6");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "2");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Shane"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "41");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "32");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Drew"))
                {
                    string strLoc = string.Empty;

                    //strSex = strSex.Replace("m", "8");
                    strLoc = SetHexPosition(i, strLoc);

                    recruit.strBrave = recruit.strBrave.Replace("mn", "2D");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "4B");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "8");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "5");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "8");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "0");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "C");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Chzuck"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "50");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "3C");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "2");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "6");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "A");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "5");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "2");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "6");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Brian"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "3C");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "41");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Eric"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "28");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "0");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "2");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Ambrozy"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "55");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "23");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "8");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "2");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "0");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "2");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "6");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "2");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Marz"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "50");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "2D");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "2");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "B");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "A");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "0");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "0");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "A");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "2");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Irwin"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "3C");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "4");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "9");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "4");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "1");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "0");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "2");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "6");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "E");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "0");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Billy"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "46");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "2");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Bersche"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "50");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "41");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "4");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "9");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "8");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "2");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "0");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Brandon"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "41");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "3C");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "E");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "1");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Tom"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "55");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "2D");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Telka"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "4");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "37");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "41");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "8");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "5");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "E");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "6");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "2");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "A");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Thieme"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "37");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "41");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "6");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "4");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "4");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "8");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Parks"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "4B");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "28");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "4");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "9");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "4");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "6");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "6");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Satan"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "41");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "32");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "C");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "3");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "C");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Jon"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "3C");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "41");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "A");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "6");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "4");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "8");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "4");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }

                if (dctCBOPeeps[i].Contains("JoeV"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "46");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "28");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "8");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "A");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "A");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "0");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "4");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "1");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "C");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "0");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Liam"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "55");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "32");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "0");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "4");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "5");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "2");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "6");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "0");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
                if (dctCBOPeeps[i].Contains("Fallout"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    recruit.strBrave = recruit.strBrave.Replace("mn", "50");
                    recruit.strFaith = recruit.strFaith.Replace("mn", "32");
                    recruit.strHPMid = recruit.strHPMid.Replace("n", "0");
                    recruit.strHPHigh = recruit.strHPHigh.Replace("m", "8");
                    recruit.strMPMid = recruit.strMPMid.Replace("n", "0");
                    recruit.strMPHigh = recruit.strMPHigh.Replace("m", "4");
                    recruit.strSpdMid = recruit.strSpdMid.Replace("n", "A");
                    recruit.strSpdHigh = recruit.strSpdHigh.Replace("m", "2");
                    recruit.strPAMid = recruit.strPAMid.Replace("n", "4");
                    recruit.strPAHigh = recruit.strPAHigh.Replace("m", "1");
                    recruit.strMAMid = recruit.strMAMid.Replace("n", "0");
                    recruit.strMAHigh = recruit.strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc, recruit);
                }
            }
            return intCounter;
        }

        private FFTCharacter FillRecruitStats(string name, string braveStat, string faithStat, string HPMidBits, string HPHighBits, string MPMidBits, string MPHighBits, string speedMidBits, string speedHighBits, string physAttackMidBits, string physAttackHighBits, string magicAttackMidBits, string magicAttackHighBits)
        {
            FFTCharacter currentCharacter = new FFTCharacter();

            currentCharacter.strName = currentCharacter.strBrave.Replace("Nullo", name);
            currentCharacter.strBrave = currentCharacter.strBrave.Replace("mn", braveStat);
            currentCharacter.strFaith = currentCharacter.strFaith.Replace("mn", faithStat);
            currentCharacter.strHPMid = currentCharacter.strHPMid.Replace("n", HPMidBits);
            currentCharacter.strHPHigh = currentCharacter.strHPHigh.Replace("m", HPHighBits);
            currentCharacter.strMPMid = currentCharacter.strMPMid.Replace("n", MPMidBits);
            currentCharacter.strMPHigh = currentCharacter.strMPHigh.Replace("m", MPHighBits);
            currentCharacter.strSpdMid = currentCharacter.strSpdMid.Replace("n", speedMidBits);
            currentCharacter.strSpdHigh = currentCharacter.strSpdHigh.Replace("m", speedHighBits);
            currentCharacter.strPAMid = currentCharacter.strPAMid.Replace("n", physAttackMidBits);
            currentCharacter.strPAHigh = currentCharacter.strPAHigh.Replace("m", physAttackHighBits);
            currentCharacter.strMAMid = currentCharacter.strMAMid.Replace("n", magicAttackMidBits);
            currentCharacter.strMAHigh = currentCharacter.strMAHigh.Replace("m", magicAttackHighBits);

            return currentCharacter;
        }

        private static string SetHexPosition(int i, string strLoc)
        {
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

        private void Append_stb(string strLoc, FFTCharacter recruit)
        {
            stbCheatFile.Append(recruit.strSex + "\r\n");
            stbCheatFile.Append(recruit.strBrave + "\r\n");
            stbCheatFile.Append(recruit.strFaith + "\r\n");
            stbCheatFile.Append(recruit.strHPMid + "\r\n");
            stbCheatFile.Append(recruit.strHPHigh + "\r\n");
            stbCheatFile.Append(recruit.strMPMid + "\r\n");
            stbCheatFile.Append(recruit.strSpdHigh + "\r\n");
            stbCheatFile.Append(recruit.strSpdMid + "\r\n");
            stbCheatFile.Append(recruit.strMPHigh + "\r\n");
            stbCheatFile.Append(recruit.strPAMid + "\r\n");
            stbCheatFile.Append(recruit.strPAHigh + "\r\n");
            stbCheatFile.Append(recruit.strMAMid + "\r\n");
            stbCheatFile.Append(recruit.strMAHigh + "\r\n");
            stbCheatFile.Replace("xx", strLoc);
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