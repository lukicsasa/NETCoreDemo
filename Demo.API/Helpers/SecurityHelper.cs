using Demo.API.Models;
using Demo.API.Models.User;
using Demo.Data.Entities;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Helpers
{
    public static class SecurityHelper
    {
        public static string SecretKey { get; set; }

        public static T Decode<T>(string value)
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            return decoder.DecodeToObject<T>(value);
        }

        public static string CreateLoginToken(User user)
        {
            var userJwtModel = new UserJwtModel
            {
                Id = user.Id,
                Role = Mapper.AutoMap<Role, RoleModel>(user.Role),
                RoleId = user.RoleId,
                ExpirationDate = DateTime.UtcNow.AddDays(1)
            };

            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(new HMACSHA256Algorithm(), serializer, urlEncoder);
            return encoder.Encode(userJwtModel, SecretKey);
        }
    }
}
