namespace GrindRailsAPI.Shared.ModelsView.User
{
    public class UserCreateViewModel
    {

        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string PhoneNumber { get; set; }
    }
}
