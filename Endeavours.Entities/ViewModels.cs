
using System.Collections.Generic;

namespace Endeavours.Entities
{
    public class RegistrationClass
    {
        public User user { get; set; }
        public UserProfile profile { get; set; }
    }


    public class OtherUserView
    { 
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string ProfilePhoto { get; set; }
        public string Profession { get; set; }
        public string City { get; set; }
    }

    public class FirstPageView
    {
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string City { get; set; }
        public string InstaLink { get; set; }
        public string FacebookLink { get; set; }
        public string GithubLink { get; set; }
        public string LinkedInLink { get; set; }
        public string OtherLinks { get; set; }
        public List<OtherUserView> OtherUsers { get; set; }
    }
}
