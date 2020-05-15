using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ICUHelperFunctions
{
    public class Patient
    {
        public User ObjUser { get; set; }

        public int patientId { get; set; }

        public  DateTime dateIngress { get; set; }

        public int conditionId { get; set; }

        public DateTime releaseDate { get; set; }

        public int userID { get; set; }

        public int isInVent { get; set; }

        public List<string> symptoms { get; set; }

        public List<string> medications { get; set; }

        public string condition { get; set; }

        public int possibleVentilator { get; set; }




    }
}
