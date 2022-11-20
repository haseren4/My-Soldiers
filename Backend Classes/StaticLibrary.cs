using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Soldiers.Backend_Classes
{
    public static class StaticLibrary
    {
        public static string[] RANK_ABRV_LIST = { "PVT", "PV2", "PFC", "SPC", "CPL", "SGT", "SSG", "SFC", "MSG", "1SG", "SGM", "CSM" };

        public static string XML_ROOT = "ROOT";

        public static string XML_DOCUMENT = "data.xml";


        public static string XML_SOLDIER = "SOLDIER";
        public static string XML_SOLDIER_FNAME = "FNAME";
        public static string XML_SOLDIER_MNAME = "MNAME";
        public static string XML_SOLDIER_LNAME = "LNAME";
        public static string XML_SOLDIER_POINTS = "POINTS";
        public static string XML_SOLDIER_RANK = "RANK";
        public static string XML_SOLDIER_RANK_DATE = "rank-date";
        public static string XML_SOLDIER_PROMOTABLE = "PROMOTABLE";
        public static string XML_SOLDIER_FLAG = "FLAGGED";
        public static string XML_SOLDIER_FLAG_DATE = "flag-date";
        public static string XML_SOLDIER_BAR = "BARRED";
        public static string XML_SOLDIER_BAR_DATE = "bar-date";
        public static string XML_SOLDIER_MOS = "MOS";
        public static string XML_SOLDIER_BASD = "BASD";
        public static string XML_SOLDIER_PEBD = "PEBD";
        public static string XML_SOLDIER_BESD = "BESD";
        public static string XML_SOLDIER_ETS = "ETS";
        public static string XML_SOLDIER_DIEMS = "DIEMS";
        public static string XML_SOLDIER_AGCSM = "AGCSM";
        public static string XML_SOLDIER_PCS = "PCS";
        public static string XML_SOLDIER_DENTAL = "DENTAL";
        public static string XML_SOLDIER_MEDPROS_DATE = "med-date";
        public static string XML_SOLDIER_DENTAL_CLASS = "dent-class";
        public static string XML_SOLDIER_VISION = "VISION";
        public static string XML_SOLDIER_HEARING = "HEARING";
        public static string XML_SOLDIER_PHA = "PHA";
        public static string XML_SOLDIER_DEPENDENTS = "DEPENDENTS";
        public static string XML_SOLDIER_ADDRESSES = "ADDRESSES";
        public static string XML_SOLDIER_VEHICLES = "VEHICLES";
        public static string XML_SOLDIER_NOTE = "NOTE";
        
        public static string XML_SOLDIER_COUNSELLING = "COUNSELLING";
        public static string XML_SOLDIER_COUNSELLING_DATE = "counsel-date";
        public static string XML_SOLDIER_COUNSELLING_TITLE = "counsel-title";
        public static string XML_SOLDIER_COUNSELLING_FILE = "counsel-file";

        public static string XML_SOLDIER_APFT = "APFT";
        public static string XML_SOLDIER_APFT_PUSH = "pu";
        public static string XML_SOLDIER_APFT_SIT = "su";
        public static string XML_SOLDIER_APFT_TIME = "apft-time";
        public static string XML_SOLDIER_APFT_ALTERNATE = "alt";
        public static string XML_SOLDIER_APFT_SCORE = "apft-score";
        public static string XML_SOLDIER_APFT_DATE = "apft-date";

        public static string XML_SOLDIER_AWARD = "AWARD";
        public static string XML_SOLDIER_AWARD_DATE = "award-date";
        public static string XML_SOLDIER_AWARD_NAME = "name";

        public static string XML_SOLDIER_WEAPON = "WEAPON";
        public static string XML_SOLDIER_WEAPON_SYSTEM = "system";
        public static string XML_SOLDIER_WEAPON_DATE = "date";
        public static string XML_SOLDIER_WEAPON_SCORE = "score";

        public static string XML_SOLDIER_MILED = "MILED";
        public static string XML_SOLDIER_MILED_COURSE = "course";
        public static string XML_SOLDIER_MILED_DATE = "date";
        public static string XML_SOLDIER_MILED_ANNUAL = "annual";

        public static string XML_SOLDIER_CIVED = "CIVED";
        public static string XML_SOLDIER_CIVED_INSTITUTION = "institution";
        public static string XML_SOLDIER_CIVED_START = "start";
        public static string XML_SOLDIER_CIVED_END = "end";
        public static string XML_SOLDIER_CIVED_CREDITS = "credits";
        public static string XML_SOLDIER_CIVED_GRADUATE = "graduate";

        public static string XML_SOLDIER_CERT = "CERTIFICATION";
        public static string XML_SOLDIER_CERT_NAME = "name";
        public static string XML_SOLDIER_CERT_DATE = "date";
        public static string XML_SOLDIER_CERT_RENEW = "renew";

        public static string XML_SOLDIER_ABCP = "ABCP";
        public static string XML_SOLDIER_ABCP_DATE = "date";
        public static string XML_SOLDIER_ABCP_PERCENT = "percent";
        public static string XML_SOLDIER_ABCP_MAX = "max";


    }
}
