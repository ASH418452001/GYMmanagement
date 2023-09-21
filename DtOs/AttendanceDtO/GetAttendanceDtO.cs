﻿using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;

namespace GYMmanagement.DtOs.AttendanceDtO
{
    public class GetAttendanceDtO
    {
        public Guid Id { get; set; }
        public GetMemberDtO Member { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
