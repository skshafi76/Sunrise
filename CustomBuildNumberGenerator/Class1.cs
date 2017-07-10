using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;

namespace CustomBuildNumberGenerator
{
    public class BuildNumberGenerator : Task
    {


        public override bool Execute()
        {
            string[] Lines = File.ReadAllLines("C:\\BuildNumber\\BuildNumber_SFM17.txt");
            string prevBuildNumber = Lines[0].Trim();
            label = Lines[1].Trim();
            int prevBuildNumber1 = Int32.Parse(prevBuildNumber);
            currentBuildNumber = prevBuildNumber1 + 1;
            m_buildNumber = currentBuildNumber.ToString().Trim();
            File.Delete("C:\\BuildNumber\\BuildNumber_SFM17.txt");
            StreamWriter sw = File.CreateText("C:\\BuildNumber\\BuildNumber_SFM17.txt");
            sw.WriteLine(currentBuildNumber.ToString().Trim());
            sw.WriteLine(label.ToString().Trim());
            sw.Close();
            return true;
        }
        private string m_buildNumber;
        private int currentBuildNumber;
        private string label;

        [Output]
        public string BuildNumber
        {
            get { return label + m_buildNumber; }
        }

        [Output]
        public int BuildNumberDigit
        {
            get { return currentBuildNumber; }
        }

    }
}