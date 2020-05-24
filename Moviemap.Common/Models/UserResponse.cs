using Moviemap.Common.Emuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PicturePath { get; set; }

        public UserType UserType { get; set; }

        public LoginType LoginType { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PictureFullPath => string.IsNullOrEmpty(PicturePath)
            ? "https://moviemapweb.azurewebsites.net/images/NoImage.jpg"
            : LoginType == LoginType.Moviemap ? $"https://moviemapweb.azurewebsites.net{PicturePath.Substring(1)}" : PicturePath;
    }
}
