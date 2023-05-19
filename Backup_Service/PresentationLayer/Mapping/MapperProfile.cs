using AutoMapper;
using BusinessLayer.Models;
using PresentationLayer.DTO;

namespace PresentationLayer.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<TariffDTO, TariffModel>()
            .ForMember(tariff => tariff.TariffName,
                opt => opt.MapFrom(tariffModel => tariffModel.TariffName))
            .ForMember(tariff => tariff.Price,
                opt => opt.MapFrom(tariffModel => tariffModel.Price))
            .ForMember(tariff => tariff.BackupSize,
                opt => opt.MapFrom(tariffModel => tariffModel.BackupSize));
        
        CreateMap<TariffModel, TariffDTO>()
            .ForMember(tariff => tariff.TariffName,
                opt => opt.MapFrom(tariffModel => tariffModel.TariffName))
            .ForMember(tariff => tariff.Price,
                opt => opt.MapFrom(tariffModel => tariffModel.Price))
            .ForMember(tariff => tariff.BackupSize,
                opt => opt.MapFrom(tariffModel => tariffModel.BackupSize));
        
        CreateMap<UserDTO, UserModel>()
            .ForMember(user => user.Name,
                opt => opt.MapFrom(userModel => userModel.Name))
            .ForMember(user => user.Surname,
                opt => opt.MapFrom(userModel => userModel.Surname))
            .ForMember(user => user.Email,
                opt => opt.MapFrom(userModel => userModel.Email))
            .ForMember(user => user.PhoneNumber,
                opt => opt.MapFrom(userModel => userModel.PhoneNumber));
        
        CreateMap<UserModel, UserDTO>()
            .ForMember(user => user.Name,
                opt => opt.MapFrom(userModel => userModel.Name))
            .ForMember(user => user.Surname,
                opt => opt.MapFrom(userModel => userModel.Surname))
            .ForMember(user => user.Email,
                opt => opt.MapFrom(userModel => userModel.Email))
            .ForMember(user => user.PhoneNumber,
                opt => opt.MapFrom(userModel => userModel.PhoneNumber));
        
        CreateMap<AccountDTO, AccountModel>()
            .ForMember(account => account.Login,
                opt => opt.MapFrom(accountModel => accountModel.Login))
            .ForMember(account => account.Password,
                opt => opt.MapFrom(accountModel => accountModel.Password))
            .ForMember(account => account.IdStorage,
                opt => opt.MapFrom(accountModel => accountModel.IdStorage))
            .ForMember(account => account.IdUser,
                opt => opt.MapFrom(accountModel => accountModel.IdUser))
            .ForMember(account => account.TariffType,
                opt => opt.MapFrom(accountModel => accountModel.TariffType));
        
        CreateMap<AccountModel, AccountDTO>()
            .ForMember(account => account.Login,
                opt => opt.MapFrom(accountModel => accountModel.Login))
            .ForMember(account => account.Password,
                opt => opt.MapFrom(accountModel => accountModel.Password))
            .ForMember(account => account.IdStorage,
                opt => opt.MapFrom(accountModel => accountModel.IdStorage))
            .ForMember(account => account.IdUser,
                opt => opt.MapFrom(accountModel => accountModel.IdUser))
            .ForMember(account => account.TariffType,
                opt => opt.MapFrom(accountModel => accountModel.TariffType));
        
        CreateMap<BackupDTO, BackupModel>()
            .ForMember(backup => backup.Name,
                opt => opt.MapFrom(backupModel => backupModel.Name))
            .ForMember(backup => backup.IdStorage,
                opt => opt.MapFrom(backupModel => backupModel.IdStorage))
            .ForMember(backup => backup.Size,
                opt => opt.MapFrom(backupModel => backupModel.Size))
            .ForMember(backup => backup.TariffType,
                opt => opt.MapFrom(backupModel => backupModel.TariffType))
            .ForMember(backup => backup.CreationTime,
                opt => opt.MapFrom(backupModel => backupModel.CreationTime));
        
        CreateMap<BackupModel, BackupDTO>()
            .ForMember(backup => backup.Name,
                opt => opt.MapFrom(backupModel => backupModel.Name))
            .ForMember(backup => backup.IdStorage,
                opt => opt.MapFrom(backupModel => backupModel.IdStorage))
            .ForMember(backup => backup.Size,
                opt => opt.MapFrom(backupModel => backupModel.Size))
            .ForMember(backup => backup.TariffType,
                opt => opt.MapFrom(backupModel => backupModel.TariffType))
            .ForMember(backup => backup.CreationTime,
                opt => opt.MapFrom(backupModel => backupModel.CreationTime));
        
        CreateMap<StorageDTO, StorageModel>()
            .ForMember(storage => storage.Path,
                opt => opt.MapFrom(storageModel => storageModel.Path))
            .ForMember(storage => storage.TotalSize,
                opt => opt.MapFrom(storageModel => storageModel.TotalSize))
            .ForMember(storage => storage.UsedSize,
                opt => opt.MapFrom(storageModel => storageModel.UsedSize));
        
        CreateMap<StorageModel, StorageDTO>()
            .ForMember(storage => storage.Path,
                opt => opt.MapFrom(storageModel => storageModel.Path))
            .ForMember(storage => storage.TotalSize,
                opt => opt.MapFrom(storageModel => storageModel.TotalSize))
            .ForMember(storage => storage.UsedSize,
                opt => opt.MapFrom(storageModel => storageModel.UsedSize));
    }
}