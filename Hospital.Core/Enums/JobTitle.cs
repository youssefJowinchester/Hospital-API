using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Enums
{
    public enum JobTitle
    {
        [EnumMember(Value = "Intern")]
        Intern,

        [EnumMember(Value = "HR")]
        HR,


        [EnumMember(Value = "Developer")]
        Developer,

        [EnumMember(Value = "CEO")]
        CEO,

        [EnumMember(Value = "Information Technology")]
        InformationTechnology,

        [EnumMember(Value = "Environmental Services")]
        EnvironmentalServices,

        [EnumMember(Value = "Food Services")]
        FoodServices,

        [EnumMember(Value = "Manager")]
        Manager,


        [EnumMember(Value = "Security")]
        Security,

        [EnumMember(Value = "Education and Training")]
        EducationAndTraining,

        [EnumMember(Value = "call center")]
        CallCenter,

        [EnumMember(Value = "Reception")]
        Reception,
    }
}
