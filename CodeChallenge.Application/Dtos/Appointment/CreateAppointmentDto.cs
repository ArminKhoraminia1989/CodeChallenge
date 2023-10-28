using CodeChallenge.Dtos.BasicInfo;

namespace CodeChallenge.Dtos.Appointment
{
    public class CreateAppointmentDto : BaseDto
    {
        public int DurationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BriefDescriptionSickness { get; set; }
        public string DescriptionOfDoctor { get; set; }
        public bool IsVisitByDoctor { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
