﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientMedicationViewModel
    {
        public int PatientID { get; set; }
        public string MedicationName { get; set; }
        public string MedicationType { get; set; }
    }
}
