#region PaySpan835ControlReport
namespace VPHP_PaySpan835_ControlReport
{
    #region Referenced Assemblies
    using System;
    using Q.Global;
    using Q.Global.DomainManagement;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Configuration;
    using System.Diagnostics;
    using Q.ProcessLogWrapper;
    using VPHP_PaySpan835_ControlReport.Helper;
    using VPHP_PaySpan835_ControlReport.Entities;
    using VPHP_PaySpan835_ControlReport.Common;
    #endregion

    class ControlReport
    {
        #region Main Method
        /// <summary>
        /// Main Method or Starting point of the interface
        /// </summary>
        /// <param name="args">User inputs</param>
        /// <returns>status of the process</returns>
        static void Main(string[] args)
        {
            #region Declaration
            ControlReportHelper objHelper = new ControlReportHelper();
            #endregion          

            try
            {
                #region Call to Process Message Function

                #region Process Inputs

                QPaySpan835ControlReportProcessDetails objPaySpan835ProcessDetails = new QPaySpan835ControlReportProcessDetails();
                objPaySpan835ProcessDetails = BuildConfigurationData(new List<string>(args));

                #endregion

                objHelper.ProcessMessage(objPaySpan835ProcessDetails);

                #endregion

                //Console.WriteLine(iReturnStatus.ToString());

            }
            catch (Exception e)
            {
                #region Logging Exception
                Console.WriteLine("Source - " + e.Source +
                                                            "\n Message - " +
                                                            e.Message +
                                                            "\n StackTrace - " +
                                                            e.StackTrace,
                                                            EventLogEntryType.Error);

                Common.Common.WriteEventLogEntry("Source - " + e.Source +
                                                         "\n Message - " +
                                                         e.Message +
                                                         "\n StackTrace - " +
                                                         e.StackTrace,
                                                         EventLogEntryType.Error);
                return;

                #endregion

               // return 8;
            }

            //return iReturnStatus;
        }
        #endregion
        
        #region Configurationdata
        /// <summary>
        /// This function is used for retrieving the data from the command line argument or the configuration file
        /// </summary>
        /// <param name="lstArguments">command line arguments</param>
        /// <returns>Configuration parameters from input</returns>
        private static QPaySpan835ControlReportProcessDetails BuildConfigurationData(List<string> lstArguments)
        {
            QPaySpan835ControlReportProcessDetails objPaySpan835ProcessDetails = new QPaySpan835ControlReportProcessDetails();

            //If arguments are passed from command line, use them.
            if (lstArguments.Count > 0)
            {
                Console.WriteLine("Number of arguments = " + lstArguments.Count);
                Console.WriteLine(lstArguments[0] + "--");
                Console.WriteLine(lstArguments[1] + "--");
                Console.WriteLine(lstArguments[2] + "--");
                Console.WriteLine(lstArguments[3] + "--");
                Console.WriteLine(lstArguments[4] + "--");
                objPaySpan835ProcessDetails.strInputPath = lstArguments[0];
                objPaySpan835ProcessDetails.strOutputPath = lstArguments[1];
                objPaySpan835ProcessDetails.strFileName = lstArguments[2];
                objPaySpan835ProcessDetails.strCustomDbName = lstArguments[3];
                objPaySpan835ProcessDetails.strServerName = lstArguments[4];
               // objPaySpan835ProcessDetails.strArchivePath = lstArguments[5];
                objPaySpan835ProcessDetails.strlob = lstArguments[5];

            }
            //If no arguments are found, use the values from configuration file.
            else
            {
                objPaySpan835ProcessDetails.strInputPath = ConfigurationManager.AppSettings["strInputPath"].ToString();
                objPaySpan835ProcessDetails.strOutputPath = ConfigurationManager.AppSettings["strOutputPath"].ToString();
                objPaySpan835ProcessDetails.strFileName = ConfigurationManager.AppSettings["strFileName"].ToString();
                objPaySpan835ProcessDetails.strCustomDbName = ConfigurationManager.AppSettings["strCustomDbName"].ToString();
                objPaySpan835ProcessDetails.strServerName = ConfigurationManager.AppSettings["strServerName"].ToString();
                //objPaySpan835ProcessDetails.strArchivePath = ConfigurationManager.AppSettings["strArchivePath"].ToString();
                objPaySpan835ProcessDetails.strlob = ConfigurationManager.AppSettings["strlob"].ToString();
            }
            return objPaySpan835ProcessDetails;
        }
        #endregion
    }
}
#endregion
