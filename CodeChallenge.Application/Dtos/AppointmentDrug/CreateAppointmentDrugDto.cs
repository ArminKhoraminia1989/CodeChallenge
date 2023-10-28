using CodeChallenge.Dtos.BasicInfo;

namespace CodeChallenge.Dtos.AppointmentDrug
{
    public class CreateAppointmentDrugDto : BaseDto
    {
        public int AppointmentId { get; set; }
        public int DrugId { get; set; }
        public int Qty { get; set; }
    }
}
