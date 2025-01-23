namespace Factoring.Application.DTOs.Account.Request
{
    public class ChangePasswordRequest
    {
        public int IdUsuario { get; set; }
        public string NewPassword { get; set; }
        public int MustChangePassword { get; set; } 
    }
}
