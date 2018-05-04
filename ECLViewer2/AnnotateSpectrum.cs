using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ECLViewer
{
    class AnnotateSpectrum // TODO: improve for complex modification.
    {

        private const int minCharge = 1;
        private const int maxCharge = 5;

        private Dictionary<string, float> massTable = new Dictionary<string, float>();
        private Regex aaPattern = new Regex(@"([A-Znc])(\[([0-9\.\-]+)\])?");


        public AnnotateSpectrum()
        {
            massTable.Add("G", 57.021464f);
            massTable.Add("A", 71.037114f);
            massTable.Add("S", 87.032028f);
            massTable.Add("P", 97.052764f);
            massTable.Add("V", 99.068414f);
            massTable.Add("T", 101.047678f);
            massTable.Add("C", 103.009184f);
            massTable.Add("I", 113.084064f);
            massTable.Add("L", 113.084064f);
            massTable.Add("N", 114.042927f);
            massTable.Add("D", 115.026943f);
            massTable.Add("Q", 128.058578f);
            massTable.Add("K", 128.094963f);
            massTable.Add("E", 129.042593f);
            massTable.Add("M", 131.040485f);
            massTable.Add("H", 137.058912f);
            massTable.Add("F", 147.068414f);
            massTable.Add("R", 156.101111f);
            massTable.Add("Y", 163.063329f);
            massTable.Add("W", 186.079313f);
            massTable.Add("n", 0);
            massTable.Add("c", 0);
            massTable.Add("Hatom", 1.007825032f);
            massTable.Add("Oatom", 15.99491462f);
            massTable.Add("PROTON", 1.00727646688f);
        }

        public void annotate(int scan_num, string peptide_1, int site_1, string peptide_2, int site_2, bool linear_1_checked, bool linear_2_checked, bool linear_3_checked, bool xl_2_checked, bool xl_3_checked, bool xl_4_checked, bool xl_5_checked, float tolerance)
        {

        }

        public float[,] buildChainIonArray(string peptide)
        {
            int chargeNum = maxCharge - minCharge + 1;
            MatchCollection matchList = aaPattern.Matches(peptide);
            float[,] chainIonArray = new float[2 * chargeNum, matchList.Count - 2];

            float nDeltaMass = matchList[0].Groups[3].Length > 0 ? float.Parse(matchList[0].Groups[3].Value, new CultureInfo("en-US")) : 0;
            float cDeltaMass = matchList[matchList.Count - 1].Groups[3].Length > 0 ? float.Parse(matchList[matchList.Count - 1].Groups[3].Value, new CultureInfo("en-US")) : 0;

            float bIonMass = massTable["n"] + nDeltaMass;
            float yIonMass = calResidueMass(peptide) + 2 * massTable["Hatom"] + massTable["Oatom"];

            for (int charge = minCharge; charge <= maxCharge; ++charge)
            {
                float bIonMassCharge = (bIonMass + charge * massTable["PROTON"]) / charge;
                float yIonMassCharge = (yIonMass + charge * massTable["PROTON"]) / charge;
                int chargeIdx = charge - minCharge;
                
                for (int idx = 1; idx < matchList.Count - 1; ++idx)
                {
                    chainIonArray[2 * chargeIdx + 1, idx - 1] = yIonMassCharge;

                    string aa = matchList[idx].Groups[1].Value;
                    float deltaMass = matchList[idx].Groups[3].Length > 0 ? float.Parse(matchList[idx].Groups[3].Value, new CultureInfo("en-US")) : 0;

                    if (idx == matchList.Count - 2)
                    {
                        bIonMassCharge += (massTable[aa] + deltaMass + massTable["c"] + cDeltaMass) / charge;
                    }
                    else
                    {
                        bIonMassCharge += (massTable[aa] + deltaMass) / charge;
                    }

                    chainIonArray[2 * chargeIdx, idx - 1] = bIonMassCharge;

                    if (idx == 1)
                    {
                        yIonMassCharge -= (massTable[aa] + deltaMass + massTable["n"] + nDeltaMass) / charge;
                    }
                    else
                    {
                        yIonMassCharge -= (massTable[aa] + deltaMass) / charge;
                    }
                }
            }

            return chainIonArray;
        }

        public float[,] buildPesudoCLIonArray(float[,] seqIon, int linkSite, float additionalMass)
        {
            int chargeNum = maxCharge - minCharge + 1;
            float[,] clIonArray = new float[2 * chargeNum, seqIon.GetLength(1)];

            if (linkSite > 0)
            {
                linkSite -= 1;
            }

            for (int charge = minCharge; charge <= maxCharge; ++charge)
            {
                int chargeIdx = charge - minCharge;
                int chargeIdx2 = 2 * chargeIdx;
                int chargeIdx21 = chargeIdx2 + 1;
                float additionMz = additionalMass / charge;
                for (int idx = 0; idx < seqIon.GetLength(1); ++idx)
                {
                    if (idx < linkSite)
                    {
                        clIonArray[chargeIdx2, idx] = seqIon[chargeIdx2, idx];
                        clIonArray[chargeIdx21, idx] = seqIon[chargeIdx21, idx] + additionMz;
                    }
                    else if (idx == linkSite)
                    {
                        clIonArray[chargeIdx2, idx] = seqIon[chargeIdx2, idx] + additionMz;
                        clIonArray[chargeIdx21, idx] = seqIon[chargeIdx21, idx] + additionMz;
                    }
                    else
                    {
                        clIonArray[chargeIdx2, idx] = seqIon[chargeIdx2, idx] + additionMz;
                        clIonArray[chargeIdx21, idx] = seqIon[chargeIdx21, idx];
                    }
                }
            }

            return clIonArray;
        }

        public float calResidueMass(string seq) // TODO: check
        {
            float totalMass = 0;
            MatchCollection matchList = aaPattern.Matches(seq);
            foreach (Match temp in matchList)
            {
                string aa = temp.Groups[1].Value;
                
                totalMass += massTable[aa] + (temp.Groups[3].Length > 0 ? float.Parse(temp.Groups[3].Value, new CultureInfo("en-US")) : 0);
            }
            return totalMass;
        }

        public Dictionary<string, float> getMassTable()
        {
            return massTable;
        }
    }
}
