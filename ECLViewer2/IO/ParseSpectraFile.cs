using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using pwiz.CLI.data;
using pwiz.CLI.msdata;

namespace ECLViewer.IO
{
    class ParseSpectraFile
    {

        private Dictionary<int, Dictionary<float, int>> spectraMap = new Dictionary<int, Dictionary<float, int>>();
        private Regex scanNumPattern = new Regex(@"scan=([0-9]+)");

        public ParseSpectraFile(string mzmlPath, HashSet<int> scanNumSet, string ext)
        {
            int currentScanNum = -1;
            try
            {
                MSDataFile msd = new MSDataFile(mzmlPath);
                SpectrumList spectrumList = msd.run.spectrumList;
                for (int i = 0; i < spectrumList.size(); ++i)
                {
                    Spectrum spectrum = spectrumList.spectrum(i, true);
                    if (int.Parse(spectrum.cvParams[0].value) == 2)
                    {
                        Match match = scanNumPattern.Match(spectrum.id);
                        currentScanNum = int.Parse(match.Groups[1].Value);
                        if (scanNumSet.Contains(currentScanNum))
                        {
                            MZIntensityPairList mzIntensityPairs = new MZIntensityPairList();
                            spectrum.getMZIntensityPairs(ref mzIntensityPairs);
                            Dictionary<float, int> originalPeakList = new Dictionary<float, int>(mzIntensityPairs.Count);
                            foreach (MZIntensityPair mzIntensity in mzIntensityPairs)
                            {
                                originalPeakList[(float)mzIntensity.mz] = (int)mzIntensity.intensity;
                            }

                            spectraMap[currentScanNum] = originalPeakList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + currentScanNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public Dictionary<int, Dictionary<float, int>> getSpectraMap()
        {
            return spectraMap;
        }
    }
}
