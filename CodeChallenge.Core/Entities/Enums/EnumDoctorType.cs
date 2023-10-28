using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Entities.Enums
{
    public enum EnumDoctorType : int
    {

        [Description("دکتر عمومی")]
        General = 1,

        [Description("دکتر متخصص")]
        Specialist = 2,

        [Description("دکتر فوق متخصص")]
        TopSpecialist = 3,

    }
}
