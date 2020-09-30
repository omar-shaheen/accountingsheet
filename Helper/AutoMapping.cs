using AutoMapper;
using ACCOUNTINGSHEET.Model.viewmodel;
using ACCOUNTINGSHEET.Model;
namespace ACCOUNTINGSHEET.Helper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<RegistrationViewModel, User>(); // means you want to map from User to UserDTO
            CreateMap<User,RegistrationViewModel>();
        }
    }

   
}