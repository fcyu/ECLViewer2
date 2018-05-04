using System;
using System.Windows.Forms;
using ECLViewer.IO;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Globalization;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;

namespace ECLViewer
{
    public partial class Form : System.Windows.Forms.Form
    {

        private string spectraFileName;
        private string resultFileName;
        private float fdrCutoff = 1;
        private DataTable resultDT;
        private Dictionary<int, Dictionary<float, int>> spectra;
        private Dictionary<string, float> massTable;

        private float ms2Tolerance;
        private float cl_mass;

        private Dictionary<float, int> currentPeakList;
        private float currentExpPrecursorMz;
        private int currentCharge;
        private int currentScanNum;
        private string currentPeptide1;
        private int currentSite1;
        private string currentPeptide2;
        private int currentSite2;
        private AnnotateSpectrum annotateSpectrumObj = new AnnotateSpectrum();
        private float peptideMass1;
        private float peptideMass2;
        private float[,] currentPeptideChainIon1;
        private float[,] currentPeptideChainIon2;
        private float[,] currentPeptideClIon1;
        private float[,] currentPeptideClIon2;


        [STAThread]
        static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Form form_obj = new Form();
            Application.Run(form_obj);
            return 0;
        }

        public Form()
        {
            InitializeComponent();
        }

        private void buttonSpectra_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                spectraFileName = openFileDialog1.FileName;
                textBoxSpectra.Text = spectraFileName;
            }
        }

        private void textBoxSpectra_TextChanged(object sender, EventArgs e)
        {
            spectraFileName = textBoxSpectra.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            labelLoading.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            labelLoading.Visible = false;
            DataRow[] temp = resultDT.Select("q_value <= " + fdrCutoff);
            dataGridView1.DataSource = new DataView(temp.CopyToDataTable());
            dataGridView1.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[6].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[9].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns[10].DefaultCellStyle.Format = "N2";
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if ((spectraFileName != null) && (resultFileName != null))
            {
                try
                {
                    // read result
                    ParseResult parseResultObj = new ParseResult(resultFileName);
                    resultDT = parseResultObj.getDataTable();
                    HashSet<int> scanNumSet = parseResultObj.getScanNumSet();

                    // read spectra
                    if (!File.Exists(spectraFileName))
                    {
                        MessageBox.Show("The file " + spectraFileName + " is not exist.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else if (spectraFileName.EndsWith("mzXML"))
                    {
                        string[] temp = spectraFileName.Split('.');
                        string ext = temp[temp.Length - 1];
                        ParseSpectraFile parseMgfObj = new ParseSpectraFile(spectraFileName, scanNumSet, ext);
                        spectra = parseMgfObj.getSpectraMap();
                    }
                    else
                    {
                        MessageBox.Show("The format of the file " + spectraFileName + " is not supported.", "Unsupported file format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Open file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else if ((spectraFileName == null) && (resultFileName == null))
            {
                MessageBox.Show("Please specify result and spectra files.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else if (spectraFileName == null)
            {
                MessageBox.Show("Please specify spectra file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Please specify result file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resultFileName = openFileDialog1.FileName;
                textBoxResult.Text = resultFileName;
            }
        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {
            resultFileName = textBoxResult.Text;
        }

        private void comboBoxFDR_SelectedIndexChanged(object sender, EventArgs e)
        {
            fdrCutoff = float.Parse(comboBoxFDR.Text, new CultureInfo("en-US"));
            DataRow[] temp = resultDT.Select("q_value <= " + fdrCutoff);
            dataGridView1.DataSource = new DataView(temp.CopyToDataTable());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // TODO: check
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                DataGridViewRow currentRow = dataGridView1.CurrentRow;
                currentScanNum = Convert.ToInt32(currentRow.Cells["scan_num"].Value);
                currentExpPrecursorMz = (float) Convert.ToDouble(currentRow.Cells["spectrum_mz"].Value);
                if (!spectra.ContainsKey(currentScanNum))
                {
                    MessageBox.Show("Cannot find the corresponding spectrum.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                currentPeakList = spectra[currentScanNum];
                currentCharge = Convert.ToInt32(currentRow.Cells["charge"].Value);

                string currentPeptide = Convert.ToString(currentRow.Cells["peptide"].Value);
                string[] tempArray = currentPeptide.Split('-');
                currentPeptide1 = tempArray[0];
                currentSite1 = int.Parse(tempArray[1], new CultureInfo("en-US"));
                currentPeptide2 = tempArray[2];
                currentSite2 = int.Parse(tempArray[3], new CultureInfo("en-US"));

                // update selected charges
                if (currentCharge == 1)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                else if (currentCharge == 2)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                else if (currentCharge == 3)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = false;
                    checkBox4.Checked = true;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                else if (currentCharge == 4)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    checkBox5.Checked = true;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                }
                else if (currentCharge == 5)
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    checkBox5.Checked = true;
                    checkBox6.Checked = true;
                    checkBox7.Checked = false;
                } else
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    checkBox5.Checked = true;
                    checkBox6.Checked = true;
                    checkBox7.Checked = true;
                }

                tabControl1.SelectedTab = tabPageSpectrum;

                updateParameter();

                // prepare for the theoretical ions
                massTable = annotateSpectrumObj.getMassTable();
                peptideMass1 = annotateSpectrumObj.calResidueMass(currentPeptide1) + 2 * massTable["Hatom"] + massTable["Oatom"];
                peptideMass2 = annotateSpectrumObj.calResidueMass(currentPeptide2) + 2 * massTable["Hatom"] + massTable["Oatom"];
                currentPeptideChainIon1 = annotateSpectrumObj.buildChainIonArray(currentPeptide1);
                currentPeptideChainIon2 = annotateSpectrumObj.buildChainIonArray(currentPeptide2);

                updateTheoreticalIons();

                plotSpectrum();
            }
        }

        private void plotSpectrum()
        {
            SortedDictionary<float, float> unmatchedPeaks = new SortedDictionary<float, float>();
            SortedDictionary<float, AnnotatedPeak> matchedPeak = new SortedDictionary<float, AnnotatedPeak>();
            float smallestMz = 99999;
            float maxIntensity = 0;

            foreach (KeyValuePair<float, int> peak in currentPeakList)
            {
                if (peak.Key < smallestMz)
                {
                    smallestMz = peak.Key;
                }

                if (peak.Value > maxIntensity)
                {
                    maxIntensity = peak.Value;
                }

                AnnotatedPeak annotatedPeak = null;

                if (checkBox1.Checked)
                {
                    annotatedPeak = matchLinearIon(peak, 1);
                }

                if ((annotatedPeak == null) && checkBox2.Checked)
                {
                    annotatedPeak = matchLinearIon(peak, 2);
                }

                if ((annotatedPeak == null) && checkBox3.Checked)
                {
                    annotatedPeak = matchLinearIon(peak, 3);
                }

                if ((annotatedPeak == null) && checkBox4.Checked)
                {
                    annotatedPeak = matchXLIon(peak, 2);
                }

                if ((annotatedPeak == null) && checkBox5.Checked)
                {
                    annotatedPeak = matchXLIon(peak, 3);
                }

                if ((annotatedPeak == null) && checkBox6.Checked)
                {
                    annotatedPeak = matchXLIon(peak, 4);
                }

                if ((annotatedPeak == null) && checkBox7.Checked)
                {
                    annotatedPeak = matchXLIon(peak, 5);
                }

                if (annotatedPeak == null)
                {
                    unmatchedPeaks[peak.Key] = peak.Value;
                }
                else
                {
                    matchedPeak[peak.Key] = annotatedPeak;
                }
            }

            PlotModel plotModel = new PlotModel { Title = String.Format("Spectrum: {0}.{1}", currentScanNum, currentCharge)};

            // make the y-axis limit bigger.
            DataPointSeries transparntSeries = new StemSeries { MarkerType = MarkerType.None, Color = OxyColors.Transparent };
            transparntSeries.Points.Add(new DataPoint(smallestMz - 1, maxIntensity * 1.1));
            plotModel.Series.Add(transparntSeries);
            
            // unmatched peaks
            DataPointSeries unmatchedSeries = new StemSeries { MarkerType = MarkerType.None, Color = OxyColors.Gray, StrokeThickness = 0.5};
            foreach (KeyValuePair<float, float> peak in unmatchedPeaks)
            {
                unmatchedSeries.Points.Add(new DataPoint(peak.Key, peak.Value));      
            }
            plotModel.Series.Add(unmatchedSeries);

            // matched peaks
            DataPointSeries matchedSeries = new StemSeries { MarkerType = MarkerType.None, Color = OxyColors.Blue, StrokeThickness = 0.5};
            foreach (KeyValuePair<float, AnnotatedPeak> peak in matchedPeak)
            {
                matchedSeries.Points.Add(new DataPoint(peak.Key, peak.Value.intensity));
                AnnotatedPeak annotatedPeak = peak.Value;
                string annotateText = annotatedPeak.chainType + annotatedPeak.byType + annotatedPeak.fragmentLocation;
                for (int i = 0; i < annotatedPeak.charge; ++i)
                {
                    annotateText += "+";
                }
                Annotation ann = new PointAnnotation { Shape = MarkerType.None, Size = 0, TextVerticalAlignment = VerticalAlignment.Bottom, X = peak.Key, Y = annotatedPeak.intensity, Text = annotateText};
                plotModel.Annotations.Add(ann);
            }
            plotModel.Series.Add(matchedSeries);
            plotViewSpectrum.Model = plotModel;
        }

        private void updateTheoreticalIons()
        {
            currentPeptideClIon1 = annotateSpectrumObj.buildPesudoCLIonArray(currentPeptideChainIon1, currentSite1, peptideMass2 + cl_mass);
            currentPeptideClIon2 = annotateSpectrumObj.buildPesudoCLIonArray(currentPeptideChainIon2, currentSite2, peptideMass1 + cl_mass);
        }

        private void updateParameter()
        {
            ms2Tolerance = float.Parse(textBoxTolerance.Text, new CultureInfo("en-US"));
            cl_mass = float.Parse(textBoxCLer.Text, new CultureInfo("en-US"));
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updateParameter();
            updateTheoreticalIons();
            plotSpectrum();
        }

        private AnnotatedPeak matchLinearIon(KeyValuePair<float, int> peak, int charge)
        {
            int tempSite1 = 0;
            int tempSite2 = 0;
            if (currentSite1 > 0)
            {
                tempSite1 = currentSite1 - 1;
            }
            if (currentSite2 > 0)
            {
                tempSite2 = currentSite2 - 1;
            }

            AnnotatedPeak annotatedPeak = null;
            bool matched = false;
            int bIonIdx = (charge - 1) * 2;
            int yIonIdx = bIonIdx + 1;
            for (int i = 0; i < tempSite1; ++i)
            {
                if (Math.Abs(peak.Key - currentPeptideClIon1[bIonIdx, i]) <= ms2Tolerance)
                {
                    annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B1", i + 1, charge, "b");
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                for (int i = tempSite1 + 1; i < currentPeptideClIon1.GetLength(1); ++i)
                {
                    if (Math.Abs(peak.Key - currentPeptideClIon1[yIonIdx, i]) <= ms2Tolerance)
                    {
                        annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B1", currentPeptideClIon1.GetLength(1) - i, charge, "y");
                        matched = true;
                        break;
                    }
                }
            }

            if (!matched)
            {
                for (int i = 0; i < tempSite2; ++i)
                {
                    if (Math.Abs(peak.Key - currentPeptideClIon2[bIonIdx, i]) <= ms2Tolerance)
                    {
                        annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B2", i + 1, charge, "b");
                        matched = true;
                        break;
                    }
                }
            }

            if (!matched)
            {
                for (int i = tempSite2 + 1; i < currentPeptideClIon2.GetLength(1); ++i)
                {
                    if (Math.Abs(peak.Key - currentPeptideClIon2[yIonIdx, i]) <= ms2Tolerance)
                    {
                        annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B2", currentPeptideClIon2.GetLength(1) - i, charge, "y");
                        matched = true;
                        break;
                    }
                }
            }

            return annotatedPeak;
        }

        private AnnotatedPeak matchXLIon(KeyValuePair<float, int> peak, int charge)
        {
            int tempSite1 = 0;
            int tempSite2 = 0;
            if (currentSite1 > 0)
            {
                tempSite1 = currentSite1 - 1;
            }
            if (currentSite2 > 0)
            {
                tempSite2 = currentSite2 - 1;
            }

            AnnotatedPeak annotatedPeak = null;
            bool matched = false;
            int bIonIdx = (charge - 1) * 2;
            int yIonIdx = bIonIdx + 1;
            for (int i = tempSite1; i < currentPeptideClIon1.GetLength(1); ++i)
            {
                if (Math.Abs(peak.Key - currentPeptideClIon1[bIonIdx, i]) <= ms2Tolerance)
                {
                    annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B1", i + 1, charge, "b");
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                for (int i = 0; i < tempSite1 + 1; ++i)
                {
                    if (Math.Abs(peak.Key - currentPeptideClIon1[yIonIdx, i]) <= ms2Tolerance)
                    {
                        annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B1", currentPeptideClIon1.GetLength(1) - i, charge, "y");
                        matched = true;
                        break;
                    }
                }
            }

            if (!matched)
            {
                for (int i = tempSite2; i < currentPeptideClIon2.GetLength(1); ++i)
                {
                    if (Math.Abs(peak.Key - currentPeptideClIon2[bIonIdx, i]) <= ms2Tolerance)
                    {
                        annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B2", i + 1, charge, "b");
                        matched = true;
                        break;
                    }
                }
            }

            if (!matched)
            {
                for (int i = 0; i < currentSite2 + 1; ++i)
                {
                    if (Math.Abs(peak.Key - currentPeptideClIon2[yIonIdx, i]) <= ms2Tolerance)
                    {
                        annotatedPeak = new AnnotatedPeak(peak.Value, "\u03B2", currentPeptideClIon2.GetLength(1) - i, charge, "y");
                        matched = true;
                        break;
                    }
                }
            }

            return annotatedPeak;
        }

        private class AnnotatedPeak
        {
            public int intensity;
            public string chainType;
            public int fragmentLocation;
            public int charge;
            public string byType;

            public AnnotatedPeak(int intensity, string chainType, int fragmentLocation, int charge, string ionType)
            {
                this.intensity = intensity;
                this.chainType = chainType;
                this.fragmentLocation = fragmentLocation;
                this.charge = charge;
                this.byType = ionType;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
    }
}
