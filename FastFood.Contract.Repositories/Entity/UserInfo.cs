using FastFood.Core.Base;
namespace FastFood.Contract.Repositories.Entity
{
    public class UserInfo : BaseEntity
    {

        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Gender { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Status { get; set; } = UserStatus.Active.ToString();
        public required string PositionId { get; set; }
        public virtual Position? Position { get; set; }
        public enum UserStatus
        {
            Active,
            Inactive
        }
    }
}
