using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using ACCOUNTINGSHEET.Model;
using ACCOUNTINGSHEET.Model.viewmodel;
using ACCOUNTINGSHEET.Helper;
using ACCOUNTINGSHEET.Model.repositories;
using AutoMapper;
namespace ACCOUNTINGSHEET.Controllers
{

    [Route("api/[controller]")]
    public class AuthController: Controller
    {
          private IOptions<Audience> _settings;
          private UnitOfWork unitOfWork = new UnitOfWork();
          private readonly IMapper _mapper;
          public AuthController(IOptions<Audience> settings,IMapper mapper)
          {
             this._settings= settings;
             _mapper = mapper;
          }
         
          [Route("Register")]
          public bool Register([FromBody]RegistrationViewModel _userViewModel) 
          {
               if (_userViewModel!=null)
               {              
                    var us = _mapper.Map<User>(_userViewModel);
                    us.Password = Helper.ComputeHash.ComputeMD5Hash(_userViewModel.Password);
                    unitOfWork.Userrepository.Add(us);
                    unitOfWork.Commit();                  
                    return true;
                }
                else
                {
                return false;
                 }
         }

          [HttpGet("checkemailfound")]
          public bool checkemailfound(string email) 
          {
               if (email!=null)
               {              
                   var usertemp=unitOfWork.Userrepository.FetchByEmail(email);
                    if(usertemp!=null){
                          return true;    
                    }else{
                         return false;   
                    }
                }
                return false;      
          }

           [HttpGet("checkmobilefound")]
          public bool checkmobilefound(string mobile) 
          {
               if (mobile!=null)
               {              
                   var usertemp=unitOfWork.Userrepository.FetchByMobile(mobile);
                    if(usertemp!=null){
                          return true;    
                    }else{
                         return false;   
                    }
                }
                return false;      
          }

          [Route("changepassword")]
          public bool changepassword([FromBody]RegistrationViewModel _userViewModel) 
          {
               if (_userViewModel!=null)
               {              
                    var userdb= unitOfWork.Userrepository.FetchByEmail(_userViewModel.Email);
                    if(userdb!=null){
                      userdb.Password = Helper.ComputeHash.ComputeMD5Hash(_userViewModel.Password);
                      unitOfWork.Userrepository.Update(userdb,userdb.Id);
                      unitOfWork.Commit();                  
                      return true;
                    }else{
                        return false;
                    }  
                }
                else
                {
                return false;
                }
         }

           [Route("updateuserinfo")]
          public bool updateuserinfo([FromBody]RegistrationViewModel _userViewModel) 
          {
               if (_userViewModel!=null)
               {              
                    var userdb= unitOfWork.Userrepository.FetchByEmail(_userViewModel.Emailold);
                    if(userdb!=null){
                      if(!string.IsNullOrEmpty(_userViewModel.Email)){
                          userdb.Email=_userViewModel.Email;
                          userdb.Emailactivated=false;
                      }
                      if(!string.IsNullOrEmpty(_userViewModel.Mobile)){
                          userdb.Mobile=_userViewModel.Mobile;
                          userdb.Mobileactivated=false;
                      }
                      if(!string.IsNullOrEmpty(_userViewModel.Name)){
                          userdb.Name=_userViewModel.Name;
                      }
                      if(_userViewModel.Gender>0){
                          userdb.Gender=_userViewModel.Gender;
                      }
                      if(_userViewModel.birthdatechange!=null && _userViewModel.birthdatechange.Value){
                          userdb.Birthdate=_userViewModel.Birthdate;
                      }
                      unitOfWork.Userrepository.Update(userdb,userdb.Id);
                      unitOfWork.Commit();                  
                      return true;
                    }else{
                        return false;
                    }  
                }
                else
                {
                return false;
                }
         }

           [HttpGet("getuserinfo")]
          public RegistrationViewModel getuserinfo(string email) 
          {
               if (email!=null)
               {              
                   var usertemp=unitOfWork.Userrepository.FetchByEmail(email);
                    if(usertemp!=null){
                         return  _mapper.Map<RegistrationViewModel>(usertemp);
                             
                    }else{
                         return null;   
                    }
                }
                return null;      
          }



          [HttpPost("auth")]
        public ActionResult<ResponseData> auth([FromBody]AuthParameters parameters)
        {
            if (parameters == null)
            {
                return Helper.Helper.CreateResponse("901", "null of parameters", null);
            }
            if (parameters.grant_type == "password")
            {
                var ReturnModel = DoPassword(parameters);
                return ReturnModel;
            }
            else
            {
               return Helper.Helper.CreateResponse("904", "bad request", null);
             }
        }
        //scenario 1 ï¼š get the access-token by Email and password  
        private ResponseData DoPassword(AuthParameters parameters)
        {
            var isClientValidated =unitOfWork.RefreshTokenrepository.AnyClient(parameters.client_id, parameters.client_secret);
            var user = unitOfWork.RefreshTokenrepository.GetUserByEmailAndPassword(parameters.email, parameters.password);
            if (!isClientValidated || user == null)
            {
                return new ResponseData
                {
                    Code = "902",
                    Message = "invalid user infomation",
                    Data = null
                };
            }
            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");
            var rToken = unitOfWork.RefreshTokenrepository.GenerateRefreshTokenModel(
                parameters.client_id,
                parameters.client_secret,
                user.Email,
                refresh_token,
                user.Id);     
            //store the refresh_token   
            if (unitOfWork.RefreshTokenrepository.AddToken(rToken))
            {
                if (unitOfWork.RefreshTokenrepository.UpdateLastAccess(user.Id))
                    return new ResponseData
                    {
                        Code = "999",
                        Message = "OK",
                        Data = GetJwt(parameters.client_id, refresh_token, user)
                    };
                else
                    return new ResponseData
                    {
                        Code = "909",
                        Message = "can not update last access in database",
                        Data = null
                    };
            }
            else
            {
                return new ResponseData
                {
                    Code = "909",
                    Message = "can not add token to database",
                    Data = null
                };
            }
        }
        //get the jwt token   
        private Object GetJwt(string client_id, string refresh_token, User User)
        {
            string RoleName="";
            if(User != null){
               // if(User.Usertype.Value == 3){
                    RoleName="user";
               // }
            }   
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, client_id),
                new Claim("UserId", User.Id.ToString()),
                new Claim("Email", User.Email.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                 new Claim(ClaimTypes.Role, RoleName)   
            };

            var symmetricKeyAsBase64 = _settings.Value.Secret;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Iss,
                audience: _settings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.AddDays(30),
                signingCredentials: new SigningCredentials(signingKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
             
            var response = new
            {
                access_token = encodedJwt,
                expires_in = now.AddDays(30),
                refresh_token = refresh_token,
                usertype = "user",
            };
          return response;
      }

    }
}