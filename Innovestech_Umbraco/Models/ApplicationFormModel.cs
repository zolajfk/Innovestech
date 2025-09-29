using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace TSPadel_Umbraco.Models
{
    public class ApplicationFormModel
    {
        public int ApplicationID { get; set; }
        public string ApplicationCode { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Alt_Phone_Number { get; set; }
        public string Email_Address { get; set; }
        public string Conf_Email_Address { get; set; }
        public string Job_Role { get; set; }
        public string Corr_Address { get; set; }

        public string Org_Name { get; set; }
        public string Legal_Org_Name { get; set; }
        public string Legal_Entity { get; set; }

        public Boolean Previous_Applicant { get; set; }
        [NotMapped]
        public List<ApplicationFormFundingTypes> ApplicantDrops { get; set; }
        public DateTime Previous_Applicant_Date { get; set; }

        public string Ceo_Name { get; set; }
        public string Ceo_Email { get; set; }
        public string Main_Address { get; set; }
        public string Post_Code { get; set; }
        public string Office_Phone_Number { get; set; }
        public string Website_Url { get; set; }
        public string Social_Media { get; set; }
        public string Charity_Number { get; set; }
        public DateTime Org_Est_Date { get; set; }

        public string Regions { get; set; }
        [NotMapped]
        public List<ApplicationFormRegions> RegionDrops { get; set; }
        public string Main_Locations { get; set; }
        public int Full_Staff_Employed { get; set; }
        public int Part_Staff_Employed { get; set; }
        public int Volunteers_Employed { get; set; }
        public string Meetings_Timetable { get; set; }

        public Double Amount_Requested { get; set; }
        public string Transition_Plan { get; set; }

        public string Funding_Type { get; set; }
        [NotMapped]
        public List<ApplicationFormFundingTypes> FundingDrops { get; set; }

        public string Project_Title { get; set; }
        public string Project_Aim { get; set; }
        public string Effective_Outcomes { get; set; }

        public DateTime Accounts_End { get; set; }
        public Double Income { get; set; }
        public Double Expenditure { get; set; }
        public string Free_Reserves { get; set; }
        public string Bank_Authorisers { get; set; }

        public string Org_Intro { get; set; }
        public string Funding_Details { get; set; }

        public HttpPostedFileBase Cost_Breakdown_Accounts_File { get; set; }
        public string Cost_Breakdown_Accounts { get; set; }
        public HttpPostedFileBase Cost_Breakdown_Statement_File { get; set; }
        public string Cost_Breakdown_Statement { get; set; }

        public HttpPostedFileBase Full_Cost_Breakdown_Statement_File { get; set; }
        public string Full_Cost_Breakdown_Statement { get; set; }

        public HttpPostedFileBase Key_Policy_1_File { get; set; }
        public string Key_Policy_1 { get; set; }
        public HttpPostedFileBase Key_Policy_2_File { get; set; }
        public string Key_Policy_2 { get; set; }
        public HttpPostedFileBase Key_Policy_3_File { get; set; }
        public string Key_Policy_3 { get; set; }

        public HttpPostedFileBase General_Document_File { get; set; }
        public string General_Document { get; set; }
        public Boolean Sustainability { get; set; }
        public string Declaration_Name { get; set; }
        public string Declaration_Position { get; set; }
        public DateTime Declaration_Date { get; set; }

        public Boolean completed { get; set; }
    }
}