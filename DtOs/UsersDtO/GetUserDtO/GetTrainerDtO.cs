﻿using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.Entities;
using GYMmanagement.Helpers;

namespace GYMmanagement.DtOs.UsersDtO.UpdateUserDtO
{
    public class GetTrainerDtO : UserInformation
    {
       
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Specialties { get; set; }
        public string Certification { get; set; }
    }
}
