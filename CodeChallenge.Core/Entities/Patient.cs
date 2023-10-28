using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Core.Entities
{
    public class Patient : BasePersonDetail
    {
        public Patient()
        {
            Appointment = new List<Appointment>();
        }

        #region Relations

        public virtual ICollection<Appointment> Appointment { get; set; }

        #endregion
    }
}
