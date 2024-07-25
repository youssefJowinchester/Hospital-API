using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Enums
{
    public enum Position
    {
        [EnumMember(Value = "GeneralPractitioner")]
        GeneralPractitioner,
        [EnumMember(Value = "Resident")]
        Resident,
        [EnumMember(Value = "AttendingPhysician")]
        AttendingPhysician,
        [EnumMember(Value = "ChiefOfStaff")]
        ChiefOfStaff,
        [EnumMember(Value = "HeadOfDepartment")]
        HeadOfDepartment,
        [EnumMember(Value = "Consultant")]
        Consultant,
        [EnumMember(Value = "Fellow")]
        Fellow,
        [EnumMember(Value = "Registrar")]
        Registrar,
        [EnumMember(Value = "MedicalOfficer")]
        MedicalOfficer,
        [EnumMember(Value = "HouseOfficer")]
        HouseOfficer
    }
}
