using CodeChallenge.Dtos.BasicInfo;

namespace CodeChallenge.Dtos.Doctor
{
    public class UpdateDoctorDto : BasePersonDetailDto
    {
        public int TypeDoctorId { get; set; }
    }
}
