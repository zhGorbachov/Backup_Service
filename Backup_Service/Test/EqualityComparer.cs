using System.Diagnostics.CodeAnalysis;
using DataLayer.Entities;

namespace Test;

internal class StorageEqualityComparer : IEqualityComparer<Storage>
{
    public bool Equals([AllowNull] Storage x, [AllowNull] Storage y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.Path == y.Path
               && x.TotalSize == y.TotalSize
               && x.UsedSize == y.UsedSize;
    }

    public int GetHashCode([DisallowNull] Storage obj)
    {
        return obj.GetHashCode();
    }
}

internal class AccountEqualityComparer : IEqualityComparer<Account>
{
    public bool Equals([AllowNull] Account x, [AllowNull] Account y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.IdUser == y.IdUser
               && x.IdStorage == y.IdStorage
               && x.Login == y.Login
               && x.Password == y.Password
               && x.TariffType == y.TariffType;
    }

    public int GetHashCode([DisallowNull] Account obj)
    {
        return obj.GetHashCode();
    }
}

internal class UserEqualityComparer : IEqualityComparer<User>
{
    public bool Equals([AllowNull] User x, [AllowNull] User y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.Name == y.Name
               && x.Surname == y.Surname
               && x.Email == y.Email
               && x.PhoneNumber == y.PhoneNumber;
    }

    public int GetHashCode([DisallowNull] User obj)
    {
        return obj.GetHashCode();
    }
}

internal class BackupEqualityComparer : IEqualityComparer<Backup>
{
    public bool Equals([AllowNull] Backup x, [AllowNull] Backup y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.IdStorage == y.IdStorage
               && x.Name == y.Name
               && x.TariffType == y.TariffType
               && x.CreationTime == y.CreationTime
               && x.Size == y.Size
               && x.IdAccount == y.IdAccount;
    }

    public int GetHashCode([DisallowNull] Backup obj)
    {
        return obj.GetHashCode();
    }
}

internal class TariffEqualityComparer : IEqualityComparer<Tariff>
{
    public bool Equals([AllowNull] Tariff x, [AllowNull] Tariff y)
    {
        if (x == null && y == null)
            return true;
        if (x == null || y == null)
            return false;

        return x.Id == y.Id
               && x.TariffName == y.TariffName
               && x.BackupSize == y.BackupSize
               && x.Price == y.Price;
    }

    public int GetHashCode([DisallowNull] Tariff obj)
    {
        return obj.GetHashCode();
    }
}