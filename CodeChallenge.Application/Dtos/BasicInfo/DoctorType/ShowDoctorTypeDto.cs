using CodeChallenge.Core.Entities.Enums;

namespace CodeChallenge.Dtos.BasicInfo.DoctorType
{
    public class ShowDoctorTypeDto : BaseDto
    {
        public EnumDoctorType Type { get; set; }
        public int MinTimeVisit { get; set; }
        public int MaxTimeVisit { get; set; }
    }
}
