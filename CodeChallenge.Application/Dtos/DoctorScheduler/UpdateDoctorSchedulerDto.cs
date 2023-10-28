using CodeChallenge.Dtos.BasicInfo;

namespace CodeChallenge.Dtos.DoctorScheduler
{
    public class UpdateDoctorSchedulerDto : BaseDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }
    }
}
