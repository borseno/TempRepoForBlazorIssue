using System;
using AutoMapper;
using Votings.Server.DAL.Models;
using Votings.Shared;
using Votings.Shared.DTO;
using Votings.Shared.PageModels;

public class MappingProfile : Profile {
    public MappingProfile() : base()
    {
        CreateMap<User, UserLimited>();
        CreateMap<VotingInitialInfoModel, Voting>()
            .ForMember(i => i.Options, opt => opt.Ignore());
        CreateMap<Voting, VotingState>();
        CreateMap<Choice, ChoiceInfo>();
        CreateMap<Option, OptionInfo>();
        CreateMap<Voting, VotingEditModel>();
        CreateMap<Voting, VotingReference>();
    }
}