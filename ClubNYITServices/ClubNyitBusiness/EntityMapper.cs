using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClubNYITDataAccess;
using ClubNYITDataTransferObjects.RequestDTO;
using ClubNYITDataTransferObjects.ResponseDTO;
using System.Reflection;

namespace ClubNyitBusiness
{
    public static class EntityMapper
    {
        internal static UserDetailResponseDto MapUserDetailtoUserDetailResponse(UserDetail userDetail)
        {
            Mapper.CreateMap<UserDetail, UserDetailResponseDto>();
            return Mapper.Map<UserDetail, UserDetailResponseDto>(userDetail);
        }

        internal static ClubDetail MapCreateClubRequesttoClubDetail(CreateClubRequestDto createClubRequestDto)
        {
            Mapper.CreateMap<CreateClubRequestDto, ClubDetail>();
            return Mapper.Map<CreateClubRequestDto, ClubDetail>(createClubRequestDto);
        }

        internal static ClubDetailResponseDto MapClubDetailtoClubDetailResponse(ClubDetail clubDetail)
        {
            Mapper.CreateMap<ClubDetail, ClubDetailResponseDto>();
            return Mapper.Map<ClubDetail, ClubDetailResponseDto>(clubDetail);
        }

        internal static UserDetail MapRegisterUserRequesttoUserDetai(RegisterUserRequestDto registerUserRequestDto)
        {
            Mapper.CreateMap<RegisterUserRequestDto, UserDetail>().ForMember(x => x.Gender, opt => opt.Ignore());
            return Mapper.Map<RegisterUserRequestDto, UserDetail>(registerUserRequestDto);
        }

        internal static EventDetail MapCreateEventRequesttoEventDetail(CreateEventRequestDto createEventRequestDto)
        {
            Mapper.CreateMap<CreateEventRequestDto, EventDetail>();
            return Mapper.Map<CreateEventRequestDto, EventDetail>(createEventRequestDto);
        }

        internal static GetAllEmployeesResponseDto MapUserDetailtoGetAllEmployeesResponse(IList<UserDetail> eUser)
        {
            Mapper.CreateMap<UserDetail, UserDetailResponseDto>();
            Mapper.CreateMap<IList<UserDetail>, IList<UserDetailResponseDto>>();
            IList<UserDetailResponseDto> peopelVM = eUser.Select(Mapper.Map<UserDetail, UserDetailResponseDto>).ToList<UserDetailResponseDto>();
            return new GetAllEmployeesResponseDto { UserDetailResponseDto = peopelVM };
        }

        internal static GetAllStudentsResponseDto MapUserDetailtoGetAllStudentsResponse(IList<UserDetail> sUser)
        {
            Mapper.CreateMap<UserDetail, UserDetailResponseDto>();
            Mapper.CreateMap<IList<UserDetail>, IList<UserDetailResponseDto>>();
            IList<UserDetailResponseDto> peopelVM = sUser.Select(Mapper.Map<UserDetail, UserDetailResponseDto>).ToList<UserDetailResponseDto>();
            return new GetAllStudentsResponseDto { UserDetailResponseDto = peopelVM };
        }

        internal static IList<EventResponseDto> MapEventDetailtoEventResponse(IList<EventDetail> eventsDetail)
        {
            Mapper.CreateMap<EventDetail, EventResponseDto>();
            Mapper.CreateMap<IList<EventDetail>, IList<EventResponseDto>>();
            IList<EventResponseDto> events = eventsDetail.Select(Mapper.Map<EventDetail, EventResponseDto>).ToList<EventResponseDto>();
            return events;
        }

        internal static EventDetailResponseDto MapEventDetailtoEventDetailResponse(EventDetail eventDetail)
        {
            Mapper.CreateMap<EventDetail, EventDetailResponseDto>();
            return Mapper.Map<EventDetail, EventDetailResponseDto>(eventDetail);
        }

        internal static IList<ClubResponseDto> MapClubDetailtoClubResponse(IList<ClubDetail> club)
        {
            Mapper.CreateMap<ClubDetail, ClubResponseDto>();
            Mapper.CreateMap<IList<ClubDetail>, IList<ClubResponseDto>>();
            IList<ClubResponseDto> clubs = club.Select(Mapper.Map<ClubDetail, ClubResponseDto>).ToList<ClubResponseDto>();
            return clubs;
        }
    }
}

