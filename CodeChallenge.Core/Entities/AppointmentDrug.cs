using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Core.Entities
{
    public class AppointmentDrug : BaseEntity
    {
        public int AppointmentId { get; set; }
        public int DrugId { get; set; }
        public int Qty { get; set; }


        #region Relations

        public virtual Appointment Appointment { get; set; }
        public virtual Drug Drug { get; set; }

        #endregion
    }
}
