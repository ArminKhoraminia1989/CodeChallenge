using CodeChallenge.Dtos.BasicInfo;

namespace CodeChallenge.Dtos.Doctor
{
    public class CreateDoctorDto : BasePersonDetailDto
    {
        public int TypeDoctorId { get; set; }
    }
}
