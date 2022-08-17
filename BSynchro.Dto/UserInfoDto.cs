using BSynchro.Dto.Validation;

namespace BSynchro.Dto
{
    public class UserInfoDto
    {
        [CustomerIdValidation]
        public string CustomerId { get; set; } 
        public double InitialCredit { get; set; }
    }
}
