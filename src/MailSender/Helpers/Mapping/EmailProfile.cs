using AutoMapper;
using MailSender.DTOs.Responses;
using MailTrapClient.DTOs.Requests;
using MailTrapClient.DTOs.Responses;

namespace MailSender.Helpers.Mapping;

public class EmailProfile : Profile
{
    public EmailProfile()
    {
        CreateMap<IFormFile, Attachment>()
            .ForMember(dest => dest.Filename, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ContentType))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => ConvertToBase64(src)));

        CreateMap<SendResponse, SendMailResponse>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => string.Join("", src.Errors)));
    }

    private static string ConvertToBase64(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        return Convert.ToBase64String(memoryStream.ToArray());
    }
}