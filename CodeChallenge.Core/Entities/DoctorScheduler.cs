using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Core.Entities
{
    public class DoctorScheduler : BaseEntity
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }


        #region Relation

        public virtual Doctor Doctor { get; set; }

        #endregion
    }
}
