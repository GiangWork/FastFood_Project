using AutoMapper;
using FastFood.Contract.Repositories.Entity;
using FastFood.ModelViews.BankAccountModelViews;
using FastFood.ModelViews.BookingModelViews;
using FastFood.ModelViews.CalenderTypeModelViews;
using FastFood.ModelViews.CheckInModelViews;
using FastFood.ModelViews.CourtModelView;
using FastFood.ModelViews.PositionViewModel;
using FastFood.ModelViews.TimeFrameModelViews;
using FastFood.ModelViews.UserModelViews;


namespace FastFood.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Create AutoMapper
            //CreateMap<BookingResponseModelView, Booking>().ReverseMap();
            //CreateMap<CreateBookingModelView, Booking>().ReverseMap();
            //CreateMap<UpdateBookingModelView, Booking>().ReverseMap();

            //CreateMap<GetBankAccountModelView, BankAccount>().ReverseMap();
            //CreateMap<CreateBankAccountModelView, BankAccount>();
            //CreateMap<UpdateBankAccountModelView, BankAccount>();
            //CreateMap<DeleteBankAccountModelView, BankAccount>();


            //CreateMap<TimeFrame, TimeFrameModelView>();
            //CreateMap<EditTimeFrameModelView, TimeFrame>();



            //CreateMap<CourtModelView, Court>();
            //CreateMap<EditCourtModel, Court>();
            //CreateMap<Court, CourtModelView>();


            //CreateMap<UserInfo, UserViewModel>();
            //CreateMap<UserCreateModel, UserInfo>();

            //CreateMap<CreateCheckInModelView, CheckIn>().ReverseMap();
            //CreateMap<GetCheckInModelView, CheckIn>().ReverseMap();
            //CreateMap<DeleteCheckInModelView, CheckIn>().ReverseMap();
            //CreateMap<UpdateCheckInModelView, CheckIn>().ReverseMap();

            //CreateMap<CalendarType, GetCalanderTypeModelView>();
            //CreateMap<CreateCalanderTypeModelView, CalendarType>();
            //CreateMap<UpdateCalanderTypeModelView, CalendarType>();
            //CreateMap<DeleteCalanderTypeModelView, CalendarType>();

            //CreateMap<CreatePositionViewModel, Position>();
            //CreateMap<UpdatePositionViewModel, Position>();
            //CreateMap<Position, GetPositionViewModel>();
        }
    }
}
