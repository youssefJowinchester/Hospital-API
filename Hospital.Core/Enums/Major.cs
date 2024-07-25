using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Enums
{
    public enum Major
    {
        [EnumMember(Value = "GeneralPractice")]
        GeneralPractice,
        [EnumMember(Value = "Cardiology")]
        Cardiology,
        [EnumMember(Value = "Neurology")]
        Neurology,
        [EnumMember(Value = "Orthopedics")]
        Orthopedics,
        [EnumMember(Value = "Pediatrics")]
        Pediatrics,
        [EnumMember(Value = "Dermatology")]
        Dermatology,
        [EnumMember(Value = "Psychiatry")]
        Psychiatry,
        [EnumMember(Value = "Surgery")]
        Surgery,
        [EnumMember(Value = "Oncology")]
        Oncology,
        [EnumMember(Value = "Radiology")]
        Radiology
    }
}
