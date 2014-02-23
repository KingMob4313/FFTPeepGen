using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Cheat : Form
    {
        private string strSex = "3005xx78 00m0";
        private string strBrave = "3005xx8B 00mn";
        private string strFaith = "3005xx8C 00mn";
        private string strHPMid = "3005xx8E 00n0";
        private string strHPHigh = "3005xx8F 000m";
        private string strMPMid = "3005xx91 00n0";
        private string strMPHigh = "3005xx92 000m";
        private string strSpdMid = "3005xx94 00n0";
        private string strSpdHigh = "3005xx95 000m";
        private string strPAMid = "3005xx97 00n0";
        private string strPAHigh = "3005xx98 000m";
        private string strMAMid = "3005xx9A 00n0";
        private string strMAHigh = "3005xx9B 000m";
        private DataSet dsNames = new DataSet();
        private StringBuilder stbCheatFile = new StringBuilder();
        private DataTable dtCBOValues = new DataTable();
        Dictionary<int, string> dctCBOPeeps = new Dictionary<int, string>();
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

        private void ResetStrings()
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
                ResetStrings();
                if (dctCBOPeeps[i].Contains("Bach"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
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
                    intCounter++;
                    Append_stb(strLoc);
                    //dctCBOPeeps.Remove(i);
                }
                if (dctCBOPeeps[i].Contains("Fred"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "46");
                    strFaith = strFaith.Replace("mn", "37");
                    strHPMid = strHPMid.Replace("n", "0");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "E");
                    strMPHigh = strMPHigh.Replace("m", "1");
                    strSpdMid = strSpdMid.Replace("n", "0");
                    strSpdHigh = strSpdHigh.Replace("m", "2");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Jamie"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "32");
                    strFaith = strFaith.Replace("mn", "46");
                    strHPMid = strHPMid.Replace("n", "0");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "6");
                    strMPHigh = strMPHigh.Replace("m", "4");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Hendo"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "37");
                    strFaith = strFaith.Replace("mn", "3C");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "6");
                    strMPHigh = strMPHigh.Replace("m", "4");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "6");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Justin"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "46");
                    strFaith = strFaith.Replace("mn", "28");
                    strHPMid = strHPMid.Replace("n", "2");
                    strHPHigh = strHPHigh.Replace("m", "B");
                    strMPMid = strMPMid.Replace("n", "A");
                    strMPHigh = strMPHigh.Replace("m", "0");
                    strSpdMid = strSpdMid.Replace("n", "4");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "C");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "0");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Sobjack"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "50");
                    strFaith = strFaith.Replace("mn", "2D");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "2");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "8");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "2");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Celine"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "4");
                    strBrave = strBrave.Replace("mn", "28");
                    strFaith = strFaith.Replace("mn", "50");
                    strHPMid = strHPMid.Replace("n", "2");
                    strHPHigh = strHPHigh.Replace("m", "6");
                    strMPMid = strMPMid.Replace("n", "A");
                    strMPHigh = strMPHigh.Replace("m", "5");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "2");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "A");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Ina"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "4");
                    strBrave = strBrave.Replace("mn", "2D");
                    strFaith = strFaith.Replace("mn", "4B");
                    strHPMid = strHPMid.Replace("n", "C");
                    strHPHigh = strHPHigh.Replace("m", "6");
                    strMPMid = strMPMid.Replace("n", "4");
                    strMPHigh = strMPHigh.Replace("m", "6");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "2");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "A");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Kouri"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "46");
                    strFaith = strFaith.Replace("mn", "28");
                    strHPMid = strHPMid.Replace("n", "8");
                    strHPHigh = strHPHigh.Replace("m", "A");
                    strMPMid = strMPMid.Replace("n", "A");
                    strMPHigh = strMPHigh.Replace("m", "0");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "6");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "2");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Shane"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "41");
                    strFaith = strFaith.Replace("mn", "32");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Drew"))
                {
                    string strLoc = string.Empty;

                    //strSex = strSex.Replace("m", "8");
                    strLoc = SetHexPosition(i, strLoc);

                    strBrave = strBrave.Replace("mn", "2D");
                    strFaith = strFaith.Replace("mn", "4B");
                    strHPMid = strHPMid.Replace("n", "8");
                    strHPHigh = strHPHigh.Replace("m", "5");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "8");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "0");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "C");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Chzuck"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "50");
                    strFaith = strFaith.Replace("mn", "3C");
                    strHPMid = strHPMid.Replace("n", "2");
                    strHPHigh = strHPHigh.Replace("m", "6");
                    strMPMid = strMPMid.Replace("n", "A");
                    strMPHigh = strMPHigh.Replace("m", "5");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "2");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "6");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Brian"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "3C");
                    strFaith = strFaith.Replace("mn", "41");
                    strHPMid = strHPMid.Replace("n", "0");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Eric"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "46");
                    strFaith = strFaith.Replace("mn", "28");
                    strHPMid = strHPMid.Replace("n", "0");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "0");
                    strSpdHigh = strSpdHigh.Replace("m", "2");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Ambrozy"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "55");
                    strFaith = strFaith.Replace("mn", "23");
                    strHPMid = strHPMid.Replace("n", "0");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "8");
                    strMPHigh = strMPHigh.Replace("m", "2");
                    strSpdMid = strSpdMid.Replace("n", "0");
                    strSpdHigh = strSpdHigh.Replace("m", "2");
                    strPAMid = strPAMid.Replace("n", "6");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "2");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Marz"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "50");
                    strFaith = strFaith.Replace("mn", "2D");
                    strHPMid = strHPMid.Replace("n", "2");
                    strHPHigh = strHPHigh.Replace("m", "B");
                    strMPMid = strMPMid.Replace("n", "A");
                    strMPHigh = strMPHigh.Replace("m", "0");
                    strSpdMid = strSpdMid.Replace("n", "0");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "A");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "2");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Irwin"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "46");
                    strFaith = strFaith.Replace("mn", "3C");
                    strHPMid = strHPMid.Replace("n", "4");
                    strHPHigh = strHPHigh.Replace("m", "9");
                    strMPMid = strMPMid.Replace("n", "4");
                    strMPHigh = strMPHigh.Replace("m", "1");
                    strSpdMid = strSpdMid.Replace("n", "0");
                    strSpdHigh = strSpdHigh.Replace("m", "2");
                    strPAMid = strPAMid.Replace("n", "6");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "E");
                    strMAHigh = strMAHigh.Replace("m", "0");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Billy"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "46");
                    strFaith = strFaith.Replace("mn", "46");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "2");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Bersche"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "50");
                    strFaith = strFaith.Replace("mn", "41");
                    strHPMid = strHPMid.Replace("n", "4");
                    strHPHigh = strHPHigh.Replace("m", "9");
                    strMPMid = strMPMid.Replace("n", "8");
                    strMPHigh = strMPHigh.Replace("m", "2");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "0");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Brad"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "41");
                    strFaith = strFaith.Replace("mn", "3C");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "E");
                    strMPHigh = strMPHigh.Replace("m", "1");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Tom"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "55");
                    strFaith = strFaith.Replace("mn", "2D");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Telka"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "4");
                    strBrave = strBrave.Replace("mn", "37");
                    strFaith = strFaith.Replace("mn", "41");
                    strHPMid = strHPMid.Replace("n", "8");
                    strHPHigh = strHPHigh.Replace("m", "5");
                    strMPMid = strMPMid.Replace("n", "E");
                    strMPHigh = strMPHigh.Replace("m", "6");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "2");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "A");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Theime"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "37");
                    strFaith = strFaith.Replace("mn", "41");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "6");
                    strMPHigh = strMPHigh.Replace("m", "4");
                    strSpdMid = strSpdMid.Replace("n", "4");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "8");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Parks"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "4B");
                    strFaith = strFaith.Replace("mn", "28");
                    strHPMid = strHPMid.Replace("n", "4");
                    strHPHigh = strHPHigh.Replace("m", "9");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "4");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "6");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "6");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Mike H"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "41");
                    strFaith = strFaith.Replace("mn", "32");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "C");
                    strMPHigh = strMPHigh.Replace("m", "3");
                    strSpdMid = strSpdMid.Replace("n", "C");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
                if (dctCBOPeeps[i].Contains("Jon"))
                {
                    string strLoc = string.Empty;

                    strLoc = SetHexPosition(i, strLoc);

                    //strSex = strSex.Replace("m", "8");
                    strBrave = strBrave.Replace("mn", "3C");
                    strFaith = strFaith.Replace("mn", "41");
                    strHPMid = strHPMid.Replace("n", "A");
                    strHPHigh = strHPHigh.Replace("m", "8");
                    strMPMid = strMPMid.Replace("n", "6");
                    strMPHigh = strMPHigh.Replace("m", "4");
                    strSpdMid = strSpdMid.Replace("n", "8");
                    strSpdHigh = strSpdHigh.Replace("m", "1");
                    strPAMid = strPAMid.Replace("n", "4");
                    strPAHigh = strPAHigh.Replace("m", "1");
                    strMAMid = strMAMid.Replace("n", "4");
                    strMAHigh = strMAHigh.Replace("m", "1");
                    intCounter++;
                    Append_stb(strLoc);

                }
            }
            return intCounter;
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

        private void Append_stb(string strLoc)
        {
            stbCheatFile.Append(strSex + "\r\n");
            stbCheatFile.Append(strBrave + "\r\n");
            stbCheatFile.Append(strFaith + "\r\n");
            stbCheatFile.Append(strHPMid + "\r\n");
            stbCheatFile.Append(strHPHigh + "\r\n");
            stbCheatFile.Append(strMPMid + "\r\n");
            stbCheatFile.Append(strSpdHigh + "\r\n");
            stbCheatFile.Append(strSpdMid + "\r\n");
            stbCheatFile.Append(strMPHigh + "\r\n");
            stbCheatFile.Append(strPAMid + "\r\n");
            stbCheatFile.Append(strPAHigh + "\r\n");
            stbCheatFile.Append(strMAMid + "\r\n");
            stbCheatFile.Append(strPAHigh + "\r\n");
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
