namespace CodeChallenge.Core.Entities.BasicInfo
{
    public class Drug : BaseEntity
    {
        public Drug()
        {
            AppointmentDrugs = new List<AppointmentDrug>();
        }


        public string Description { get; set; }
        public int Price { get; set; }


        #region Relations

        public virtual ICollection<AppointmentDrug> AppointmentDrugs { get; set; }

        #endregion

    }
}
