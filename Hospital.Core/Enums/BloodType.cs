using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Enums
{
    public enum BloodType
    {
        [EnumMember(Value = "A+")]
        A_Positive,
        [EnumMember(Value = "A-")]
        A_Negative,
        [EnumMember(Value = "B+")]
        B_Positive,
        [EnumMember(Value = "B-")]
        B_Negative,
        [EnumMember(Value = "AB+")]
        AB_Positive,
        [EnumMember(Value = "AB-")]
        AB_Negative,
        [EnumMember(Value = "O+")]
        O_Positive,
        [EnumMember(Value = "O-")]
        O_Negative
    }
}
