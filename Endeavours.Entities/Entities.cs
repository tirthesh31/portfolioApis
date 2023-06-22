using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavours.Entities
{
public class User
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }
}

public class UserProfile
{
    public int UserID { get; set; }
    public string FullName { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }
    public DateTime Dob { get; set; }
    public string Website { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public string Profession { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string JobType { get; set; }
    public string InstaLink { get; set; }
    public string FacebookLink { get; set; }
    public string GithubLink { get; set; }
    public string LinkedinLink { get; set; }
    public string OtherLinks { get; set; }
}

public class Education
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public string Degree { get; set; }
    public string Institution { get; set; }
    public string Location { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}

public class WorkExperience
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public string Position { get; set; }
    public string Company { get; set; }
    public string Location { get; set; }
    public string Duration { get; set; }
    public string Description { get; set; }
}

public class Project
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public string ProjectName { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string TechnologiesUsed { get; set; }
    public int Year { get; set; }
    public string Client { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string[] Images { get; set; }
}

public class Skill
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public string SkillName { get; set; }
    public int Proficiency { get; set; }
}

public class Achievement
{
    public int UserID { get; set; }
    public string AchievementName { get; set; }
    public int Year { get; set; }
    public string Place { get; set; }
    public string Description { get; set; }
}

public class Testimonial
{
    public int UserID { get; set; }
    public int CommentorID { get; set; }
    public string Message { get; set; }
}

public class Reference
{
    public int UserID { get; set; }
    public string ReferenceName { get; set; }
    public string OrgName { get; set; }
    public string Passion { get; set; }
    public string Email { get; set; }
}

public class Service
{
    public int SID { get; set; }
    public string SType { get; set; }
    public int UID { get; set; }
    public string Description { get; set; }
}

public class Query
{
    public int FID { get; set; }
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime AskDate { get; set; }
    public string ReplySubject { get; set; }
    public string ReplyMessage { get; set; }
    public DateTime ReplyDate { get; set; }
}
    public class Interest
    {
        public int interestId { get; set; }
        public string name { get; set; }
        public int userId { get; set; }
    }
}
