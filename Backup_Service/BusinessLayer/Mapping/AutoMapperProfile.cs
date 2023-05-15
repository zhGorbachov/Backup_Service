using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Entities;

namespace BusinessLayer.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Account, AccountModel>()
            .ForMember(account => account.Login,
                opt => opt.MapFrom(accountModel => accountModel.Login))
            .ForMember(account => account.Password,
                opt => opt.MapFrom(accountModel => accountModel.Password));
        
        CreateMap<Backup, BackupModel>()
            .ForMember(backup => backup.Name,
                opt => opt.MapFrom(backupModel => backupModel.Name))
            .ForMember(backup => backup.IdStorage,
                opt => opt.MapFrom(backupModel => backupModel.IdStorage));

        CreateMap<Storage, StorageModel>()
            .ForMember(storage => storage.Id,
                opt => opt.MapFrom(storageModel => storageModel.Id));
        
        CreateMap<User, UserModel>()
            .ForMember(user => user.Name,
                opt => opt.MapFrom(userModel => userModel.Name))
            .ForMember(user => user.Surname,
                opt => opt.MapFrom(userModel => userModel.Surname))
            .ForMember(user => user.Email,
                opt => opt.MapFrom(userModel => userModel.Email));

        CreateMap<Tariff, TariffModel>()
                    .ForMember(tariff => tariff.TariffName,
                        opt => opt.MapFrom(tariffModel => tariffModel.TariffName));
        
        // CreateMap<Storage, StorageModel>()
        //     .ForMember(storage => storage.Path,
        //         opt => opt.MapFrom(storageModel => storageModel.Path));
    }
}