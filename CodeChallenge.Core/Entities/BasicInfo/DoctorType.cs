using CodeChallenge.Core.Entities.Enums;

namespace CodeChallenge.Core.Entities.BasicInfo
{
    public class DoctorType : BaseEntity
    {
        public DoctorType()
        {
            Doctors = new List<Doctor>();
        }


        public EnumDoctorType Type { get; set; }
        public int MinTimeVisit { get; set; }
        public int MaxTimeVisit { get; set; }


        #region Relations

        public virtual ICollection<Doctor> Doctors { get; set; }

        #endregion
    }
}
