namespace FastFood.ModelViews.UserModelViews
{
    public class ChangePasswordModelView
    {
        public required string OldPassword { get; set; }

        public required string NewPassword { get; set; }

        public required string ConfirmPassword { get; set; }
    }
}
