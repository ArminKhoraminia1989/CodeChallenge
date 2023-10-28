using CodeChallenge.Core.Entities.Enums;

namespace CodeChallenge.Core.Entities.BasicInfo
{
    public abstract class BasePersonDetail : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public EnumGender Gender { get; set; }
        public string NationalCode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
