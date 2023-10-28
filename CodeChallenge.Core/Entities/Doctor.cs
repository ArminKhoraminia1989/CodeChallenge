using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Core.Entities
{
    public class Doctor : BasePersonDetail
    {
        public Doctor()
        {
            DoctorSchedulers = new List<DoctorScheduler>();
            Appointment = new List<Appointment>();
        }

        public int TypeDoctorId { get; set; }


        #region Relations

        public virtual DoctorType TypeDoctor { get; set; }
        public virtual ICollection<DoctorScheduler> DoctorSchedulers { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }

        #endregion
    }
}
