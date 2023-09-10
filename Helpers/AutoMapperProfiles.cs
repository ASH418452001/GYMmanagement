using AutoMapper;
using GYMmanagement.DtOs.AttendanceDtO;
using GYMmanagement.DtOs.BookingDtO;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.FeedBacksDtO;
using GYMmanagement.DtOs.MemberShipDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.DtOs.Schedule;
using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.DtOs.UsersDtO.Update;
using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Entities;
using GYMmanagement.Extension;

namespace GYMmanagement.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            //CreateMap<User, UserInformation>();
            CreateMap<User, GetTrainerDtO>().
                ForMember(dest => dest.Age, opt => opt.
                MapFrom(src => src.DateOfBirth.CalculateAge()));        //To Get The Users
            CreateMap<User, GetMemberDtO>().
                ForMember(dest => dest.Age, opt => opt.
                MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, GetEmployeeDtO>().
                ForMember(dest => dest.Age, opt => opt.
                MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<UserInformation, User>();
            CreateMap<EmployeeDtO, User>();
            CreateMap<TrainerDtO, User>();      //To Create Users
            CreateMap<MemberDtO, User>();



            CreateMap<UpdateTrainerDtO, User>();
            CreateMap<UpdateEmployeeDtO, User>();
            CreateMap<UpdateMemberByEmployeeDtO, User>();      //To Update Users
            CreateMap<UpdateMemberDtO, User>();






            CreateMap<GetClassDtO, Class>().
                ForMember(dest => dest.Trainer, opt => opt.
                MapFrom(src => src.Trainer));//why?
                    
                   

         
            CreateMap<Class, GetClassDtO>();  //To Get The Classes
            CreateMap<CreateClassDtO, Class>();  //To Create The Classes
            CreateMap<UpdateClassDtO, Class>();  //To Update The Classes



            CreateMap<Membership, GetMemberShipDtO>();//To Get The MemberShips
            CreateMap<Create_UpdateMemberShipDtO, Membership>();  //To Create & Update The MemberShips





            //// Mapping from a collection of Payment to GetPaymentDtO to present payments by username with the member in Getpayment in paymentCotroller
            //CreateMap<ICollection<Payment>, ICollection<GetPaymentDtO>>();
            //CreateMap<User,GetPaymentDtO>();//map properties from instances of the User entity class to instances of the GetPaymentDtO DTO class.
            ////& i need the above code of create map to get payment by member Username
           
            CreateMap<Payment, GetPaymentDtO>();  //To Get The Payments
            CreateMap<CreatePaymentDtO, Payment>();  //To Create The Payments

            CreateMap<Schedule, GetScheduleDtO>().
                ForMember(dest => dest.ClassTime, opt => opt.//To Get The Schedules
                MapFrom(src => src.ClassTimes.ToTimeOnly())).
                ForMember(dest => dest.ClassDate, opt => opt.
                MapFrom(src => src.ClassTimes.ToDateOnly()));  
            CreateMap<Create_UpdateScheduleDtO, Schedule>();  //To Create & Update The Schedules


            CreateMap<Booking, GetBookingDtO>().
                ForMember(dest => dest.ClassTime, opt => opt.//To Get The Bookings
                MapFrom(src => src.ClassTimes.ToTimeOnly())).
                ForMember(dest => dest.ClassDate, opt => opt.
                MapFrom(src => src.ClassTimes.ToDateOnly()));
            CreateMap<Create___UpdateBookingDtO, Booking>();  //To Create & Update The Bookings
            
           
            


            CreateMap<Attendance, GetAttendanceDtO>().
                ForMember(dest => dest.ClassTime, opt => opt.//To Get The Bookings
                MapFrom(src => src.ClassTimes.ToTimeOnly())).
                ForMember(dest => dest.ClassDate, opt => opt.
                MapFrom(src => src.ClassTimes.ToDateOnly()));
            CreateMap<Create___UpdateAttendaceDtO, Attendance>();
                  //To Create & Update The Bookings

            
            
            
            
            
            CreateMap<Feedback, GetFeedBacksDtO>();  //To Get The FeedBacks
            CreateMap<Create_UpdateFeedBacksDtO, Feedback>();  //To Create & Update The FeedBacks


            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<DateTime?, DateTime?>().ConvertUsing(d => d.HasValue ?
                DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null);
        }


    }
}
