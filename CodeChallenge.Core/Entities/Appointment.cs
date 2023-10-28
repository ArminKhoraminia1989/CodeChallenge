using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Core.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment()
        {
            AppointmentDrugs = new List<AppointmentDrug>();
        }


        public int DurationTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BriefDescriptionSickness { get; set; }
        public string DescriptionOfDoctor { get; set; }
        public bool IsVisitByDoctor { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }


        #region Relations

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<AppointmentDrug> AppointmentDrugs { get; set; }

        #endregion
    }
}
