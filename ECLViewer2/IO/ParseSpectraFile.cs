using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pwiz.CLI.msdata;

namespace ECLViewer.IO
{
    class ParseSpectraFile
    {

        private Dictionary<int, Dictionary<float, int>> spectraMap = new Dictionary<int, Dictionary<float, int>>();

        public ParseSpectraFile(string mzmlPath, HashSet<int> scanNumSet, string ext)
        {
            int currentScanNum = -1;
            try
            {
                MSDataFile msd = new MSDataFile(mzmlPath);
                SpectrumList spectrumList = msd.run.spectrumList;
                foreach (int scanNum in scanNumSet)
                {
                    currentScanNum = scanNum;
                    Spectrum spectrum;
                    spectrum = spectrumList.spectrum(scanNum - 1, true); // caution!!

                    MZIntensityPairList mzIntensityPairs = new MZIntensityPairList();
                    spectrum.getMZIntensityPairs(ref mzIntensityPairs);
                    Dictionary<float, int> originalPeakList = new Dictionary<float, int>(mzIntensityPairs.Count);
                    foreach (MZIntensityPair mzIntensity in mzIntensityPairs)
                    {
                        originalPeakList[(float) mzIntensity.mz] = (int) mzIntensity.intensity;
                    }

                    spectraMap[scanNum] = originalPeakList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + currentScanNum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        public Dictionary<int, Dictionary<float, int>> getSpectraMap()
        {
            return spectraMap;
        }
    }
}
