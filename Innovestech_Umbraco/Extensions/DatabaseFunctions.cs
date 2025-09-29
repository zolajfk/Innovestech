using TSPadel_Umbraco.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TSPadel_Umbraco.Extensions
{
    public class DatabaseFunctions
    {

        public static string GetConnectionString()
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["TSPadel_System"];

            //If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public static DataTable saveContactRequest(ContactFormModel contactFormModel)
        {

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Contact_Request_Update";
                    cmd.Parameters.AddWithValue("@Contact_Request_ID", 0);
                    cmd.Parameters.AddWithValue("@First_Name", contactFormModel.First_Name);
                    cmd.Parameters.AddWithValue("@Last_Name", contactFormModel.Last_Name);
                    cmd.Parameters.AddWithValue("@Email_Address", contactFormModel.Email_Address);
                    cmd.Parameters.AddWithValue("@Phone_Number", contactFormModel.Phone_Number);
                    cmd.Parameters.AddWithValue("@Contact_Message", contactFormModel.Contact_Message);

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }
            return dtResult;
        }

        public static ApplicationFormModel saveApplicationForm(ApplicationFormModel applicationFormModel)
        {

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ApplicationForm_Update";
                    cmd.Parameters.AddWithValue("@ApplicationID", 0);
                    cmd.Parameters.AddWithValue("@ApplicationCode", applicationFormModel.ApplicationCode);
                    cmd.Parameters.AddWithValue("@Title", applicationFormModel.Title);
                    cmd.Parameters.AddWithValue("@First_Name", applicationFormModel.First_Name);
                    cmd.Parameters.AddWithValue("@Last_Name", applicationFormModel.Last_Name);
                    cmd.Parameters.AddWithValue("@Phone_Number", applicationFormModel.Phone_Number);
                    cmd.Parameters.AddWithValue("@Alt_Phone_Number", applicationFormModel.Alt_Phone_Number);
                    cmd.Parameters.AddWithValue("@Email_Address", applicationFormModel.Email_Address);
                    cmd.Parameters.AddWithValue("@Conf_Email_Address", applicationFormModel.Conf_Email_Address);
                    cmd.Parameters.AddWithValue("@Job_Role", applicationFormModel.Job_Role);
                    cmd.Parameters.AddWithValue("@Corr_Address", applicationFormModel.Corr_Address);
                    cmd.Parameters.AddWithValue("@Org_Name", applicationFormModel.Org_Name);
                    cmd.Parameters.AddWithValue("@Legal_Org_Name", applicationFormModel.Legal_Org_Name);
                    cmd.Parameters.AddWithValue("@Legal_Entity", applicationFormModel.Legal_Entity);
                    cmd.Parameters.AddWithValue("@Previous_Applicant", applicationFormModel.Previous_Applicant);
                    cmd.Parameters.AddWithValue("@Previous_Applicant_Date", applicationFormModel.Previous_Applicant_Date.ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@Ceo_Name", applicationFormModel.Ceo_Name);
                    cmd.Parameters.AddWithValue("@Ceo_Email", applicationFormModel.Ceo_Email);
                    cmd.Parameters.AddWithValue("@Main_Address", applicationFormModel.Main_Address);
                    cmd.Parameters.AddWithValue("@Post_Code", applicationFormModel.Post_Code);
                    cmd.Parameters.AddWithValue("@Office_Phone_Number", applicationFormModel.Office_Phone_Number);
                    cmd.Parameters.AddWithValue("@Website_Url", applicationFormModel.Website_Url);
                    cmd.Parameters.AddWithValue("@Social_Media", applicationFormModel.Social_Media);
                    cmd.Parameters.AddWithValue("@Charity_Number", applicationFormModel.Charity_Number);
                    cmd.Parameters.AddWithValue("@Org_Est_Date", applicationFormModel.Org_Est_Date.ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@Regions", applicationFormModel.Regions);
                    cmd.Parameters.AddWithValue("@Main_Locations", applicationFormModel.Main_Locations);
                    cmd.Parameters.AddWithValue("@Full_Staff_Employed", applicationFormModel.Full_Staff_Employed);
                    cmd.Parameters.AddWithValue("@Part_Staff_Employed", applicationFormModel.Part_Staff_Employed);
                    cmd.Parameters.AddWithValue("@Volunteers_Employed", applicationFormModel.Volunteers_Employed);
                    cmd.Parameters.AddWithValue("@Meetings_Timetable", applicationFormModel.Meetings_Timetable);
                    cmd.Parameters.AddWithValue("@Amount_Requested", applicationFormModel.Amount_Requested);
                    cmd.Parameters.AddWithValue("@Transition_Plan", applicationFormModel.Transition_Plan);
                    cmd.Parameters.AddWithValue("@Funding_Type", applicationFormModel.Funding_Type);
                    cmd.Parameters.AddWithValue("@Project_Title", applicationFormModel.Project_Title);
                    cmd.Parameters.AddWithValue("@Project_Aim", applicationFormModel.Project_Aim);
                    cmd.Parameters.AddWithValue("@Effective_Outcomes", applicationFormModel.Effective_Outcomes);
                    cmd.Parameters.AddWithValue("@Accounts_End", applicationFormModel.Accounts_End.ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@Income", applicationFormModel.Income);
                    cmd.Parameters.AddWithValue("@Expenditure", applicationFormModel.Expenditure);
                    cmd.Parameters.AddWithValue("@Free_Reserves", applicationFormModel.Free_Reserves);
                    cmd.Parameters.AddWithValue("@Bank_Authorisers", applicationFormModel.Bank_Authorisers);
                    cmd.Parameters.AddWithValue("@Org_Intro", applicationFormModel.Org_Intro);
                    cmd.Parameters.AddWithValue("@Funding_Details", applicationFormModel.Funding_Details);
                    cmd.Parameters.AddWithValue("@Cost_Breakdown_Accounts", applicationFormModel.Cost_Breakdown_Accounts);
                    cmd.Parameters.AddWithValue("@Cost_Breakdown_Statement", applicationFormModel.Cost_Breakdown_Statement);
                    cmd.Parameters.AddWithValue("@Key_Policy_1", applicationFormModel.Key_Policy_1);
                    cmd.Parameters.AddWithValue("@Key_Policy_2", applicationFormModel.Key_Policy_2);
                    cmd.Parameters.AddWithValue("@Key_Policy_3", applicationFormModel.Key_Policy_3);
                    cmd.Parameters.AddWithValue("@Full_Cost_Breakdown_Statement", applicationFormModel.Full_Cost_Breakdown_Statement);
                    cmd.Parameters.AddWithValue("@General_Document", applicationFormModel.General_Document);
                    cmd.Parameters.AddWithValue("@Sustainability", applicationFormModel.Sustainability);
                    cmd.Parameters.AddWithValue("@Declaration_Name", applicationFormModel.Declaration_Name);
                    cmd.Parameters.AddWithValue("@Declaration_Position", applicationFormModel.Declaration_Position);
                    cmd.Parameters.AddWithValue("@Declaration_Date", applicationFormModel.Declaration_Date.ToString("yyyyMMdd"));

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            if (dtResult.Rows.Count > 0)
            {
                applicationFormModel.ApplicationCode = dtResult.Rows[0]["ApplicationCode"].ToString();
            }

            return applicationFormModel;
        }

        public static ApplicationFormModel getApplicationForm(string ApplicationCode)
        {

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ApplicationForm_Select";
                    cmd.Parameters.AddWithValue("@ApplicationCode", ApplicationCode);
                    cmd.Parameters.AddWithValue("@SelectAll", "0");

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            if (dtResult.Rows.Count > 0)
            {
                ApplicationFormModel applicationFormModel = setApplicationFormModel(dtResult.Rows[0]);
                return applicationFormModel;
            }
            else
            {
                ApplicationFormModel applicationFormModel = new ApplicationFormModel();
                return applicationFormModel;
            }
            
        }

        public static List<ApplicationFormModel> getApplications()
        {

            String ApplicationCode = "";
            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ApplicationForm_Select";
                    cmd.Parameters.AddWithValue("@ApplicationCode", ApplicationCode);
                    cmd.Parameters.AddWithValue("@SelectAll", "1");
                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            List<ApplicationFormModel> applicationForms = new List<ApplicationFormModel>();

            if (dtResult.Rows.Count > 0)
            {
                foreach(DataRow dataRow in dtResult.Rows) { 
                    ApplicationFormModel applicationFormModel = setApplicationFormModel(dataRow);
                    applicationForms.Add(applicationFormModel);
                }
                return applicationForms;
            }
            else
            {
                ApplicationFormModel applicationFormModel = new ApplicationFormModel();
                applicationForms.Add(applicationFormModel);
                return applicationForms;
            }

        }


        public static ApplicationFormModel setApplicationFormModel(DataRow dataRow)
        {
            ApplicationFormModel applicationFormModel = new ApplicationFormModel();

            applicationFormModel.ApplicationID = Convert.ToInt32(dataRow["ApplicationID"].ToString());
            applicationFormModel.ApplicationCode = dataRow["ApplicationCode"].ToString();
            applicationFormModel.Title = dataRow["Title"].ToString();
            applicationFormModel.First_Name = dataRow["First_Name"].ToString();
            applicationFormModel.Last_Name = dataRow["Last_Name"].ToString();
            applicationFormModel.Phone_Number = dataRow["Phone_Number"].ToString();
            applicationFormModel.Alt_Phone_Number = dataRow["Alt_Phone_Number"].ToString();
            applicationFormModel.Email_Address = dataRow["Email_Address"].ToString();
            applicationFormModel.Conf_Email_Address = dataRow["Conf_Email_Address"].ToString();
            applicationFormModel.Job_Role = dataRow["Job_Role"].ToString();
            applicationFormModel.Corr_Address = dataRow["Corr_Address"].ToString();
            applicationFormModel.Org_Name = dataRow["Org_Name"].ToString();
            applicationFormModel.Legal_Org_Name = dataRow["Legal_Org_Name"].ToString();
            applicationFormModel.Legal_Entity = dataRow["Legal_Entity"].ToString();
            applicationFormModel.Previous_Applicant = dataRow["Previous_Applicant"].ToString() == "1" ? true : false;
            applicationFormModel.Previous_Applicant_Date = Convert.ToDateTime(dataRow["Previous_Applicant_Date"].ToString());
            applicationFormModel.Ceo_Name = dataRow["Ceo_Name"].ToString();
            applicationFormModel.Ceo_Email = dataRow["Ceo_Email"].ToString();
            applicationFormModel.Main_Address = dataRow["Main_Address"].ToString();
            applicationFormModel.Post_Code = dataRow["Post_Code"].ToString();
            applicationFormModel.Office_Phone_Number = dataRow["Office_Phone_Number"].ToString();
            applicationFormModel.Website_Url = dataRow["Website_Url"].ToString();
            applicationFormModel.Social_Media = dataRow["Social_Media"].ToString();
            applicationFormModel.Charity_Number = dataRow["Charity_Number"].ToString();
            applicationFormModel.Org_Est_Date = Convert.ToDateTime(dataRow["Org_Est_Date"].ToString());
            applicationFormModel.Regions = dataRow["Regions"].ToString();
            //applicationFormModel.RegionDrops = dataRow["RegionDrops"].ToString();
            applicationFormModel.Main_Locations = dataRow["Main_Locations"].ToString();
            applicationFormModel.Full_Staff_Employed = Convert.ToInt32(dataRow["Full_Staff_Employed"].ToString());
            applicationFormModel.Part_Staff_Employed = Convert.ToInt32(dataRow["Part_Staff_Employed"].ToString());
            applicationFormModel.Volunteers_Employed = Convert.ToInt32(dataRow["Volunteers_Employed"].ToString());
            applicationFormModel.Meetings_Timetable = dataRow["Meetings_Timetable"].ToString();
            applicationFormModel.Amount_Requested = Convert.ToDouble(dataRow["Amount_Requested"].ToString());
            applicationFormModel.Transition_Plan = dataRow["Transition_Plan"].ToString();
            applicationFormModel.Funding_Type = dataRow["Funding_Type"].ToString();
            //applicationFormModel.FundingDrops = dataRow["FundingDrops"].ToString();
            applicationFormModel.Project_Title = dataRow["Project_Title"].ToString();
            applicationFormModel.Project_Aim = dataRow["Project_Aim"].ToString();
            applicationFormModel.Effective_Outcomes = dataRow["Effective_Outcomes"].ToString();
            applicationFormModel.Accounts_End = Convert.ToDateTime(dataRow["Accounts_End"].ToString());
            applicationFormModel.Income = Convert.ToDouble(dataRow["Income"].ToString());
            applicationFormModel.Expenditure = Convert.ToDouble(dataRow["Expenditure"].ToString());
            applicationFormModel.Free_Reserves = dataRow["Free_Reserves"].ToString();
            applicationFormModel.Bank_Authorisers = dataRow["Bank_Authorisers"].ToString();
            applicationFormModel.Org_Intro = dataRow["Org_Intro"].ToString();
            applicationFormModel.Funding_Details = dataRow["Funding_Details"].ToString();
            applicationFormModel.Cost_Breakdown_Accounts = dataRow["Cost_Breakdown_Accounts"].ToString();
            applicationFormModel.Cost_Breakdown_Statement = dataRow["Cost_Breakdown_Statement"].ToString();
            applicationFormModel.Key_Policy_1 = dataRow["Key_Policy_1"].ToString();
            applicationFormModel.Key_Policy_2 = dataRow["Key_Policy_2"].ToString();
            applicationFormModel.Key_Policy_3 = dataRow["Key_Policy_3"].ToString();
            applicationFormModel.General_Document = dataRow["General_Document"].ToString();
            applicationFormModel.Full_Cost_Breakdown_Statement = dataRow["Full_Cost_Breakdown_Statement"].ToString();
            applicationFormModel.Sustainability = dataRow["Sustainability"].ToString() == "1" ? true : false;
            applicationFormModel.Declaration_Name = dataRow["Declaration_Name"].ToString();
            applicationFormModel.Declaration_Position = dataRow["Declaration_Position"].ToString();
            applicationFormModel.Declaration_Date = Convert.ToDateTime(dataRow["Declaration_Date"].ToString());

            return applicationFormModel;
        }
        public static MonitoringFormModel saveMonitoringForm(MonitoringFormModel monitoringFormModel)
        {

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_MonitoringForm_Update";
                    cmd.Parameters.AddWithValue("@MonitoringID", 0);
                    cmd.Parameters.AddWithValue("@MonitoringCode", monitoringFormModel.MonitoringCode);
                    cmd.Parameters.AddWithValue("@Org_Name", monitoringFormModel.Org_Name);
                    cmd.Parameters.AddWithValue("@Completer_Name", monitoringFormModel.Completer_Name);
                    cmd.Parameters.AddWithValue("@Completer_Email_Address", monitoringFormModel.Completer_Email_Address);
                    cmd.Parameters.AddWithValue("@Grant_Value", monitoringFormModel.Grant_Value);
                    cmd.Parameters.AddWithValue("@Salaries", monitoringFormModel.Salaries);
                    cmd.Parameters.AddWithValue("@Premises", monitoringFormModel.Premises);
                    cmd.Parameters.AddWithValue("@Resources", monitoringFormModel.Resources);
                    cmd.Parameters.AddWithValue("@Other_Expenditure", monitoringFormModel.Other_Expenditure);
                    cmd.Parameters.AddWithValue("@Total", monitoringFormModel.Total);
                    cmd.Parameters.AddWithValue("@Under_Over_Spends", monitoringFormModel.Under_Over_Spends);
                    cmd.Parameters.AddWithValue("@Outcome_1", monitoringFormModel.Outcome_1);
                    cmd.Parameters.AddWithValue("@Outcome_2", monitoringFormModel.Outcome_2);
                    cmd.Parameters.AddWithValue("@Outcome_3", monitoringFormModel.Outcome_3);
                    cmd.Parameters.AddWithValue("@Outcome_4", monitoringFormModel.Outcome_4);
                    cmd.Parameters.AddWithValue("@Outcome_5", monitoringFormModel.Outcome_5);
                    cmd.Parameters.AddWithValue("@What_Leant", monitoringFormModel.What_Leant);
                    cmd.Parameters.AddWithValue("@Anonymised_Case", monitoringFormModel.Anonymised_Case);
                    cmd.Parameters.AddWithValue("@Publicity", monitoringFormModel.Publicity);
                    cmd.Parameters.AddWithValue("@Conditional_Images", monitoringFormModel.Conditional_Images);
                    cmd.Parameters.AddWithValue("@Total_Beneficiaries", monitoringFormModel.Total_Beneficiaries);
                    cmd.Parameters.AddWithValue("@Male", monitoringFormModel.Male);
                    cmd.Parameters.AddWithValue("@Female", monitoringFormModel.Female);
                    cmd.Parameters.AddWithValue("@Undisclosed_Gender", monitoringFormModel.Undisclosed_Gender);
                    cmd.Parameters.AddWithValue("@Total_Gender", monitoringFormModel.Total_Gender);
                    cmd.Parameters.AddWithValue("@Under_4", monitoringFormModel.Under_4);
                    cmd.Parameters.AddWithValue("@Between_5_9", monitoringFormModel.Between_5_9);
                    cmd.Parameters.AddWithValue("@Between_10_14", monitoringFormModel.Between_10_14);
                    cmd.Parameters.AddWithValue("@Between_15_24", monitoringFormModel.Between_15_24);
                    cmd.Parameters.AddWithValue("@Between_25_34", monitoringFormModel.Between_25_34);
                    cmd.Parameters.AddWithValue("@Between_35_44", monitoringFormModel.Between_35_44);
                    cmd.Parameters.AddWithValue("@Between_45_54", monitoringFormModel.Between_45_54);
                    cmd.Parameters.AddWithValue("@Between_55_64", monitoringFormModel.Between_55_64);
                    cmd.Parameters.AddWithValue("@Over_65", monitoringFormModel.Over_65);
                    cmd.Parameters.AddWithValue("@Total_Age", monitoringFormModel.Total_Age);
                    cmd.Parameters.AddWithValue("@White_Background", monitoringFormModel.White_Background);
                    cmd.Parameters.AddWithValue("@Other_White_Background", monitoringFormModel.Other_White_Background);
                    cmd.Parameters.AddWithValue("@Asian_Background", monitoringFormModel.Asian_Background);
                    cmd.Parameters.AddWithValue("@Other_Asian_Background", monitoringFormModel.Other_Asian_Background);
                    cmd.Parameters.AddWithValue("@Black_Background", monitoringFormModel.Black_Background);
                    cmd.Parameters.AddWithValue("@Other_Black_Background", monitoringFormModel.Other_Black_Background);
                    cmd.Parameters.AddWithValue("@Other_Background", monitoringFormModel.Other_Background);
                    cmd.Parameters.AddWithValue("@Total_Ethnicity", monitoringFormModel.Total_Ethnicity);
                    cmd.Parameters.AddWithValue("@Signee_Name", monitoringFormModel.Signee_Name);
                    cmd.Parameters.AddWithValue("@Signee_Email_Address", monitoringFormModel.Signee_Email_Address);
                    cmd.Parameters.AddWithValue("@Date_Signed", monitoringFormModel.Date_Signed);

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            if (dtResult.Rows.Count > 0)
            {
                monitoringFormModel.MonitoringCode = dtResult.Rows[0]["MonitoringCode"].ToString();
            }

            return monitoringFormModel;
        }

        public static MonitoringFormModel getMonitoringForm(string MonitoringCode)
        {

            MonitoringFormModel monitoringFormModel = new MonitoringFormModel();

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_MonitoringForm_Select";
                    cmd.Parameters.AddWithValue("@@MonitoringCode", MonitoringCode);

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            if (dtResult.Rows.Count > 0)
            {
                monitoringFormModel.MonitoringID = Convert.ToInt32(dtResult.Rows[0]["MonitoringID"].ToString());
                monitoringFormModel.MonitoringCode = dtResult.Rows[0]["MonitoringCode"].ToString();
                monitoringFormModel.Org_Name = dtResult.Rows[0]["Org_Name"].ToString();
                monitoringFormModel.Completer_Name = dtResult.Rows[0]["Completer_Name"].ToString();
                monitoringFormModel.Completer_Email_Address = dtResult.Rows[0]["Completer_Email_Address"].ToString();
                monitoringFormModel.Grant_Value = dtResult.Rows[0]["Grant_Value"].ToString();
                monitoringFormModel.Salaries = dtResult.Rows[0]["Salaries"].ToString();
                monitoringFormModel.Premises = dtResult.Rows[0]["Premises"].ToString();
                monitoringFormModel.Resources = dtResult.Rows[0]["Resources"].ToString();
                monitoringFormModel.Other_Expenditure = dtResult.Rows[0]["Other_Expenditure"].ToString();
                monitoringFormModel.Total = dtResult.Rows[0]["Total"].ToString();
                monitoringFormModel.Under_Over_Spends = dtResult.Rows[0]["Under_Over_Spends"].ToString();
                monitoringFormModel.Outcome_1 = dtResult.Rows[0]["Outcome_1"].ToString();
                monitoringFormModel.Outcome_2 = dtResult.Rows[0]["Outcome_2"].ToString();
                monitoringFormModel.Outcome_3 = dtResult.Rows[0]["Outcome_3"].ToString();
                monitoringFormModel.Outcome_4 = dtResult.Rows[0]["Outcome_4"].ToString();
                monitoringFormModel.Outcome_5 = dtResult.Rows[0]["Outcome_5"].ToString();
                monitoringFormModel.What_Leant = dtResult.Rows[0]["What_Leant"].ToString();
                monitoringFormModel.Anonymised_Case = dtResult.Rows[0]["Anonymised_Case"].ToString();
                monitoringFormModel.Publicity = dtResult.Rows[0]["Publicity"].ToString() == "1" ? true : false;
                monitoringFormModel.Conditional_Images = dtResult.Rows[0]["Conditional_Images"].ToString();
                monitoringFormModel.Total_Beneficiaries = Convert.ToInt32(dtResult.Rows[0]["Total_Beneficiaries"].ToString());
                monitoringFormModel.Male = Convert.ToInt32(dtResult.Rows[0]["Male"].ToString());
                monitoringFormModel.Female = Convert.ToInt32(dtResult.Rows[0]["Female"].ToString());
                monitoringFormModel.Undisclosed_Gender = Convert.ToInt32(dtResult.Rows[0]["Undisclosed_Gender"].ToString());
                monitoringFormModel.Total_Gender = Convert.ToInt32(dtResult.Rows[0]["Total_Gender"].ToString());
                monitoringFormModel.Under_4 = Convert.ToInt32(dtResult.Rows[0]["Under_4"].ToString());
                monitoringFormModel.Between_5_9 = Convert.ToInt32(dtResult.Rows[0]["Between_5_9"].ToString());
                monitoringFormModel.Between_10_14 = Convert.ToInt32(dtResult.Rows[0]["Between_10_14"].ToString());
                monitoringFormModel.Between_15_24 = Convert.ToInt32(dtResult.Rows[0]["Between_15_24"].ToString());
                monitoringFormModel.Between_25_34 = Convert.ToInt32(dtResult.Rows[0]["Between_25_34"].ToString());
                monitoringFormModel.Between_35_44 = Convert.ToInt32(dtResult.Rows[0]["Between_35_44"].ToString());
                monitoringFormModel.Between_45_54 = Convert.ToInt32(dtResult.Rows[0]["Between_45_54"].ToString());
                monitoringFormModel.Between_55_64 = Convert.ToInt32(dtResult.Rows[0]["Between_55_64"].ToString());
                monitoringFormModel.Over_65 = Convert.ToInt32(dtResult.Rows[0]["Over_65"].ToString());
                monitoringFormModel.Total_Age = Convert.ToInt32(dtResult.Rows[0]["Total_Age"].ToString());
                monitoringFormModel.White_Background = Convert.ToInt32(dtResult.Rows[0]["White_Background"].ToString());
                monitoringFormModel.Other_White_Background = Convert.ToInt32(dtResult.Rows[0]["Other_White_Background"].ToString());
                monitoringFormModel.Asian_Background = Convert.ToInt32(dtResult.Rows[0]["Asian_Background"].ToString());
                monitoringFormModel.Other_Asian_Background = Convert.ToInt32(dtResult.Rows[0]["Other_Asian_Background"].ToString());
                monitoringFormModel.Black_Background = Convert.ToInt32(dtResult.Rows[0]["Black_Background"].ToString());
                monitoringFormModel.Other_Black_Background = Convert.ToInt32(dtResult.Rows[0]["Other_Black_Background"].ToString());
                monitoringFormModel.Other_Background = Convert.ToInt32(dtResult.Rows[0]["Other_Background"].ToString());
                monitoringFormModel.Total_Ethnicity = Convert.ToInt32(dtResult.Rows[0]["Total_Ethnicity"].ToString());
                monitoringFormModel.Signee_Name = dtResult.Rows[0]["Signee_Name"].ToString();
                monitoringFormModel.Signee_Email_Address = dtResult.Rows[0]["Signee_Email_Address"].ToString();
                monitoringFormModel.Date_Signed = Convert.ToDateTime(dtResult.Rows[0]["Date_Signed"].ToString());
            }
            return monitoringFormModel;
        }

        public static List<ApplicationFormRegions> getRegions()
        {

            List<ApplicationFormRegions> applicationFormRegions = new List<ApplicationFormRegions>();

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Regions";

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            ApplicationFormRegions applicationFormRegionBlank = new ApplicationFormRegions();

            applicationFormRegionBlank.RegionValue = "";
            applicationFormRegionBlank.RegionName = "Please select...";

            applicationFormRegions.Add(applicationFormRegionBlank);

            if (dtResult.Rows.Count > 0)
            {
                foreach (DataRow dr in dtResult.Rows)
                {
                    ApplicationFormRegions applicationFormRegion = new ApplicationFormRegions();

                    applicationFormRegion.RegionValue = dr["RegionID"].ToString();
                    applicationFormRegion.RegionName = dr["RegionName"].ToString();

                    applicationFormRegions.Add(applicationFormRegion);
                }
            }
            return applicationFormRegions;
        }

        public static List<ApplicationFormFundingTypes> getFundingTypes()
        {

            List<ApplicationFormFundingTypes> applicationFormFundingTypes = new List<ApplicationFormFundingTypes>();

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Funding_Type";

                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            ApplicationFormFundingTypes applicationFormFundingTypeBlank = new ApplicationFormFundingTypes();

            applicationFormFundingTypeBlank.FundingValue = "";
            applicationFormFundingTypeBlank.FundingName = "Please select...";

            applicationFormFundingTypes.Add(applicationFormFundingTypeBlank);

            if (dtResult.Rows.Count > 0)
            {
                foreach (DataRow dr in dtResult.Rows)
                {
                    ApplicationFormFundingTypes applicationFormFundingType = new ApplicationFormFundingTypes();

                    applicationFormFundingType.FundingValue = dr["FundingID"].ToString();
                    applicationFormFundingType.FundingName = dr["FundingName"].ToString();

                    applicationFormFundingTypes.Add(applicationFormFundingType);
                }
            }
            return applicationFormFundingTypes;
        }

        public static ApplicationFormModel saveUploadedFile(ApplicationFormModel applicationFormModel)
        {

            DataTable dtResult = new DataTable();
            string connstr = GetConnectionString();

            using (SqlConnection dbconn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = dbconn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ApplicationForm_UpdateFile";
                    cmd.Parameters.AddWithValue("@ApplicationID", 0);
                    cmd.Parameters.AddWithValue("@ApplicationCode", applicationFormModel.ApplicationCode);
                    
                    cmd.Parameters.AddWithValue("@Cost_Breakdown_Accounts", applicationFormModel.Cost_Breakdown_Accounts);
                    cmd.Parameters.AddWithValue("@Cost_Breakdown_Statement", applicationFormModel.Cost_Breakdown_Statement);
                    cmd.Parameters.AddWithValue("@Key_Policy_1", applicationFormModel.Key_Policy_1);
                    cmd.Parameters.AddWithValue("@Key_Policy_2", applicationFormModel.Key_Policy_2);
                    cmd.Parameters.AddWithValue("@Key_Policy_3", applicationFormModel.Key_Policy_3);
                    cmd.Parameters.AddWithValue("@Full_Cost_Breakdown_Statement", applicationFormModel.Full_Cost_Breakdown_Statement);
                    cmd.Parameters.AddWithValue("@General_Document", applicationFormModel.General_Document);
                    
                    using (SqlDataAdapter daData = new SqlDataAdapter())
                    {
                        daData.SelectCommand = cmd;
                        dbconn.Open();
                        daData.Fill(dtResult);
                    }

                }

            }

            if (dtResult.Rows.Count > 0)
            {
                applicationFormModel.ApplicationCode = dtResult.Rows[0]["ApplicationCode"].ToString();
            }

            return applicationFormModel;
        }
    }
}
