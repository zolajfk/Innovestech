using System;
using System.Web;

namespace TSPadel_Umbraco.Models
{
    public class MonitoringFormModel
    {
        public int MonitoringID { get; set; }
        public string MonitoringCode { get; set; }
        public string Org_Name { get; set; }
        public string Completer_Name { get; set; }
        public string Completer_Email_Address { get; set; }
        public string Grant_Value { get; set; }
        public string Salaries { get; set; }
        public string Premises { get; set; }
        public string Resources { get; set; }
        public string Other_Expenditure { get; set; }
        public string Total { get; set; }
        public string Under_Over_Spends { get; set; }
        public string Outcome_1 { get; set; }
        public string Outcome_2 { get; set; }
        public string Outcome_3 { get; set; }
        public string Outcome_4 { get; set; }
        public string Outcome_5 { get; set; }
        public string What_Leant { get; set; }
        public string Anonymised_Case { get; set; }

        public Boolean Publicity { get; set; }
        public HttpPostedFileBase Conditional_Images_File { get; set; }
        public string Conditional_Images { get; set; }

        public int Total_Beneficiaries { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public int Undisclosed_Gender { get; set; }
        public int Total_Gender { get; set; }
        public int Under_4 { get; set; }
        public int Between_5_9 { get; set; }
        public int Between_10_14 { get; set; }
        public int Between_15_24 { get; set; }
        public int Between_25_34 { get; set; }
        public int Between_35_44 { get; set; }
        public int Between_45_54 { get; set; }
        public int Between_55_64 { get; set; }
        public int Over_65 { get; set; }
        public int Total_Age { get; set; }


        public int White_Background { get; set; }
        public int Other_White_Background { get; set; }
        public int Asian_Background { get; set; }
        public int Other_Asian_Background { get; set; }
        public int Black_Background { get; set; }
        public int Other_Black_Background { get; set; }
        public int Other_Background { get; set; }
        public int Total_Ethnicity { get; set; }
        public string Signee_Name { get; set; }
        public string Signee_Email_Address { get; set; }
        public DateTime Date_Signed { get; set; }
    }
}